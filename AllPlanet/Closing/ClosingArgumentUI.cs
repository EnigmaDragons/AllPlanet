using System.Collections.Generic;
using AllPlanet.Argument;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Inputs;
using System;

namespace AllPlanet.Closing
{
    public class ClosingArgumentUI : IVisual
    {
        private readonly CurrentClosingArgument _currentArgument;
        private readonly List<ImageTextButton> _optionButtons = new List<ImageTextButton>();
        private readonly ColoredRectangle _choosingOptionButtonBorder = new ColoredRectangle()
            { Transform = new Transform2(new Size2(1062, 132)), Color = Color.Green };
        private Transform2 _currentlyHighlightedOption = new Transform2(new Vector2(269, 2000));
        private float _currentlyHighlightedOptionAsFloat
        {
            get { return _currentlyHighlightedOption.Location.Y == 2000 ? -1 : (_currentlyHighlightedOption.Location.Y - 194) / 140; }
            set { _currentlyHighlightedOption.Location = value == -1 ? new Vector2(269, 2000) : new Vector2(269, 194 + 140 * value); }
        }

        private bool _active = false;

        public ClickUIBranch Branch { get; } = new ClickUIBranch("Closing", (int)ClickBranchPriority.Closing);

        public ClosingArgumentUI(CurrentClosingArgument argument)
        {
            ControlHandler.BindOnPress(2, Control.A, () => { if (_active) { ChooseCurrentlyHighlightedOption(); return true; } return false; });
            ControlHandler.BindOnPress(2, Control.Up, () => { if (_active) ChangeHighlightOptionUp(); return _active; });
            ControlHandler.BindOnPress(2, Control.Down, () => { if (_active) ChangeHighlightOptionDown(); return _active; });
            _currentArgument = argument;
            World.Subscribe(EventSubscription.Create<ModeChanged>(ChangeMode, this));
        }

        private void ChooseCurrentlyHighlightedOption()
        {
            if (_currentlyHighlightedOptionAsFloat != -1)
                _optionButtons[(int)_currentlyHighlightedOptionAsFloat].OnReleased();
        }

        private void ChangeHighlightOptionUp()
        {
            if (_currentlyHighlightedOptionAsFloat == -1)
                _currentlyHighlightedOptionAsFloat = 0;
            else if (_currentlyHighlightedOptionAsFloat > 0)
                _currentlyHighlightedOptionAsFloat--;
        }

        private void ChangeHighlightOptionDown()
        {
            if (_currentlyHighlightedOptionAsFloat == -1)
            {
                if (_optionButtons.Count > 1)
                    _currentlyHighlightedOptionAsFloat = 1;
                else
                    _currentlyHighlightedOptionAsFloat = 0;
            }
            else if (_currentlyHighlightedOptionAsFloat + 1 < _optionButtons.Count)
                _currentlyHighlightedOptionAsFloat++;
        }

        private void ChangeMode(ModeChanged obj)
        {
            _active = obj.Mode == Mode.ClosingArgument;
            UpdateOptions();
        }

        private void UpdateOptions()
        {
            ClearOptions();
            if (_active)
                MakeNewButtons();
        }

        private void ClearOptions()
        {
            _optionButtons.ForEach(x => Branch.Remove(x));
            _optionButtons.Clear();
        }

        private void MakeNewButtons()
        {
            var i = 0;
            _currentArgument.Get().CurrentChoice.AvailableOptionDescriptions.ForEach(x =>
            {
                var opt = Buttons.CreateClosingArgument(x.ToString(),
                    new Transform2(new Vector2(275, 200 + (i * 140)), new Size2(1050, 120)),
                        () => { _currentArgument.Get().Choose(x); UpdateOptions(); _currentlyHighlightedOptionAsFloat = -1; });
                _optionButtons.Add(opt);
                Branch.Add(opt);
                i++;
            });
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Darken();
            _choosingOptionButtonBorder.Draw(_currentlyHighlightedOption + parentTransform);
            _optionButtons.ForEach(x => x.Draw(parentTransform));
        }
    }
}