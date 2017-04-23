using NAudio.Wave;

namespace MonoDragons.Core.Audio
{
    public sealed class MusicPlayer
    {
        private WaveOut _waveOut;

        public void Play(string songName)
        {
            Play(songName, 1.0f);
        }

        public void Play(string songName, float volume)
        {
            DisposeLastWaveOut();
            _waveOut = new WaveOut();
            _waveOut.Init(new AudioFileReader("Content/" + songName + ".mp3"));
            _waveOut.Play();
            _waveOut.Volume = volume;
            _waveOut.PlaybackStopped += LoopSong;
        }

        private void LoopSong(object sender, StoppedEventArgs e)
        {
            _waveOut.Play();
        }

        private void DisposeLastWaveOut()
        {
            if (_waveOut == null)
                return;

            _waveOut.Stop();
            _waveOut.Dispose();
            _waveOut = null;
        }
    }
}
