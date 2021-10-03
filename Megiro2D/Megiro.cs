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
        private MegiroCollider megiroCollider = new MegiroCollider();
        private List<MegiroBehaviour> behaviours = new List<MegiroBehaviour>();

        public Megiro()
        {
            if (Singleton == null)
                Singleton = this;

            new WindowController();

            WindowController.Singleton.UpdateFrame += megiroCollider.Update;
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

            WindowController.Singleton.StartFrame += behaviour.Start;
            WindowController.Singleton.UpdateFrame += behaviour.Update;
        }

        public void RemoveBehaviour(MegiroBehaviour behaviour)
        {
            if (behaviours.Contains(behaviour))
            {
                WindowController.Singleton.UpdateFrame -= behaviour.Update;
                behaviours.Remove(behaviour);
            }
        }

        public void AddCollider(Collider collider)
        {
            if (collider != null)
                megiroCollider.Colliders.Add(collider);
        }

        public void RemoveCollider(Collider collider)
        {
            if (collider != null)
                megiroCollider.Colliders.Remove(collider);
        }
    }
}
