﻿using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Transitions;

namespace AllPlanet.Closing.Concrete
{
    public static class ClosingArgument1
    {
        public static ClosingArgument Argument { get; } = new ClosingArgument("emerson closing", TransitionFactory.Create("to second argument"), TransitionFactory.Create("lost to emerson"), 
            new ClosingChoice(new object[0],
                new ClosingOption("Address them as academics", 0, 
                    new PlanetResponds("Fellow academics, I propose to you that I am, in fact, a planet.", PlanetExpression.Challenging)),
                new ClosingOption("Rally the crowd for your cause", +1, 
                    new PlanetResponds("You all know in your heart that I'm a planet, but now I shall prove it.", PlanetExpression.Proud)),
                new ClosingOption("Throw shade at your opponent", +3, 
                    new PlanetResponds("I am going to rip apart the opinions of this foolish man, who calls himself a scientist, apart!", PlanetExpression.Challenging))),
            new ClosingChoice(new object[0],
                new ClosingOption("List random facts, which mean you are a planet.", -1,
                    new PlanetResponds("On the surface of some planets, grows a rare fungus which, when cooked in a dish, can make someone not hungry for a week.", PlanetExpression.Thinking),
                    new PlanetResponds("This rare fungus is made of the element Xanarin, which, as you know, has many other useful applications.", PlanetExpression.Thinking),
                    new PlanetResponds("Do you know what else has Xanarin? That's right! My core.", PlanetExpression.Challenging),
                    new PlanetResponds("I think this conclusively proves that I am indeed a planet.", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.NoComment)),
                new ClosingOption("planet made from", true, "You are made up of everything a planet is made up of", +1,
                    new PlanetResponds("A planet possesses a very large number of traits and attributes.", PlanetExpression.Thinking),
                    new PlanetResponds("Consider a car. If a car had 6 wheels instead of 4, would it still be a car?", PlanetExpression.Challenging),
                    new PlanetResponds("Of course it would be!", PlanetExpression.Proud),
                    new PlanetResponds("I am made up of Carbon Monoxide, Carbon Dioxide, Nitrogen -- all the stuff planets are made out of.", PlanetExpression.Challenging),
                    new PlanetResponds("I am in the shape of a planet, and I orbit the sun. Therefore I am a planet.", PlanetExpression.Proud)),
                new ClosingOption("planet made from 2", false, "You are made up of everything a planet is made up of", +2,
                    new PlanetResponds("A planet possesses a very large number of traits and attributes.", PlanetExpression.Thinking),
                    new PlanetResponds("Consider a car. If a car had 6 wheels instead of 4, would it still be a car?", PlanetExpression.Challenging),
                    new PlanetResponds("Of course it would be!", PlanetExpression.Proud),
                    new PlanetResponds("I am made up of Carbon Monoxide, Carbon Dioxide, Nitrogen, and even 199 Rexium -- all the stuff planets are made out of.", PlanetExpression.Proud),
                    new PlanetResponds("I am in the shape of a planet, and I orbit the sun. Therefore I am a planet.", PlanetExpression.Proud)),
                new ClosingOption("Cite the famious scientist who discovered you", +2,
                    new PlanetResponds("In 1876, when I was first discovered as a planet, by the famous scientist Dr. Larcaster...", PlanetExpression.Challenging),
                    new PlanetResponds("He also proved that mushrooms can grow on trees, and that parrots can be trained to sing the national anthem.", PlanetExpression.Challenging),
                    new PlanetResponds("There is no way, after his many great achievements, that his findings can be questioned.", PlanetExpression.Proud))),
            new ClosingChoice(new object[] { new PlanetResponds("In regards to Dr. Emerson", PlanetExpression.Challenging) },
                new ClosingOption("Bring up Dr. Emerson's questionable past with drugs", +2,
                    new PlanetResponds("Can you really trust a criminal?", PlanetExpression.Challenging),
                    new OpponentResponds("What!?!", OpponentExpression.Worried),
                    new PlanetResponds("Did you know that Dr. Emerson, or should I say Waldo here, was arrested at a young age?", PlanetExpression.Challenging),
                    new PlanetResponds("It says in the record here that Waldo was in for drug abuse.", PlanetExpression.Challenging),
                    new PlanetResponds("Can you really trust a drugged up mind to do proper science?", PlanetExpression.Challenging),
                    new OpponentResponds("That's ridiculous! That was ages ago and has no bearing on this debate!", OpponentExpression.Worried)),
                new ClosingOption("Question the legitimacy of a scientist who gets paid by private corporations", +3, 
                    new PlanetResponds("Are you really a scientist?", PlanetExpression.Challenging),
                    new PlanetResponds("It seems to me you only have participated in independent scientific studies.", PlanetExpression.Challenging),
                    new PlanetResponds("As such, you were paid large sums of money, and conveniently found results that benefitted the people paying you.", PlanetExpression.Challenging),
                    new PlanetResponds("You are just a hoax being paid to come and do fake science. This community won't stand for it!", PlanetExpression.Challenging),
                    new OpponentResponds("-", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo)),
                new ClosingOption("Emerson doesn't look like a scientist", +1, 
                    new PlanetResponds("That's a pretty nice suit your wearing", PlanetExpression.Thinking),
                    new PlanetResponds("...not very science-like.", PlanetExpression.Challenging),
                    new PlanetResponds("And that well groomed beard, do you spend more time on science or grooming yourself?", PlanetExpression.Challenging),
                    new PlanetResponds("And those shoes... very businessy.", PlanetExpression.Thinking),
                    new PlanetResponds("You seem more like a car salesman than a scientist -- trying to sell us your bullshit ideas.", PlanetExpression.Challenging))),
            new ClosingChoice(new object[0],
                new ClosingOption("Appeal to your audience's intellect", -2,
                    new PlanetResponds("Ladies and gentleman, I know you are a prestigious community, the best of the best.", PlanetExpression.Proud),
                    new PlanetResponds("You do your research and I trust you will judge fairly that I am indeed a planet.", PlanetExpression.Proud),
                    new OpponentResponds("Oh, they will judge fairly all right!", OpponentExpression.Proud)),
                new ClosingOption("unite", true, "Unite the audience against the common enemy", +2,
                    new PlanetResponds("Do you see Emerson's grin? He is thinking to himself that he is smarter than all of you.", PlanetExpression.Challenging),
                    new PlanetResponds("He thinks that he can pull one over this entire community.", PlanetExpression.Challenging),
                    new PlanetResponds("First he is claiming planets aren't real.", PlanetExpression.Challenging),
                    new PlanetResponds("Next he's going to be claiming that you aren't scientifically literate!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("-", OpponentExpression.Worried)),
                new ClosingOption("unite 2", false, "Unite the audience against the common enemy", +3,
                    new PlanetResponds("Do you see Emerson's grin? He is thinking to himself that he is smarter than all of you.", PlanetExpression.Challenging),
                    new PlanetResponds("He thinks that he can pull one over this entire community, like he did with the entire scientific community!", PlanetExpression.Challenging),
                    new PlanetResponds("First he is claiming planets aren't real.", PlanetExpression.Challenging),
                    new PlanetResponds("Next he's going to be claiming that you aren't scientifically literate!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Boo),
                    new OpponentResponds("-", OpponentExpression.Worried)),
                new ClosingOption("Make the audience out to be heroes", +1, 
                    new PlanetResponds("Today is a momentous occasion!", PlanetExpression.Proud),
                    new PlanetResponds("This day, you will become the audience that saved a planet from utter destruction.", PlanetExpression.Proud),
                    new PlanetResponds("You will be remembered. People will thank you for what you have done here today.", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer))),
            new ClosingChoice(new object[] {new PlanetResponds("In conclusion", PlanetExpression.Thinking) },
                new ClosingOption("Insult the slow members of the audience.", -2,
                    new PlanetResponds("At this point, only idiots would still believe I'm not a planet!", PlanetExpression.Proud)),
                new ClosingOption("Super Confident Finish", +2, 
                    new PlanetResponds("There is no doubt I'm a planet -- it's more debatable whether Saturn is a planet!", PlanetExpression.Proud)),
                new ClosingOption("Tell them how science has got your back", +1,
                    new PlanetResponds("The science is irrefutable, Emerson's theory has been tested and proven false.", PlanetExpression.Thinking))));
    }
}
