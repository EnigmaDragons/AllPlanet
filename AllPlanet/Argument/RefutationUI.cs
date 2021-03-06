﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Text;
using AllPlanet.Player;

namespace AllPlanet.Argument
{
    public sealed class RefutationUI : IVisualAutomaton
    {
        private readonly ArgumentNavUI _navUi;
        private readonly ClickUIBranch _interactBranch;
        private readonly ImageButton _quoteButton;
        private readonly TextButton _discreditButton;
        private readonly ImageButton _refuteButton;
        private readonly ImageButton _cancelButton;
        private readonly List<ImageTextButton> _optionButtons = new List<ImageTextButton>();
        private readonly ColoredRectangle _choosingOptionButtonBorder = new ColoredRectangle()
            { Transform = new Transform2(new Size2(306, 86)), Color = Color.Orange };
        private Transform2 _currentlyHighlightedOption = new Transform2(new Vector2(647, 2000));
        private float _currentlyHighlightedOptionAsFloat {
            get { return _currentlyHighlightedOption.Location.Y == 2000 ? -1 : (_currentlyHighlightedOption.Location.Y - 247) / 90; }
            set { _currentlyHighlightedOption.Location = value == -1 ? new Vector2(647, 2000) : new Vector2(647, 247 + 90 * value); } }

        private Statement _currentStatement;
        private Statement _quotedStatement;
        
        private bool _isDiscreditUnlocked = false; 
        private bool _active;
        private bool _isQuoting = false;
        private bool _isRefuting;
        private bool _isRefutingChanged;
        private bool CanClickRefute => _active && !_isRefuting && !_isQuoting;
        private bool CanClickCancel => _active && (_isRefuting || _isQuoting);
        private bool CanClickQuote => CanClickRefute && _isDiscreditUnlocked;

        public ClickUIBranch Branch { get; }

        public RefutationUI(CurrentPoint point)
        {
            _navUi = new ArgumentNavUI(point);
            _refuteButton = Buttons.CreateRefute(new Transform2(new Vector2(640, 720), new Size2(320, 100)), Refute, () => CanClickRefute);
            ControlHandler.BindOnPress(5, Control.A, () => { if(_active) Refute(); return _active; });
            _cancelButton = Buttons.CreateCancel(new Transform2(new Vector2(640, 720), new Size2(320, 100)), Cancel, () => CanClickCancel);
            ControlHandler.BindOnPress(5, Control.B, () => { if(_active) Cancel(); return _active; });
            ControlHandler.BindOnPress(5, Control.A, () => { if (_isRefuting) { RefuteCurrentlyHighlightedOption(); return true;  } return false; });
            ControlHandler.BindOnPress(5, Control.Up, () => { if(_isRefuting) ChangeHighlightOptionUp(); return _active; });
            ControlHandler.BindOnPress(5, Control.Down, () => { if(_isRefuting) ChangeHighlightOptionDown(); return _active; });
            _quoteButton = Buttons.CreateQuoteButton(new Transform2(new Vector2(640, 600), new Size2(320, 100)), Quote, () => CanClickQuote);
            _discreditButton = new TextButton(new Transform2(new Vector2(640, 600), new Size2(320, 100)).ToRectangle(), Discredit, "Discredit",
                Color.Red, Color.Orange, Color.Yellow, () => _isQuoting);
            _interactBranch = new ClickUIBranch("Interact", (int)ClickBranchPriority.Interact);
            _quoteButton.IsEnabled = false;
            _interactBranch.Add(_refuteButton);
            _interactBranch.Add(_quoteButton);
            Branch = new ClickUIBranch("RefutationUI", (int)ClickBranchPriority.Refute);
            Branch.Add(_navUi.Branch);
            Branch.Add(_interactBranch);
            World.Subscribe(EventSubscription.Create<ModeChanged>(ChangeMode, this));
            World.Subscribe(EventSubscription.Create<StatementChanged>(ChangeStatement, this));
            //World.Subscribe(EventSubscription.Create<ArgumentLearned>(
                //(a) => { if (a.Name == "Discredit") { _isDiscreditUnlocked = true; _quoteButton.IsEnabled = true; } }, this));
        }

        private void Discredit()
        {
            _quotedStatement.Discredit(_currentStatement.Message);
            ResetRefuting();
        }

