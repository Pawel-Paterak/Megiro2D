using Megiro2D.Controllers;
using Megiro2D.Engine;
using Megiro2D.Render;
using System.Collections.Generic;

namespace Megiro2D
{
    public class Megiro
    {
        public static Megiro Singleton;

        private Window window;
        public readonly List<Component> behaviours = new List<Component>();

        public Megiro()
        {
            if (Singleton == null)
                Singleton = this;

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
        }

        public void RemoveBehaviour(MegiroBehaviour component)
        {
            if (behaviours.Contains(component))
            {
                WindowController.Singleton.UpdateFrame -= component.Update;

                Renderer renderer = component.renderer;
                if (renderer != null)
                    WindowController.Singleton.RenderFrame -= renderer.Render;

                behaviours.Remove(component);
            }
        }
    }
}
