using System.Collections.Generic;
using NAudio.Wave;

namespace MonoDragons.Core.Audio
{
    public sealed class SoundPlayer
    {
        private List<WaveOut> _allSounds = new List<WaveOut>();

        public void Play(string sound, float volume)
        {
            var waveOut = new WaveOut();
            waveOut.Init(new AudioFileReader("Content/Sounds/" + sound + ".mp3"));
            waveOut.Volume = volume;
            waveOut.Play();
            _allSounds.Add(waveOut);
        }
    }
}
