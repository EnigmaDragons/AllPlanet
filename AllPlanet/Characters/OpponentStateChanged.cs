
namespace AllPlanet.Characters
{
    public sealed class OpponentStateChanged
    {
        public OpponentState State { get; }

        public OpponentStateChanged(OpponentState state)
        {
            State = state;
        }
    }
}
