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
                    "At least 23% of fake statistics are right. Or more.",
                    "1 out of 100 people have learned this argument",
                    "94% of academic orators utilize statistics, because statistics are convincing!"
                }
            },
            {
                ArgumentType.AgreeAndAmplify, new List<string>
                {
                    "This isn't just a good argument, this is the greatest argument! It should be used everywhere.",
                    "You now know this argument so well you could use it in your sleep -- or even when you're in the grave!",
                    "All of the best debaters agree and amplify. All of them!",
                    "You will win and win and win if you use this technique! You will get sick of winning so much."
                }
            },
            {
                ArgumentType.AppealToEmotion, new List<string>
                {
                    "You have to try this argument! Just think about all the sad people who don't know how to use this argument yet.",
                    "Imagine how good it would feel to argue like a boss by tugging at peoples heartstring!",
                    "You will feel terrible if you don't use every tool at your disposal.",
                    "Your audience would be crushed if they left the debate thinking you aren't a planet."
                }
            },
            {
                ArgumentType.Reframe, new List<string>
                {
                    "This isn't an arguing technique, it's just a way to show how your opponent already agrees with you.",
                    "You didn't just learn this, you're just remembering an argument technique you already knew.",
                    "The real question is, would my opponent be arguing so hard if he didn't know he was wrong?",
                    "Can we wrap this up? I could for go a banana split right now.",
                }
            },
            {
                ArgumentType.Refuse, new List<string>
                {
                    "Person 1: This is a great argument. Person 2: No it isn't, it's terrible!",
                    "You're wrong, you didn't just learn this argument!",
                    "I'm not arguing. You're arguing.",
                    "No it isnt! It just isn't! Is not!",
                }
            },
            {
                ArgumentType.Illegitimize, new List<string>
                {
                    "Need help with these lol"
                }
            },
            {
                ArgumentType.Discredit, new List<string>
                {
                    "There was a contradiction in that argument somewhere.",
                    "This next statement is true. The previous statement is false.",
                    "The things my opponent says aren't just wrong. They are misguided, too!",
                    "Being a planet doesn't make you an expert at logic, or public speaking.",
                }
            },
            {
                ArgumentType.AdHominem, new List<string>
                {
                    "Your argument's wrong because you have sold drugs to kids!",
                }
            },
            {
                ArgumentType.AppealToAuthority, new List<string>
                {
                    "This argument is good the Socrates used it!",
                }
            },
        };

        public static ArgumentLearned Create(ArgumentType type)
        {
            return new ArgumentLearned(type, _argumentLines[type].Random());
        }
    }
}
