using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.UserInterface;

namespace AllPlanet.Debate
{
    public class SpeechUI : IVisualAutomaton
    {
        private const int MillisToCharacter = 30;

        private string _speechbubbleleft = "UI/speechbubble";
        private string _speechbubbleright = "UI/speechbubble-r";

        private string _currentDisplayMessage = "Enter message is deing displayed. Hello.";
        private Side _currentSide = Side.Left;
        private string _currentContent = "";
        private long _totalMessageTime = 0;

        public void Update(TimeSpan deltaMillis)
        {
            _totalMessageTime += (long)deltaMillis.TotalMilliseconds;
            var length = (int)((double)_totalMessageTime / (double)MillisToCharacter);
            length = _currentDisplayMessage.Length < length ? _currentDisplayMessage.Length : length;
            _currentContent = _currentDisplayMessage.Substring(0, length);
        }

        public void Draw(Transform2 parentTransform)
        {
            var bubble = _currentSide.Equals(Side.Left) ? _speechbubbleleft : _speechbubbleright;
            UI.DrawCenteredWithOffset(bubble, new Vector2(0, -100));
            UI.DrawTextCentered(_currentContent, new Rectangle(0, 0, 1600, 700), Color.Black);
        }

        public void Show(string message, Side side)
        {
            _totalMessageTime = 0;
            _currentDisplayMessage = message;
            _currentSide = side;
        }

        public bool IsPrinting()
        {
            return _currentDisplayMessage != _currentContent;
        }

        public void FinishPrinting()
        {
            _totalMessageTime = 99999999;
        }
    }
}
