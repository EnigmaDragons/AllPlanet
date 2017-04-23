using System.Collections.Generic;
using AllPlanet.Argument;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Audio;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.Inputs;

namespace AllPlanet.Player
{
    public class ArgumentLearnedUI : IVisual
    {
        private readonly List<string> _argumentsLearned = new List<string>();
        private readonly string _backdrop = "UI/argument-learned";
        private readonly ImageButton _confirm;
        private readonly Label _title;
        private readonly Label _name;
        private readonly Label _desc;

        private bool Dismissed { get; set; }

        public ClickUIBranch Branch { get; }

        public ArgumentLearnedUI()
        {
            Branch = new ClickUIBranch("Learn", (int)ClickBranchPriority.Learn);
            _title = new Label { BackgroundColor = Color.Transparent, Transform = new Transform2(new Vector2(250, 200), new Size2(1100, 100)), Text = "New Argument Learned!" };
            _name = new Label { BackgroundColor = Color.Transparent, Transform = new Transform2(new Vector2(250, 200 + 75), new Size2(1100, 100)), Text = "File a bug ticket if you see this." };
            _desc = new Label { BackgroundColor = Color.Transparent, Transform = new Transform2(new Vector2(250, 200 + 150), new Size2(1100, 100)) };
            _confirm = new ImageButton("UI/checkmark", "UI/checkmark", "UI/checkmark",
                new Transform2(new Vector2(1300, 400), new Size2(64, 64)), Dismiss, () => !Dismissed);
            Input.On(Control.X, Dismiss);
            Branch.Add(_confirm);
            Dismissed = true;
            World.Subscribe(EventSubscription.Create<ArgumentLearned>(LearnArgument, this));
        }

        private void Dismiss()
        {
            if (Dismissed) return;
            Dismissed = true;
            World.Publish(new AdvanceArgument());
        }

        private void LearnArgument(ArgumentLearned obj)
        {
            if (_argumentsLearned.Contains(obj.Name))
            {
                World.Publish(new AdvanceArgument());
                return;
            }
            _argumentsLearned.Add(obj.Name);
            _name.Text = obj.Name;
            _desc.Text = obj.Desc;
            Dismissed = false;
            Audio.PlaySound("argument-learned");
        }

        public void Draw(Transform2 parentTransform)
        {
            if (Dismissed) return;

            World.Darken();
            UI.DrawCenteredWithOffset(_backdrop, new Vector2(1200, 300), new Vector2(0, -110));
            _title.Draw(parentTransform);
            _name.Draw(parentTransform);
            _desc.Draw(parentTransform);
            _confirm.Draw(parentTransform);
        }
    }
}
