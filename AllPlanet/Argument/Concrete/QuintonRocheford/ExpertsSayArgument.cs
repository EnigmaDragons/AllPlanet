using System.Collections.Generic;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete.Opponent2
{
    public static class ExpertsSayArgument
    {
        public static ArgumentPoint Argument { get; } = new ArgumentPoint(new List<object>
            {
                new OpponentResponds("You know what's kinda funny about arguing against the experts?", OpponentExpression.Challenging),
                new PlanetResponds("*What does he have now?*", PlanetExpression.Thinking),
                new OpponentResponds("Experts defined what a planet is.", OpponentExpression.Challenging),
                new OpponentResponds("As such they are the ones who judge what belongs in the category of planet.", OpponentExpression.Challenging),
                new OpponentResponds("All the experts have judged that you are not a planet!", OpponentExpression.Proud),
            },
            "experts say",
            new Statement("Experts defined what a planet is.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.AppealToAuthority, "too far from sun", 9,
                    new PlanetResponds("One day an expert will come along.", PlanetExpression.Challenging),
                    new PlanetResponds("And he will say that you are not a scientist.", PlanetExpression.Challenging),
                    new PlanetResponds("Will that make you no longer a scientist?", PlanetExpression.Challenging),
                    new OpponentResponds("That would never happen.", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.AppealToEmotion, "too far from sun", 9,
                    new PlanetResponds("For thousands of years I've been a planet.", PlanetExpression.Challenging),
                    new PlanetResponds("ve always been called a planet.", PlanetExpression.Challenging),
                    new PlanetResponds("And now you experts come along and say I'm not. Now I'm just a lonely clump of dirt in the sky.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Sympathy),
                    new OpponentResponds("You have been mistaken for thousands of years.", OpponentExpression.Bored)),
                new RefuteOption(ArgumentType.AgreeAndAmplify, "too far from sun", 9,
                    new PlanetResponds("Of course! Experts are the wizards of reality!", PlanetExpression.Challenging),
                    new PlanetResponds("An experts says to one planet; \"You are a planet.\"", PlanetExpression.Challenging),
                    new PlanetResponds("And to another; \"You are not a planet.\"", PlanetExpression.Challenging),
                    new PlanetResponds("All reality begins and ends with what experts say.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new Statement("As such they are the ones who judge what belongs in the category of planet.", OpponentExpression.Challenging,
                new RefuteOption(ArgumentType.Discredit, "too far from sun", 9,
                    new PlanetResponds("Don't contradict yourself, please!", PlanetExpression.Challenging),
                    new PlanetResponds("Experts have already defined what a planet is.", PlanetExpression.Challenging),
                    new PlanetResponds("You can't now redefine what qualifies as a planet.", PlanetExpression.Challenging),
                    new OpponentResponds("I'm not redefining, I'm clarifying.", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo)),
                new RefuteOption(ArgumentType.AdHominem, "too far from sun", 9,
                    new PlanetResponds("As such THEY are the ones who judge.", PlanetExpression.Challenging),
                    new PlanetResponds("You yourself didn't put yourself in the category of expert.", PlanetExpression.Challenging),
                    new PlanetResponds("I don't see any reason why the audience here should either!", PlanetExpression.Challenging),
                    new OpponentResponds("I am an accredited scientist for years, everyone has heard of me. Of course I'm an expert.", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Reframe, "too far from sun", 9,
                    new PlanetResponds("That's wonderful!", PlanetExpression.Challenging),
                    new PlanetResponds("I am an expert, I have a Ph.D in Astrology!", PlanetExpression.Challenging),
                    new PlanetResponds("And yes, I am a planet.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer),
                    new OpponentResponds("This crowd will eat up anything!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo))),
            new Statement("All the experts have judged that you are not a planet!", OpponentExpression.Proud,
                new RefuteOption(ArgumentType.FakeStatistic, "too far from sun", 9,
                    new PlanetResponds("Actually, only 38% of the scientific community says that I am not a planet.", PlanetExpression.Challenging),
                    new OpponentResponds("That's because the other 62%, know astornomy isn't their field", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.AppealToAuthority, "too far from sun", 9,
                    new PlanetResponds("For millenia, scientists have unanimously agreed that I am a planet.", PlanetExpression.Challenging),
                    new PlanetResponds("Do you presume to disagree with all of the experts that came before you?", PlanetExpression.Challenging),
                    new OpponentResponds("The people that came before you, simply didn't have the technology to know the facts.", OpponentExpression.Bored),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new RefuteOption(ArgumentType.Reframe, "too far from sun", 9,
                    new PlanetResponds("One day when experts come along and declare you are not an expert;", PlanetExpression.Challenging),
                    new PlanetResponds("Will that make you no longer an expert?", PlanetExpression.Challenging),
                    new OpponentResponds("Not if I declare them not to be experts first! HAHAHAHA!", OpponentExpression.Proud),
                    new CrowdResponds(CrowdExpression.Boo))));
    }
}
