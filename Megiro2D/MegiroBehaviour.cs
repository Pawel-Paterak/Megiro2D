using Megiro2D.Engine;
using OpenTK;

namespace Megiro2D
{
    public class MegiroBehaviour : Component
    {
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
            MegiroBehaviour behaviour = new MegiroBehaviour();
            behaviour.gameObject.transform.Position = position;
            behaviour.gameObject.transform.Rotation = rotation;
            behaviour.gameObject.transform.Parent = parent;
            return behaviour.gameObject;
        }

        private void Initialize()
        {
            base.gameObject = gameObject;
            AddComponent(this);
            Megiro.Singleton.AddBehaviour(this);
        }
    }
}
