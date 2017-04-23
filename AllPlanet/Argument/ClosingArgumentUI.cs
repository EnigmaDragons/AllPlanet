using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System.Collections.Generic;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.EventSystem;
using Microsoft.Xna.Framework;

namespace AllPlanet.Argument
{
    public class ClosingArgumentUI : IVisualAutomaton
    {
        private readonly CurrentClosingArgument _currentArgument;
        private readonly List<TextButton> _optionButtons = new List<TextButton>();

        private bool _active = false;

        public ClickUIBranch Branch { get; } = new ClickUIBranch("Closing", (int)ClickBranchPriority.Closing);

        public ClosingArgumentUI(CurrentClosingArgument argument)
        {
            _currentArgument = argument;
            World.Subscribe(EventSubscription.Create<ModeChanged>(ChangeMode, this));
        }

        private void ChangeMode(ModeChanged obj)
        {
            _active = obj.Mode == Mode.ClosingArgument;
            if (_active)
            {
                var i = 0;
                _currentArgument.Get().CurrentChoice.OptionDescriptions.ForEach(x =>
                {
                    var opt = Buttons.CreateOption(x.ToString(),
                        new Transform2(new Vector2(650, 250 + (i * 90)), new Size2(300, 80)),
                        () => { _currentArgument.Get().Choose(x); ChangeOptions(); });
                    _optionButtons.Add(opt);
                    Branch.Add(opt);
                    i++;
                });
            }
            else
            {
                _optionButtons.ForEach(x => Branch.Remove(x));
                _optionButtons.Clear();
            }
        }

        public void ChangeOptions()
        {
            _optionButtons.ForEach(x => Branch.Remove(x));
            _optionButtons.Clear();
            var i = 0;
            _currentArgument.Get().CurrentChoice.OptionDescriptions.ForEach(x =>
            {
                var opt = Buttons.CreateOption(x.ToString(),
                    new Transform2(new Vector2(650, 250 + (i * 90)), new Size2(300, 80)),
                    () => { _currentArgument.Get().Choose(x); ChangeOptions(); });
                _optionButtons.Add(opt);
                Branch.Add(opt);
                i++;
            });
        }

        public void Draw(Transform2 parentTransform)
        {
            World.Darken();
            _optionButtons.ForEach(x => x.Draw(parentTransform));
        }

        public void Update(TimeSpan delta)
        {
        }
    }
}