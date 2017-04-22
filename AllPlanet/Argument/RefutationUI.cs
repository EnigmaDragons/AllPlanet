using System;
using System.Collections.Generic;
using AllPlanet.Debate;
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
        private readonly SpeechUI _speech;
        private readonly List<TextButton> _optionButtons = new List<TextButton>();

        private ArgumentPoint _currentPoint;
        private Statement _currentStatement;
        private bool _currentStatementChanged;

        private bool _isRefuting;
        private bool _isRefutingChanged;

        public RefutationUI(Segue segue)
        {
            _navUi = new ArgumentNavUI(segue);
            _darken = new ColoredRectangle { Color = Color.FromNonPremultiplied(0, 0, 0, 130), Transform = new Transform2(new Size2(1600, 900)) };
            _speech = new SpeechUI();
            _interactBranch = new ClickUIBranch("Interact", 2);
            _clickUi = new ClickUI();
            _clickUi.Add(_navUi.Branch);
            _clickUi.Add(_interactBranch);
            _refuteButton = Buttons.CreateRefute(new Transform2(new Vector2(650, 650), new Size2(300, 95)), Refute);
            _cancelButton = Buttons.CreateCancel(new Transform2(new Vector2(650, 650), new Size2(300, 95)), Cancel);
            _interactBranch.Add(_refuteButton);
            UpdatePoint(segue);
            World.Subscribe(EventSubscription.Create<Segue>(UpdatePoint, this));
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
            UpdateCurrentStatement();
            if (_isRefutingChanged)
                UpdateRefuting();
            
            _speech.Update(delta);
            _clickUi.Update(delta);
        }

        private void UpdateCurrentStatement()
        {
            var currentStatementChanged = _currentStatement != _currentPoint.CurrentStatement;
            _currentStatement = _currentPoint.CurrentStatement;
            if (currentStatementChanged)
                _speech.Show(_currentStatement.Message, Side.Right);
        }

        public void Draw(Transform2 parentTransform)
        {
            _speech.Draw(parentTransform);
            if (_isRefuting)
            {
                _darken.Draw(parentTransform);
                _cancelButton.Draw(parentTransform);
                _optionButtons.ForEach(x => x.Draw(parentTransform));
            }
            else
            {
                _navUi.Draw(parentTransform);
                _refuteButton.Draw(parentTransform);
            }
        }

        private void UpdatePoint(Segue segue)
        {
            _currentPoint = ArgumentPointFactory.Create(segue.ArgumentName);
        }

        private void UpdateRefuting()
        {
            // TODO: Refactor this into ClickableUIElements
            if (_isRefuting)
                _interactBranch.Add(_cancelButton);
            else
                _interactBranch.Remove(_cancelButton);
            if (!_isRefuting)
                _interactBranch.Add(_refuteButton);
            else
                _interactBranch.Remove(_refuteButton);
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
