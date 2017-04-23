using System;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using System.Collections.Generic;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.EventSystem;
using Microsoft.Xna.Framework;

namespace AllPlanet.Argument
{
    public class ClosingArgumentUI : IVisual
    {
        private readonly CurrentClosingArgument _currentArgument;
        private readonly List<ImageTextButton> _optionButtons = new List<ImageTextButton>();

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
                        () => { _currentArgument.Get().Choose(x); UpdateOptions(); });
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
    }
}