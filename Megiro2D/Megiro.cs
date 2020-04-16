using OpenTK;
using OpenTK.Graphics;
using Megiro2D.Controllers;
using System;
using System.Threading;

namespace Megiro2D
{
    public class Megiro
    {
        public KeyboardController KeyboardController { get; private set; } = new KeyboardController();
        public WindowController WindowController { get; private set; } = new WindowController();

        private Thread mainThread;
        private GameWindow window;

        public Megiro(int width, int height, string title)
        {
            mainThread = new Thread(() => Initialize(width, height, title));
        }

        public void Start()
        {
            mainThread.Start();
        }

        public void Close()
        {
            window.Close();
        }

        private void Initialize(int w, int h, string t)
        {
            window = new GameWindow(w, h, GraphicsMode.Default, t);
            InitializeWindow();
            InitializeKeyboard();
            window.Run(1.0 / 60.0);
        }

        private void InitializeWindow()
        {
            window.Load += Loaded;
            window.Load += WindowController.OnLoad;
            window.Resize += Resize;
            window.Resize += WindowController.OnResize;
            window.UpdateFrame += UpdateFrame;
            window.UpdateFrame += WindowController.OnUpdateFrame;
            window.RenderFrame += RenderFrame;
            window.RenderFrame += WindowController.OnRenderFrame;
        }

        private void InitializeKeyboard()
        {
            window.KeyDown += KeyboardController.OnKeyDown;
            window.KeyPress += KeyboardController.OnKeyPress;
            window.KeyUp += KeyboardController.OnKeyUp;
        }

        private void Loaded(object o, EventArgs e)
        {

        }

        private void Resize(object o, EventArgs e)
        {

        }

        private void UpdateFrame(object o, EventArgs e)
        {

        }

        public void RenderFrame(object o, EventArgs e)
        {

        }
    }
}
