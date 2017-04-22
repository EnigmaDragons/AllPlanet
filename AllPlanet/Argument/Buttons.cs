using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public static class Buttons
    {
        public static ImageButton CreateRefute(Transform2 transform, Action refuteAction, Func<bool> visibleCondition)
        {
            return new ImageButton("UI/refutebutton-default", "UI/refutebutton-hover", "UI/refutebutton-pressed",
                transform,
                refuteAction,
                visibleCondition);
        }

        public static ImageButton CreateCancel(Transform2 transform, Action cancelAction, Func<bool> visibleCondition)
        {
            return new ImageButton("UI/cancelbutton-default", "UI/cancelbutton-hover", "UI/cancelbutton-pressed",
                transform,
                cancelAction,
                visibleCondition);
        }

        public static ImageButton CreateNext(Transform2 transform, Action nextAction, Func<bool> visibleCondition)
        {
            return new ImageButton("UI/next-button", "UI/next-button", "UI/next-button",
                transform,
                nextAction, 
                visibleCondition);
        }

        public static ImageButton CreateBack(Transform2 transform, Action backAction, Func<bool> visibleCondition)
        {
            return new ImageButton("UI/back-button", "UI/back-button", "UI/back-button",
                transform,
                backAction,
                visibleCondition);
        }

        public static TextButton CreateOption(string text, Transform2 transform, Action option)
        {
            return new TextButton(transform.ToRectangle(), option, text, Color.BlanchedAlmond, Color.BurlyWood, Color.Cyan);
        }
    }
}
