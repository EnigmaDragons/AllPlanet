using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;

namespace AllPlanet.Argument.Concrete
{
    public class ClosingArgument1
    {
        public ClosingArgument Argument { get; } = new ClosingArgument(
            new ClosingChoice(
                new ClosingOption("Address them as acedemics", 0, 
                    new PlanetResponds("Fellow academics I propose to you that I am in fact a planet.", PlanetExpression.Challenging)),
                new ClosingOption("Rally the crowd for your cause", 1, 
                    new PlanetResponds("You all know in your heart that I'm a planet, but now I shall prove it.", PlanetExpression.Proud)),
                new ClosingOption("Throw shade at your opponent", 3, 
                    new PlanetResponds("I am going to tear the opinions from this foolish person who calls himself a scientist apart!", PlanetExpression.Challenging))),
            new ClosingChoice(
                new ClosingOption("You orbit the sun which is what planet's do", -1, //todo: recraft this to something super random
                    new PlanetResponds("The one thing all planet's have in common is there ability to orbit the sun.", PlanetExpression.Challenging), 
                    new PlanetResponds("As my gravitational pull is to the sun as opposed to other planet's such as moon's then I'm a planet", PlanetExpression.Challenging)),
                new ClosingOption("You are made up of everything a planet is made up of", -1,
                    new PlanetResponds("A planet is made up of a very large amount of traits and attributes.", PlanetExpression.Thinking),
                    new PlanetResponds("Just like a car, if I was to use 6 wheels instead of 4 would it still be a car?", PlanetExpression.Challenging),
                    new PlanetResponds("Of course it would be!", PlanetExpression.Proud),
                    new PlanetResponds("I am made up of Carbon Monoxide, Carbon Dioxide, Mitrogen, all the stuff planet's are made out of.", PlanetExpression.Challenging),
                    new PlanetResponds("And I'm the shape of planet, and I orbit the sun. Therefore I am a planet.", PlanetExpression.Proud)),
                new ClosingOption("Cite the famious scientist who discovered you", 2, //todo: recraft lancasters says to be ill relvant and to put into question the legitamacy of this scientist
                    new PlanetResponds("In 1876 when I was first discovered as a planet, by the famious scientist Dr.Larcaster.", PlanetExpression.Challenging),
                    new PlanetResponds("He also had to prove I was a planet, he showed them the numerious characteristics that were planet-like,", PlanetExpression.Challenging),
                    new PlanetResponds("Until they could no longer dispute him. All you have to do is look at any of his notes to be convinced I'm a planet.", PlanetExpression.Proud))),
            new ClosingChoice(
                new ClosingOption("Bring up Dr.Emerson's questionable past with drugs", 2,
                    new PlanetResponds("Can you really trust a criminal?", PlanetExpression.Challenging),
                    new OpponentResponds("What!", OpponentExpression.Worried),
                    new PlanetResponds("Did you know Dr.Emerson, or should I say Waldo here was arrested at a young age!", PlanetExpression.Challenging),
                    new PlanetResponds("It says in the record here, Waldo was in for drug abuse. Can you really trust an drugged up mind to do proper science?", PlanetExpression.Challenging),
                    new OpponentResponds("That's ridiculous! That was ages ago and has no bearing on this debate!", OpponentExpression.Worried)),
                new ClosingOption("Question the legitimacy of a scientist who gets paid by private corporations", 3, 
                    new PlanetResponds("Are you really a scientist?", PlanetExpression.Challenging),
                    new PlanetResponds("It seems to me you only have participated in independent scientific studies.", PlanetExpression.Challenging),
                    new PlanetResponds("As such you were paid large sums of money, and conviently found results that benefitted the people you were paid by.", PlanetExpression.Challenging),
                    new PlanetResponds("You are just a hoax being paid to come and do fake science, and this community won't stand for it!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("-", OpponentExpression.Worried)),
                new ClosingOption("Emerson doesn't look like a scientist", 1, 
                    new PlanetResponds("That's a pretty nice suit your wearing", PlanetExpression.Thinking),
                    new PlanetResponds("Not very science like.", PlanetExpression.Challenging),
                    new PlanetResponds("And that well groomed beard, do you spend more time on science or grooming yourself?", PlanetExpression.Challenging),
                    new PlanetResponds("And those shoes, very bissness-y.", PlanetExpression.Thinking),
                    new PlanetResponds("You seem more like a car salesman than a scientist, trying to sell us your bullshit ideas.", PlanetExpression.Challenging))),
            new ClosingChoice(
                new ClosingOption("Respectfully tell the audience how they are smart enough to know you are a planet", -2,
                    new PlanetResponds("Now I know you are a prestigious community, the best of the best.", PlanetExpression.Proud),
                    new PlanetResponds("You guys do your research and I trust you will judge fairly that I am indeed a planet.", PlanetExpression.Proud),
                    new OpponentResponds("Oh, they will judge fairly all right!", OpponentExpression.Proud)),
                new ClosingOption("Unite the audience against the common enemy", 2,
                    new PlanetResponds("Do you see Emerson's grin, he is thinking to himself that he is smarter than all of the audience.", PlanetExpression.Challenging),
                    new PlanetResponds("That he can pull one over this entire community.", PlanetExpression.Challenging),
                    new PlanetResponds("First it's claiming planet's arn't real, then it's going to be claiming you guys arn't real scientists.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("-", OpponentExpression.Worried)),
                new ClosingOption("Make the audience out to be heroes", 0, 
                    new PlanetResponds("Today is a momentious occasion!", PlanetExpression.Proud),
                    new PlanetResponds("The day all of you members of the auidence saved a planet from utter destruction.", PlanetExpression.Proud),
                    new PlanetResponds("You will be remembered, people will thank you for what you have done here today.", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new ClosingChoice(
                new ClosingOption("", 0),
                new ClosingOption("", 0),
                new ClosingOption("", 0)));
    }
}
