using System.Collections.Generic;
using AllPlanet.Argument;
using MonoDragons.Core.Common;

namespace AllPlanet.Player
{
    public static class ArgumentLearnedFactory
    {
        private static Dictionary<ArgumentType, List<string>> _argumentLines = new Dictionary<ArgumentType, List<string>>
        {
            {
                ArgumentType.FakeStatistic, new List<string>
                {
                    "76% of all winning arguments use fake statistics",
                    "25% of fake statistics are right",
                    "1 out of 100 people have learned this argument",
                }
            },
            {
                ArgumentType.AgreeAndAmplify, new List<string>
                {
                    "This isn't just a good argument, this is the greatest argument! It should be used everywhere.",
                    "You bet you learned this argument, you know it so well you could use it in your sleep, or even when you're in the grave.",
                }
            },
            {
                ArgumentType.AppealToEmotion, new List<string>
                {
                    "You have to try this argument, just think about all the sad people who don't know how to use this argument yet.",
                }
            },
            {
                ArgumentType.Reframe, new List<string>
                {
                    "This isn't an arguing technique, it's just a way to agree.",
                    "You didn't just learn this, you're just discovering what you already knew.",
                }
            },
            {
                ArgumentType.Refuse, new List<string>
                {
                    "Person 1: This is a great argument. Person 2: No it isn't, it's terrible!",
                    "You're wrong, you didn't just learn this argument!",
                }
            },
            {
                ArgumentType.StrawMan, new List<string>
                {
                    "Th"
                }
            }
        };

        public static ArgumentLearned Create(ArgumentType type)
        {
            return new ArgumentLearned(type, _argumentLines[type].Random());
        }
    }
}
