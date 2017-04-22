using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Core.Audio
{
    public static class Audio
    {
        private static readonly MusicPlayer _musicPlayer = new MusicPlayer();
        private static readonly SoundPlayer _soundPlayer = new SoundPlayer();

        public static void PlaySound(string soundName)
        {
            PlaySound(soundName, 1.0f);
        }

        public static void PlaySound(string soundName, float volume)
        {
            _soundPlayer.PlaySound(soundName, volume);
        }

        public static void PlayMusic(string songName)
        {
            _musicPlayer.PlaySong(songName);
        }
    }
}
