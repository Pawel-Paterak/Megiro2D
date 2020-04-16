using Megiro2D.Controllers;

namespace Megiro2D
{
    public class Megiro
    {
        private Window window;

        public void Start(int width, int height, string title, double updateRatio)
        {
            window = new Window(width, height, title);
            window.Run(updateRatio);
        }

        public void Exit()
        {
            window.Exit();
        }
    }
}
