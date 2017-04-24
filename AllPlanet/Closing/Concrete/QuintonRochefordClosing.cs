﻿using AllPlanet.Argument;
using AllPlanet.Crowds;
using AllPlanet.Opponent;
using AllPlanet.Planet;
using AllPlanet.Transitions;

namespace AllPlanet.Closing.Concrete
{
    public static class QuintonRochefordClosing
    {
        public static ClosingArgument Argument { get; } = new ClosingArgument("quinton closing", TransitionFactory.Create("victory"), TransitionFactory.Create("lost to quinton"),
            new ClosingChoice(new object[0], 
                new ClosingOption("No doubt, I am a planet", +1, 
                    new PlanetResponds("Now I shall prove without a doubt I'm a planet!", PlanetExpression.Proud)),
                new ClosingOption("Proud opening", +2,
                    new PlanetResponds("Today is a grand day!", PlanetExpression.Proud),
                    new PlanetResponds("Dr.Rocheford isn't fooling anyone here.", PlanetExpression.Challenging),
                    new PlanetResponds("You know that he is wrong just as much as he does.", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new ClosingOption("Pedantic opening", +1, 
                    new PlanetResponds("Ladies and gentlemen, throughout today's argument, it has become apparent that Dr.Rocheford is incorrect.", PlanetExpression.Challenging),
                    new PlanetResponds("He has given numerous arguments before you, and each one of them was errant.", PlanetExpression.Challenging),
                    new PlanetResponds("Do not trust his white lab coat that he wears.", PlanetExpression.Challenging))),
            new ClosingChoice(new object[0],
                new ClosingOption("Try actual science", -3,
                    new PlanetResponds("Now, a planet is defined as a celestial body that is:", PlanetExpression.Challenging),
                    new PlanetResponds("In orbit of the sun,", PlanetExpression.Challenging),
                    new PlanetResponds("Has suffifcient mass for its own gravity keep it spherical,", PlanetExpression.Challenging),
                    new PlanetResponds("and has cleared the neighborhood around its orbit.", PlanetExpression.Challenging),
                    new PlanetResponds("Now according to this I wouldn't be a planet. However,", PlanetExpression.Worried)),
                new ClosingOption("Over simplify the science", +2,
                    new PlanetResponds("A planet is a sphere that floats in orbit around the sun.", PlanetExpression.Proud),
                    new PlanetResponds("I am a sphere that orbits the sun.", PlanetExpression.Proud),
                    new PlanetResponds("Therefore, I am a planet.", PlanetExpression.Proud)),
                new ClosingOption("Get tricky with the words", -1,
                    new PlanetResponds("Now, a planet is defined as a celestial body that is:", PlanetExpression.Challenging),
                    new PlanetResponds("In orbit of the sun,", PlanetExpression.Challenging),
                    new PlanetResponds("Has suffifcient mass for its own gravity keep it spherical,", PlanetExpression.Challenging),
                    new PlanetResponds("and has cleared the neighborhood around its orbit.", PlanetExpression.Challenging),
                    new PlanetResponds("I do orbit the sun, am spherical, and have cleared the neighborhood around my orbit by showing up here!", PlanetExpression.Proud),
                    new OpponentResponds("There are lots of things that meet that criteria!", OpponentExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new ClosingChoice(new object[] { new PlanetResponds("I have something to say about quinton.", PlanetExpression.Challenging),  },
                new ClosingOption("Quinton is trying to destroy the world", +5,
                    new PlanetResponds("Mad Scientist Quinton roucheford hates all planets!", PlanetExpression.Sad),
                    new PlanetResponds("He was on the council that in 2006 declared that Pluto is not a planet.", PlanetExpression.Sad),
                    new PlanetResponds("He worked for EvilCorp Inc. from 2008-2014 to create a Decimator Bomb to destroy earth!", PlanetExpression.Sad),
                    new PlanetResponds("If he wins, he will blow me up right before your eyes!", PlanetExpression.Sad),
                    new PlanetResponds("If you help save me, I will help save your planet.", PlanetExpression.Challenging),
                    new OpponentResponds("I definitely don't know anything about EvilCorp and how we are going to destroy the world in 2018!", OpponentExpression.Worried),
                    new CrowdResponds(CrowdExpression.Boo)),
                new ClosingOption("Tell them about Quintons Dark Soul", 0,
                    new PlanetResponds("Quinton collects Dark Souls around him, to support him.", PlanetExpression.Challenging),
                    new PlanetResponds("In his enkindling of evil, and should not be trusted.", PlanetExpression.Challenging),
                    new OpponentResponds("Next you're gonna say I was Borne from Blood.", OpponentExpression.Bored),
                new ClosingOption("Dr.Rocheford is Pluto", +3, 
                    new PlanetResponds("I will reveal a great mystery here!", PlanetExpression.Challenging),
                    new PlanetResponds("Dr. Rocheford is PLUTO! In 2006 he was determined to not be a planet.", PlanetExpression.Challenging),
                    new PlanetResponds("And he failed to argue successfully and prove that he is indeed a planet.", PlanetExpression.Challenging),
                    new OpponentResponds("WHAT?!", OpponentExpression.Worried),
                    new PlanetResponds("And now, because of that, he wants revenge! He is trying to prove that nothing is a planet!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.NoComment))),
            new ClosingChoice(new object[0],
                new ClosingOption("A vote for me is a vote for the future", 0,
                    new PlanetResponds("A vote for me is a vote for your future.", PlanetExpression.Proud),
                    new PlanetResponds("We need change in this scientific community!", PlanetExpression.Challenging),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new ClosingOption("Free space flights", 0, 
                    new PlanetResponds("")),
                new ClosingOption()),
            new ClosingChoice(new object[] { new PlanetResponds("In conclusion", PlanetExpression.Challenging), },
                new ClosingOption("I am a fucking planet", +1, 
                    new PlanetResponds("I am a fucking planet.", PlanetExpression.Challenging)),
                new ClosingOption("I just dropped on by to tell you I'm a planet.", 9, 
                    new PlanetResponds("Once upon a time, I floated around the edge of this solar system having a grand party with Neptune.", PlanetExpression.Challenging),
                    new PlanetResponds("A couple years ago, however, scientists like Dr. Emerson and Mad Scientist Rocheford starting claiming I was not a planet.", PlanetExpression.Challenging),
                    new PlanetResponds("So I have traveled 4,200 million kilometers to come to earth to argue before you today that I am indeed a planet.", PlanetExpression.Proud),
                    new CrowdResponds(CrowdExpression.Cheer)),
                new ClosingOption("Dr.Rocheford must be stopped", +2,
                    new PlanetResponds("Dr.Rocheford is a menace to society, and must be stopped at all costs!", PlanetExpression.Sad),
                    new PlanetResponds("Declaring that I'm not a planet is just the next step in his evil plan!", PlanetExpression.Sad))));
    }
}
