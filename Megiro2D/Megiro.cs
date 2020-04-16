using Megiro2D.Controllers;
using System.Collections.Generic;

namespace Megiro2D
{
    public class Megiro
    {
        public static Megiro Singleton;

        private Window window;
        private readonly List<MegiroBehaviour> behaviours = new List<MegiroBehaviour>();

        public Megiro()
        {
            if (Singleton == null)
                Singleton = this;

            new KeyboardController();
            new WindowController();
        }

        public void Start(int width, int height, string title, double updateRatio)
        {
            window = new Window(width, height, title);
            window.Run(updateRatio);
        }

        public void Exit()
        {
            window.Exit();
        }

        public void AddBehaviour(MegiroBehaviour behaviour)
        {
            behaviours.Add(behaviour);
            behaviour.Start();
            WindowController.Singleton.UpdateFrame += behaviour.Update;
            WindowController.Singleton.RenderFrame += behaviour.Render;
        }

        public void RemoveBehaviour(MegiroBehaviour behaviour)
        {
            if (behaviours.Contains(behaviour))
            {
                WindowController.Singleton.UpdateFrame -= behaviour.Update;
                behaviours.Remove(behaviour);
            }
        }
    }
}
