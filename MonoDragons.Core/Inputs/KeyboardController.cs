using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Inputs
{
    public class KeyboardController : Subject<ControlChange, Direction>, IController
    {
        private readonly Map<Keys, HorizontalDirection> _hDirBind;
        private readonly Map<Keys, VerticalDirection> _vDirBind;
        private readonly Map<Keys, Control> _controlBind;

        private KeyboardState _lastState;

        public KeyboardController(Map<Keys, Control> controlBind)
            : this(CreateDefaultHDirBind(), CreateDefaultVDirBind(), controlBind) { }

        public KeyboardController(Map<Keys, HorizontalDirection> hDirBind, Map<Keys, VerticalDirection> vDirBind, Map<Keys, Control> controlBind)
        {
            _hDirBind = hDirBind;
            _vDirBind = vDirBind;
            _controlBind = controlBind;
        }

        public void Update(TimeSpan delta)
        {
            var state = Keyboard.GetState();
            var downKeys = state.GetPressedKeys().ToList();
            var pressedKeys = downKeys.Where(x => !_lastState.GetPressedKeys().Any(y => x.Equals(y))).ToList();
            var releasedKeys = _lastState.GetPressedKeys().Where(x => downKeys.All(y => !y.Equals(x))).ToList();
            NotifyControlSubscribers(pressedKeys, releasedKeys);
            NotifyDirectionSubscribers(downKeys);
            _lastState = state;
        }

        private void NotifyDirectionSubscribers(List<Keys> downKeys)
        {
            var hDir = (HorizontalDirection) downKeys
                .Where(x => _hDirBind.ContainsKey(x))
                .Select(x => (int) _hDirBind[x])
                .Distinct()
                .Sum();
            var vDir = (VerticalDirection) downKeys
                .Where(x => _vDirBind.ContainsKey(x))
                .Select(x => (int) _vDirBind[x])
                .Distinct()
                .Sum();
            NotifySubscribers(new Direction(hDir, vDir));
        }

        private void NotifyControlSubscribers(List<Keys> pressedKeys, List<Keys> releasedKeys)
        {
            pressedKeys.Where(x => _controlBind.ContainsKey(x))
                .ForEach(x => NotifySubscribers(new ControlChange(_controlBind[x], ControlState.Active)));
            releasedKeys.Where(x => _controlBind.ContainsKey(x))
                .ForEach(x => NotifySubscribers(new ControlChange(_controlBind[x], ControlState.Inactive)));
        }

        private static Map<Keys, VerticalDirection> CreateDefaultVDirBind()
        {
            return new Map<Keys, VerticalDirection>
            {
                {Keys.W, VerticalDirection.Up},
                {Keys.S, VerticalDirection.Down},
                {Keys.Up, VerticalDirection.Up},
                {Keys.Down, VerticalDirection.Down},
            };
        }

        private static Map<Keys, HorizontalDirection> CreateDefaultHDirBind()
        {
            return new Map<Keys, HorizontalDirection>
            {
                {Keys.A, HorizontalDirection.Left},
                {Keys.D, HorizontalDirection.Right},
                {Keys.Left, HorizontalDirection.Left},
                {Keys.Right, HorizontalDirection.Right},
            };
        }

        public void ClearBindings()
        {
            _observers1.Clear();
            _observers2.Clear();
        }
    }
}
