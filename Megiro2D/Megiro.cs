using Megiro2D.Controllers;
using Megiro2D.Engine;
using Megiro2D.Resources;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Megiro2D
{
    public class Megiro
    {
        public static Megiro Singleton;

        private Window window;
        private readonly List<Component> behaviours = new List<Component>();

        public Megiro()
        {
            if (Singleton == null)
                Singleton = this;

            new WindowController();
            new ResourcesEngine();
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

        public void AddBehaviour(Component component)
        {
            behaviours.Add(component);
            component.Start();
            WindowController.Singleton.UpdateFrame += component.Update;
            MegiroBehaviour behaviour = (component as MegiroBehaviour);
            if (behaviour != null)
                WindowController.Singleton.RenderFrame += behaviour.Render;
        }

        public void RemoveBehaviour(MegiroBehaviour behaviour)
        {
            if (behaviours.Contains(behaviour))
            {
                WindowController.Singleton.UpdateFrame -= behaviour.Update;
                WindowController.Singleton.RenderFrame -= behaviour.Render;
                behaviours.Remove(behaviour);
            }
        }
    }
}
