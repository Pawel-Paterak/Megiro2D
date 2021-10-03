using Megiro2D.Engine;
using OpenTK;
using System.Windows.Forms;

namespace Megiro2D
{
    public class MegiroBehaviour : Component
    {
        public string Name { get => base.Name; set { gameObject.Name = value; base.Name = value; } }
        public GameObject gameObject { get; set; } = new GameObject();

        public MegiroBehaviour()
        {
            Initialize();
        }

        public MegiroBehaviour(bool initialize)
        {
            if (initialize)
                Initialize();
        }

        public GameObject Instantiate(Vector3 position, Vector3 rotation)
            => Instantiate(position, rotation, null);

        public GameObject Instantiate(Vector3 position, Vector3 rotation, Transform parent)
        {
            GameObject gameobject = new GameObject();
            gameobject.transform.Position = position;
            gameobject.transform.EulerAngles = rotation;
            gameobject.transform.Parent = parent;
            return gameobject;
        }

        private void Initialize()
        {
            Name = "Behaviour";
            base.gameObject = gameObject;
            AddComponent(this);
            Megiro.Singleton.AddBehaviour(this);
        }
    }
}
