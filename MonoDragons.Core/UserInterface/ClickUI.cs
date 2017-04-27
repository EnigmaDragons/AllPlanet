using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System.Linq;

namespace MonoDragons.Core.UserInterface
{
    public sealed class ClickUI : IVisualAutomaton
    {
        public static readonly ClickableUIElement None = new NoneClickableUIElement();

        private List<ClickUIBranch> _branches = new List<ClickUIBranch> { new ClickUIBranch("Base", 0) };
        
        private readonly ColoredRectangle _elementHighlight = new ColoredRectangle { Color = Color.Transparent };
        private ClickableUIElement _currentElement = None;
        private bool _wasClicked;
        private ClickUIBranch _elementLayer;
        private bool _elementChangeAfterPressed;
        private readonly Action<ClickUIBranch>[] subscribeAction;

        public float Scale = 1;
        
        public ClickUI()
        {
            _elementLayer = _branches[0];
            subscribeAction = new Action<ClickUIBranch>[] { (br) => Add(br), (br) => Remove(br) }; ;
        }

        public void Add(ClickUIBranch branch)
        {
            var branches = GetAllBrancesFrom(branch);
            foreach (var b in branches)
            {
                _branches.Add(b);
                b.Subscribe(subscribeAction);
            }
            _branches = _branches.OrderBy((b) => b.Priority).Reverse().ToList();
        }

        private List<ClickUIBranch> GetAllBrancesFrom(ClickUIBranch branch)
        {
            var branches = new List<ClickUIBranch> { branch };
            foreach (ClickUIBranch subBranch in branch.SubBranches())
                branches.AddRange(GetAllBrancesFrom(subBranch));
            return branches;
        }

        public void Add(ClickableUIElement element)
        {
            _elementLayer.Add(element);
        }

        public void Remove(ClickUIBranch branch)
        {
            var branches = GetAllBrancesFrom(branch);
            foreach (var b in branches)
            {
                _branches.Remove(b);
                b.Unsubscribe(subscribeAction);
            }
        }

        public void Remove(ClickableUIElement element)
        {
            _elementLayer.Remove(element);
        }

        public void Update(TimeSpan delta)
        {
            var mouse = Mouse.GetState();
            if (Hack.TheGame.IsActive)
            {
                var newElement = GetElement(mouse.Position);
                if (newElement != _currentElement)
                    ChangeActiveElement(newElement);
                else if (MouseIsOutOfGame(mouse))
                    return;
                else if (WasMouseReleased(mouse))
                    OnReleased();
                else if (mouse.LeftButton == ButtonState.Pressed)
                    OnPressed();
            }
        }

        private bool MouseIsOutOfGame(MouseState mouse)
        {
            return mouse.Position.X < 0 || mouse.Position.X > Config.Width || mouse.Position.Y < 0 || mouse.Position.Y > Config.Height;
        }

        private void OnPressed()
        {
            if (_wasClicked)
                return;

            _currentElement.OnPressed();
            _wasClicked = true;
        }

        private void OnReleased()
        {
            _currentElement.OnReleased();
            _wasClicked = false;
            _elementChangeAfterPressed = false;
            _currentElement.OnEntered();
        }

        private void ChangeActiveElement(ClickableUIElement newElement)
        {
            _elementChangeAfterPressed = _wasClicked;
            _currentElement.OnExitted();
            _wasClicked = false;
            _currentElement = newElement;
            _currentElement.OnEntered();
            _elementHighlight.Transform = new Transform2(_currentElement.Area);
            _elementHighlight.Color = Color.FromNonPremultiplied(100, 100, 0, 30);
        }

        private bool WasMouseReleased(MouseState mouse)
        {
            var position = new Point((int)Math.Round(mouse.Position.X / Scale / Config.Scale),
                (int)Math.Round(mouse.Position.Y / Scale / Config.Scale));
            return _wasClicked 
                && mouse.LeftButton == ButtonState.Released 
                && new Rectangle(_currentElement.Area.Location + _currentElement.ParentLocation.ToPoint(), _currentElement.Area.Size)
                    .Contains(position);
        }

        private ClickableUIElement GetElement(Point mousePosition)
        {
            var position = new Point((int)Math.Round(mousePosition.X / Scale / Config.Scale),
                (int)Math.Round(mousePosition.Y / Scale / Config.Scale));
            var branch = _branches.Find((b) => b.GetElement(position) != None);
            return branch != null ? branch.GetElement(position) : None ;
        }

        public void Draw(Transform2 parentTransform)
        {
#if DEBUG
            _elementHighlight?.Draw(parentTransform + _elementLayer.Location);
            UI.DrawText($"Mouse: {Mouse.GetState().Position}", new Vector2(1200, 800), Color.Yellow);
            UI.DrawText($"Clicked: {_wasClicked}, {_elementChangeAfterPressed}", new Vector2(1200, 840), Color.Yellow);
#endif
        }
    }
}
