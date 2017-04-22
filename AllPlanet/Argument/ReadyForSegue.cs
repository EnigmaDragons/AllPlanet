using MonoDragons.Core.Engine;

namespace AllPlanet.Argument
{
    public class ReadyForSegue
    {
        private readonly string _argumentPointName;

        public ReadyForSegue(string argumentPointName)
        {
            _argumentPointName = argumentPointName;
        }

        public void Go()
        {
            World.Publish(new Segue(_argumentPointName));
        }
    }
}
