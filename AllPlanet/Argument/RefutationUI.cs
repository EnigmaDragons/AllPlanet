using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public sealed class RefutationUI : IVisualAutomaton
    {
        private readonly ArgumentNavUI _navUi;
        private readonly ClickUI _clickUi;
        private readonly ClickUIBranch _interactBranch;
        private readonly ImageButton _refuteButton;
        private readonly ImageButton _cancelButton;
        private readonly ColoredRectangle _darken;
        private readonly List<TextButton> _optionButtons = new List<TextButton>();

        private Statement _currentStatement;

        private bool _active;
        private bool _isRefuting;
        private bool _isRefutingChanged;
        private bool CanClickRefute => _active && !_isRefuting;
        private bool CanClickCancel => _active && _isRefuting;

        public RefutationUI(CurrentPoint point)
        {
            _navUi = new ArgumentNavUI(point);
            _darken = new ColoredRectangle { Color = Color.FromNonPremultiplied(0, 0, 0, 130), Transform = new Transform2(new Size2(1600, 900)) };
            _interactBranch = new ClickUIBranch("Interact", 2);
            _clickUi = new ClickUI();
            _clickUi.Add(_navUi.Branch);
            _clickUi.Add(_interactBranch);
            _refuteButton = Buttons.CreateRefute(new Transform2(new Vector2(650, 650), new Size2(300, 95)), Refute, () => CanClickRefute);
            _cancelButton = Buttons.CreateCancel(new Transform2(new Vector2(650, 650), new Size2(300, 95)), Cancel, () => CanClickCancel);
            _interactBranch.Add(_refuteButton);
            _interactBranch.Add(_cancelButton);
            World.Subscribe(EventSubscription.Create<RefutationStarted>(x => _active = true, this));
            World.Subscribe(EventSubscription.Create<StatementChanged>(ChangeStatement, this));
        }

        private void ChangeStatement(StatementChanged obj)
        {
            _currentStatement = obj.Statement;
        }

        private void Cancel()
        {
            ResetRefuting();
        }

        private void Refute()
        {
            _isRefuting = true;
            _clickUi.Remove(_navUi.Branch);
            _isRefutingChanged = true;
        }

        public void Update(TimeSpan delta)
        {
            if (_isRefutingChanged)
                UpdateRefuting();
            
            _clickUi.Update(delta);
        }

        public void Draw(Transform2 parentTransform)
        {
            if (!_active)
                return;

            _cancelButton.Draw(parentTransform);
            _refuteButton.Draw(parentTransform);

            if (_isRefuting)
            {
                _darken.Draw(parentTransform);
                _optionButtons.ForEach(x => x.Draw(parentTransform));
            }
            else
                _navUi.Draw(parentTransform);
        }

        private void UpdateRefuting()
        {
            if (_isRefuting)
            {
                var i = 0;
                _currentStatement.Options.ForEach(x =>
                {
                    var opt = Buttons.CreateOption(x.ToString(),
                        new Transform2(new Vector2(650, 250 + (i * 50)), new Size2(300, 95)),
                        () => {
                            _currentStatement.Refute(x);
                            ResetRefuting();
                        });
                    _optionButtons.Add(opt);
                    _interactBranch.Add(opt);
                    i++;
                });
            }
            else
            {
                _optionButtons.ForEach(x => _interactBranch.Remove(x));
                _optionButtons.Clear();
            }

            _isRefutingChanged = false;
        }

        private void ResetRefuting()
        {
            _isRefuting = false;
            _clickUi.Add(_navUi.Branch);
            _isRefutingChanged = true;
        }
    }
}
