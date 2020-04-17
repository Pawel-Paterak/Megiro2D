using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace Megiro2D.Controllers
{
    public class Input
    {
        public Vector2 MousePosition { get => new Vector2(Mouse.GetCursorState().X, Mouse.GetCursorState().Y); }

        private static List<Key> keysDown;
        private static List<Key> keysDownLast;
        private static List<MouseButton> buttonsDown;
        private static List<MouseButton> buttonsDownLast;

        public static void Initialize(GameWindow window)
        {
            keysDown = new List<Key>();
            keysDownLast = new List<Key>();
            buttonsDown = new List<MouseButton>();
            buttonsDownLast = new List<MouseButton>();

            window.KeyDown += Window_KeyDown;
            window.KeyUp += Window_KeyUp;
            window.MouseDown += Window_MouseDown;
            window.MouseUp += Window_MouseUp;
        }

        private static void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            while (buttonsDown.Contains(e.Button))
                buttonsDown.Remove(e.Button);
        }

        private static void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            buttonsDown.Add(e.Button);
        }

        private static void Window_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            while (keysDown.Contains(e.Key))
                keysDown.Remove(e.Key);
        }

        private static void Window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            keysDown.Add(e.Key);
        }

        public static void Update()
        {
            keysDownLast = new List<Key>(keysDown);
            buttonsDownLast = new List<MouseButton>(buttonsDown);
        }

        public static bool KeyPress(Key key)
            => (keysDown.Contains(key) && !keysDownLast.Contains(key));

        public static bool KeyRelease(Key key)
            => (!keysDown.Contains(key) && keysDownLast.Contains(key));

        public static bool KeyDown(Key key)
            => keysDown.Contains(key);

        public static bool MousePress(MouseButton button)
            => (buttonsDown.Contains(button) && !buttonsDownLast.Contains(button));

        public static bool MouseRelease(MouseButton button)
            => (!buttonsDown.Contains(button) && buttonsDownLast.Contains(button));

        public static bool MouseDown(MouseButton button)
            => buttonsDown.Contains(button);
    }
}
