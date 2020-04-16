using Megiro2D;
using System;
using Megiro2D.Delegates;

namespace DebugConsole
{
    public class Core
    {
        private Megiro window;

        public void Start()
        {
            window = new Megiro(500, 300, "Megiro");
            window.Start();
            window.KeyboardController.KeyPress += new KeyDelegate(OnKeyPress);
            Console.ReadKey();
            window.Close();
        }

        private void OnKeyPress(char key)
        {
            Console.Write(key);
        }
    }
}
