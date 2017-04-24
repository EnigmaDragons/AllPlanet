using System;
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
        private readonly TextButton _quoteButton;
        private readonly ImageButton _refuteButton;
        private readonly ImageButton _cancelButton;
        private readonly List<ImageTextButton> _optionButtons = new List<ImageTextButton>();

        private Statement _currentStatement;
        private Statement _quotedStatement;
        
        private bool _isDiscreditUnlocked = false; 
        private bool _active;
        private bool _isQuoting = false;
        private bool _isRefuting;
        private bool _isRefutingChanged;
        private bool CanClickRefute => _active && !_isRefuting;
        private bool CanClickCancel => _active && _isRefuting;
        private bool CanClickQuote => CanClickRefute && _isDiscreditUnlocked;

        public ClickUIBranch Branch { get; }

        public RefutationUI(CurrentPoint point)
        {
            _navUi = new ArgumentNavUI(point);
            _refuteButton = Buttons.CreateRefute(new Transform2(new Vector2(650, 650), new Size2(300, 95)), Refute, () => CanClickRefute);
            Input.On(Control.A, Refute);
            _cancelButton = Buttons.CreateCancel(new Transform2(new Vector2(650, 650), new Size2(300, 95)), Cancel, () => CanClickCancel);
            Input.On(Control.B, Cancel);
            _quoteButton = new TextButton(new Rectangle(new Point(650, 750), new Point(300, 95)), Quote, "Quote",
                Color.BlanchedAlmond, Color.BurlyWood, Color.Cyan, () => CanClickQuote);
            _interactBranch = new ClickUIBranch("Interact", (int)ClickBranchPriority.Interact);
            _quoteButton.IsEnabled = false;
            _interactBranch.Add(_refuteButton);
            _interactBranch.Add(_quoteButton);
            Branch = new ClickUIBranch("RefutationUI", (int)ClickBranchPriority.Refute);
            Branch.Add(_navUi.Branch);
            Branch.Add(_interactBranch);
            World.Subscribe(EventSubscription.Create<ModeChanged>(ChangeMode, this));
            World.Subscribe(EventSubscription.Create<StatementChanged>(ChangeStatement, this));
            World.Subscribe(EventSubscription.Create<ArgumentLearned>(
                (a) => { if (a.Name == "Discredit") { _isDiscreditUnlocked = true; _quoteButton.IsEnabled = true; } }, this));
        }

        private void ChangeMode(ModeChanged obj)
        {
            _active = obj.Mode == Mode.Refutation;
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
                _optionButtons.ForEach(x => x.Draw(parentTransform));
            }
            else
                _navUi.Draw(parentTransform);

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
            _isQuoting = false;
            _isRefuting = false;
            _interactBranch.Add(_refuteButton);
            _interactBranch.Add(_quoteButton);
            Branch.Add(_navUi.Branch);
            _interactBranch.Remove(_cancelButton);
            _isRefutingChanged = true;
        }
    }
}
