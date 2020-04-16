using Megiro2D.Delegates;
using OpenTK;
using OpenTK.Input;
using System;

namespace Megiro2D.Controllers
{
    public class KeyboardController
    {
        public bool Alt { get; private set; }
        public bool Command { get; private set; }
        public bool Control { get; private set; }
        public bool Shift { get; private set; }
        public bool IsRepeat { get; private set; }

        public event KeyDelegate KeyDown;
        public event KeyDelegate KeyPress;
        public event KeyDelegate KeyUp;

        public static KeyboardController Singleton;

        public KeyboardController()
        {
            if (Singleton == null)
                Singleton = this;
        }

        public void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (IsSingleton())
            {
                Alt = e.Alt;
                Command = e.Command;
                Control = e.Control;
                Shift = e.Shift;
                IsRepeat = e.IsRepeat;
                KeyDown?.Invoke(e.Key.ToString()[0]);
            }
        }

        public void OnKeyPress(KeyPressEventArgs e)
        {
            if(IsSingleton())
                KeyPress?.Invoke(e.KeyChar);
        }

        public void OnKeyUp(KeyboardKeyEventArgs e)
        {
            if (IsSingleton())
            {
                Alt = e.Alt;
                Command = e.Command;
                Control = e.Control;
                Shift = e.Shift;
                IsRepeat = e.IsRepeat;
                KeyUp?.Invoke(e.Key.ToString()[0]);
            }
        }

        private bool IsSingleton()
        {
            if (Singleton != this)
                throw new Exception("you can't call this method, you can call this method only in Singleton");
            return true;
        }
    }
}
