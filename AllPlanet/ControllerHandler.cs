using MonoDragons.Core.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllPlanet
{
    public static class ControlHandler
    {
        private static List<KeyValuePair<int, KeyValuePair<Control, Func<bool>>>> _bindingsOnPress;
        private static List<KeyValuePair<int, KeyValuePair<Control, Func<bool>>>> _bindingsOnRelease;

        public static void Initialize(params Control[] controls)
        {
            for (var i = 0; i < controls.Length; i++)
            {
                var control = controls[i];
                Input.On(control, () => Press(control), () => Release(control));
            }
            _bindingsOnPress = new List<KeyValuePair<int, KeyValuePair<Control, Func<bool>>>>();
            _bindingsOnRelease = new List<KeyValuePair<int, KeyValuePair<Control, Func<bool>>>>();
        }

        private static void Press(Control control)
        {
            Handle(control, _bindingsOnPress);
        }

        private static void Release(Control control)
        {
            Handle(control, _bindingsOnRelease);
        }

        private static void Handle(Control control, List<KeyValuePair<int, KeyValuePair<Control, Func<bool>>>> list)
        {
            for (var i = 0; i < list.Count; i++)
                if (list.ElementAt(i).Value.Key == control)
                    if (/*Handled*/ list.ElementAt(i).Value.Value())
                        return;
        }

        public static void BindOnPress(int i, Control c, Func<bool> f)
        {
            BindOnPress(new KeyValuePair<int, KeyValuePair<Control, Func<bool>>>(i, new KeyValuePair<Control, Func<bool>>(c, f)));
        }

        public static void BindOnPress(KeyValuePair<int, KeyValuePair<Control, Func<bool>>> controlBinding)
        {
            _bindingsOnPress.Add(controlBinding);
            _bindingsOnPress = _bindingsOnPress.OrderBy((b) => b.Key).Reverse().ToList();
        }

        public static void UnbindOnPress(KeyValuePair<int, KeyValuePair<Control, Func<bool>>> controlBinding)
        {
            _bindingsOnPress.Remove(controlBinding);
        }

        public static void BindOnRelease(int i, Control c, Func<bool> f)
        {
            BindOnRelease(new KeyValuePair<int, KeyValuePair<Control, Func<bool>>>(i, new KeyValuePair<Control, Func<bool>>(c, f)));
        }

        public static void BindOnRelease(KeyValuePair<int, KeyValuePair<Control, Func<bool>>> controlBinding)
        {
            _bindingsOnRelease.Add(controlBinding);
            _bindingsOnRelease = _bindingsOnRelease.OrderBy((b) => b.Key).Reverse().ToList();
        }

        public static void UnbindOnRelease(KeyValuePair<int, KeyValuePair<Control, Func<bool>>> controlBinding)
        {
            _bindingsOnRelease.Remove(controlBinding);
        }
    }
}
