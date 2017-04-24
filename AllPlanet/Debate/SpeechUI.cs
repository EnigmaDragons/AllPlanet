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
        
        private string _currentDisplayMessage = "";
        private Side _currentSide = Side.Left;
        private string _currentContent = "";
        private long _totalMessageTime = 0;

        private string Image => (_isThinking ? _thinking : _saying) + _currentSide.ToString().ToLower();
        private string _saying = "UI/speechbubble-";
        private string _thinking = "UI/thoughtbubble-";
        private bool _isThinking;

        public void Update(TimeSpan deltaMillis)
        {
            _totalMessageTime += (long)deltaMillis.TotalMilliseconds;
            var length = (int)((double)_totalMessageTime / (double)MillisToCharacter);
            length = _currentDisplayMessage.Length < length ? _currentDisplayMessage.Length : length;
            _currentContent = _currentDisplayMessage.Substring(0, length);
        }

        public void Draw(Transform2 parentTransform)
        {
            if (_currentDisplayMessage.Equals(""))
                return;
            
            if (_isThinking)
                UI.DrawCenteredWithOffset(Image, new Vector2(800, 240), new Vector2(0, -280));
            else
                UI.DrawCenteredWithOffset(Image, new Vector2(800, 200), new Vector2(0, -300));
            UI.DrawTextCentered(_currentContent, new Rectangle(480, -10, 660, 300), Color.Black);
        }

        public void Show(string message, Side side)
        {
            _isThinking = message.StartsWith("*");
            _totalMessageTime = 0;
            _currentDisplayMessage = _isThinking ? message.Replace("*", "") : message;
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