        private void RefuteCurrentlyHighlightedOption()
        {
            if (_currentlyHighlightedOptionAsFloat != -1)
                _optionButtons[(int)_currentlyHighlightedOptionAsFloat].OnReleased();
        }

        private void ChangeHighlightOptionUp()
        {
            if (_currentlyHighlightedOptionAsFloat == -1)
                _currentlyHighlightedOptionAsFloat = 0;
            else if(_currentlyHighlightedOptionAsFloat > 0)
                _currentlyHighlightedOptionAsFloat--;
        }

        private void ChangeHighlightOptionDown()
        {
            if (_currentlyHighlightedOptionAsFloat == -1)
            {
                if(_optionButtons.Count > 1)
                    _currentlyHighlightedOptionAsFloat = 1;
                else
                    _currentlyHighlightedOptionAsFloat = 0;
            }
            else if (_currentlyHighlightedOptionAsFloat + 1 < _optionButtons.Count)
                _currentlyHighlightedOptionAsFloat++;
        }

        private void ChangeMode(ModeChanged obj)
        {
            if(obj.Mode == Mode.Refutation)
            {
                Branch.Add(_interactBranch);
                _active = true;
            }
            else
            {
                Branch.Remove(_interactBranch);
                _active = false;
            }
        }

        private void ChangeStatement(StatementChanged obj)
        {
            _currentStatement = obj.Statement;
        }

        private void Cancel()
        {
            if (!CanClickCancel) return;
            ResetRefuting();
        }

        private void Quote()
        {
            if (!CanClickQuote) return;
            _isQuoting = true;
            _interactBranch.Add(_discreditButton);
            _interactBranch.Remove(_refuteButton);
            _interactBranch.Remove(_quoteButton);
            _interactBranch.Add(_cancelButton);
            _quotedStatement = _currentStatement;
        }

        private void Refute()
        {
            if (!CanClickRefute) return;
            _isRefuting = true;
            _interactBranch.Remove(_refuteButton);
            _interactBranch.Remove(_quoteButton);
            Branch.Remove(_navUi.Branch);
            _interactBranch.Add(_cancelButton);
            _isRefutingChanged = true;
        }

        public void Update(TimeSpan delta)
        {
            if (_isRefutingChanged)
                UpdateRefuting();
        }

        public void Draw(Transform2 parentTransform)
        {
            if (!_active)
                return;

            if (_isRefuting)
            {
                World.Darken();
                _choosingOptionButtonBorder.Draw(parentTransform + _currentlyHighlightedOption);
                _optionButtons.ForEach(x => x.Draw(parentTransform));
            }
            else
                _navUi.Draw(parentTransform);

            _discreditButton.Draw(parentTransform);
            _cancelButton.Draw(parentTransform);
            _refuteButton.Draw(parentTransform);
            _quoteButton.Draw(parentTransform);
        }

        private void UpdateRefuting()
        {
            if (_isRefuting)
            {
                var i = 0;
                if (_isQuoting)
                {
                    var quoteOpt = Buttons.CreateOption("Discredit", new Transform2(new Vector2(650, 250 + (i++ * 90)), new Size2(300, 80)),
                        () =>
                        {
                            _isQuoting = false;
                            _quotedStatement.Discredit(_currentStatement.Message);
                            ResetRefuting();
                        });
                    _optionButtons.Add(quoteOpt);
                    _interactBranch.Add(quoteOpt);
                }
                _currentStatement.Options.ForEach(x =>
                {
                    var opt = Buttons.CreateOption(x.WithSpaces(),
                        new Transform2(new Vector2(650, 250 + (i++ * 90)), new Size2(300, 80)),
                        () =>
                        {
                            _isQuoting = false;
                            _currentStatement.Refute(x);
                            ResetRefuting();
                        });
                    _optionButtons.Add(opt);
                    _interactBranch.Add(opt);
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
            _currentlyHighlightedOptionAsFloat = -1;
            _isQuoting = false;
            _isRefuting = false;
            _interactBranch.Remove(_discreditButton);
            _interactBranch.Add(_refuteButton);
            _interactBranch.Add(_quoteButton);
            Branch.Add(_navUi.Branch);
            _interactBranch.Remove(_cancelButton);
            _isRefutingChanged = true;
        }
    }
}
