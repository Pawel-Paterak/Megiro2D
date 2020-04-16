using OpenTK;
using OpenTK.Graphics;
using Megiro2D.Controllers;

namespace Megiro2D
{
    public class Megiro
    {
        public KeyboardController KeyboardController { get; set; } = new KeyboardController();

        private readonly GameWindow window;

        public Megiro(int width, int height, string title)
        {
            window = new GameWindow(width, height, GraphicsMode.Default, title);
        }

        public void Start()
        {
            window.KeyDown += KeyboardController.OnKeyDown;
            window.KeyPress += KeyboardController.OnKeyPress;
            window.KeyUp += KeyboardController.OnKeyUp;
            window.Run(1.0/60.0);
        }
    }
}
