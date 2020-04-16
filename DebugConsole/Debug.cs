using Megiro2D;
using System;
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
            KeyboardController.Singleton.KeyPress += OnKeyPress;
            WindowController.Singleton.Closing += OnClosing;

            DebugMethod();

            Console.ReadKey();
            core.Exit();
        }

        private void DebugMethod()
        {
            TestObject o = new TestObject();
            o.RotationSpeed = 45;
            o.Transform.Position = new Vector3D(2.5f, 0, 0);

            TestObject n = new TestObject();
            n.Transform.Position = new Vector3D(-2.5f, 0, 0);
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
