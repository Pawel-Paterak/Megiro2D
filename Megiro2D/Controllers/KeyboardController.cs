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

        public event Key KeyDown;
        public event Key KeyPress;
        public event Key KeyUp;
        public delegate void Key(char key);

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
