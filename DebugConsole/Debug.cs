using Megiro2D;
using System;
using Megiro2D.Delegates;
using System.Threading;
using Megiro2D.Controllers;

namespace DebugConsole
{
    public class Debug
    {
        private Megiro core = new Megiro();

        public void Start()
        {
            Thread mainThread = new Thread(new ThreadStart(Initialize));
            mainThread.Start();
            Thread.Sleep(1000);
            KeyboardController.Singleton.KeyPress += OnKeyPress;
            WindowController.Singleton.Closing += OnClosing;

            Console.ReadKey();
            core.Exit();
        }

        private void OnClosing()
        {
            Environment.Exit(0);
        }

        private void Initialize()
        {
            core.Start(500, 300, "Megiro", 1.0 / 60.0);
        }

        private void OnKeyPress(char key)
        {
            Console.Write(key);
        }
    }
}
