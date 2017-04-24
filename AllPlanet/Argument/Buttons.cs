using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Argument
{
    public static class Buttons
    {
        public static ImageTextButton CreateStart(Transform2 transform, Action action)
        {
            return new ImageTextButton("Start", "UI/startbutton-default", "UI/startbutton-hover", "UI/startbutton-pressed", transform, action);
        }

        public static ImageTextButton CreateReplayIntro(Transform2 transform, Action action)
        {
            return new ImageTextButton("Replay Intro", "UI/startbutton-default", "UI/startbutton-hover", "UI/startbutton-pressed", transform, action);
        }

        public static ImageTextButton CreateContinue(Transform2 transform, Action action)
        {
            return new ImageTextButton("Continue", "UI/startbutton-default", "UI/startbutton-hover", "UI/startbutton-pressed", transform, action);
        }

        public static ImageTextButton CreateMainMenu(Transform2 transform, Action action)
        {
            return new ImageTextButton("Main Menu", "UI/startbutton-default", "UI/startbutton-hover", "UI/startbutton-pressed", transform, action);
        }

        public static ImageTextButton CreateTextButton(string text, Transform2 transform, Action action)
        {
            return new ImageTextButton(text, "UI/plainbutton-default", "UI/plainbutton-hover", "UI/plainbutton-pressed", transform, action);
        }

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
            return new ImageButton("UI/nextbutton-pressed", "UI/nextbutton-hover", "UI/nextbutton-default",
                transform,
                nextAction, 
                visibleCondition);
        }

        public static ImageButton CreateBack(Transform2 transform, Action backAction, Func<bool> visibleCondition)
        {
            return new ImageButton("UI/backbutton-pressed", "UI/backbutton-hover", "UI/backbutton-default",
                transform,
                backAction,
                visibleCondition);
        }

        public static ImageTextButton CreateOption(string text, Transform2 transform, Action option)
        {
            return new ImageTextButton(text, "UI/plainbutton-default", "UI/plainbutton-hover", "UI/plainbutton-pressed", transform, option);
        }

        public static ImageButton CreateQuoteButton(Transform2 transform, Action action, Func<bool> visibleCondition)
        {
            return new ImageButton("UI/quotebutton-default", "UI/quotebutton-hover", "UI/quotebutton-pressed",
                transform,
                action,
                visibleCondition);
        }

        public static ImageTextButton CreateClosingArgument(string text, Transform2 transform, Action option)
        {
            return new ImageTextButton(text, "UI/closingarg-button-default", "UI/closingarg-button-hover",
                "UI/closingarg-button-pressed", transform, option);
        }
    }
}
