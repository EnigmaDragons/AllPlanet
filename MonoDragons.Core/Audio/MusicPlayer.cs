using NAudio.Wave;

namespace MonoDragons.Core.Audio
{
    public sealed class MusicPlayer
    {
        private WaveOut _waveOut;

        public void PlaySong(string songName)
        {
            DisposeLastWaveOut();
            _waveOut = new WaveOut();
            _waveOut.Init(new AudioFileReader("Content/" + songName + ".mp3"));
            _waveOut.Play();
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
