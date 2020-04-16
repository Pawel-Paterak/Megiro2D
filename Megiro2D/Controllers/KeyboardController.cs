using Megiro2D.Delegates;
using OpenTK;
using OpenTK.Input;

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

        public void OnKeyDown(object o, KeyboardKeyEventArgs e)
        {
            Alt = e.Alt;
            Command = e.Command;
            Control = e.Control;
            Shift = e.Shift;
            IsRepeat = e.IsRepeat;
            KeyDown?.Invoke(e.Key.ToString()[0]);
        }

        public void OnKeyPress(object o, KeyPressEventArgs e)
            => KeyPress?.Invoke(e.KeyChar);

        public void OnKeyUp(object o, KeyboardKeyEventArgs e)
        {
            Alt = e.Alt;
            Command = e.Command;
            Control = e.Control;
            Shift = e.Shift;
            IsRepeat = e.IsRepeat;
            KeyUp?.Invoke(e.Key.ToString()[0]);
        }
    }
}
