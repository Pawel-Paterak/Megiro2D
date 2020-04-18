using Megiro2D;
using System;
using System.Threading;
using Megiro2D.Controllers;
using Megiro2D.Render;
using OpenTK;

namespace DebugConsole
{
    public class Debug
    {
        private Megiro core = new Megiro();

        public void Start()
        {
            Thread mainThread = new Thread(new ThreadStart(Initialize));
            mainThread.Start();
            WindowController.Singleton.Closing += OnClosing;

            DebugMethod();

            do
            {
                Console.WriteLine("behaviours Count: " + core.behaviours.Count);
            } while (true);

            Console.ReadKey();
            core.Exit();
        }


        private void DebugMethod()
        {
            Ground ground = new Ground();
            //new TestObject().AddComponent<Renderer>();
            newTestObject n = new newTestObject();
        }

        private void OnClosing()
        {
            Environment.Exit(0);
        }

        private void Initialize()
        {
            core.Start(640, 480, "Megiro", 1.0 / 60.0);
        }
    }
}
