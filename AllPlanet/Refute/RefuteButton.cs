using System;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Refute
{
    public static class RefuteButton
    {
        public static ImageButton Create(Transform2 transform, Action refuteAction)
        {
            return new ImageButton("UI/refutebutton-default", "UI/refutebutton-hover", "UI/refutebutton-pressed",
                transform,
                refuteAction);
        }
    }
}
