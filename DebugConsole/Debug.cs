using Megiro2D;
using System;
using System.Threading;
using Megiro2D.Controllers;
using Megiro2D.Render;
using OpenTK;
using Megiro2D.Engine;

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

            Console.ReadKey();
            core.Exit();
        }

        private void Write(string text)
        {
            Console.WriteLine(text);
        }


        private void DebugMethod()
        {
           // Ground ground = new Ground();
           // ground.transform.Position = new Vector3(0, -5, 0);
            
            TestObject t = new TestObject();
            t.AddComponent<Renderer>();
            t.RotationSpeed = new Vector3(0, 45, 0);
            t.transform.Position = new Vector3(0,1,0);

            newTestObject n = new newTestObject();
            n.transform.Position = new Vector3(0, 0, 0);


            Thread.Sleep(500);
            do
            {
              /*  Console.Clear();
                Console.WriteLine("cam position: "+n.camera.transform.Position);
                Console.WriteLine("obj position: "+n.transform.Position);
                Thread.Sleep(100);*/
            } while (true);
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
