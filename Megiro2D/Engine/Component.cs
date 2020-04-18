using Megiro2D.Render;
using OpenTK;

namespace Megiro2D.Engine
{
    public class Component : EngineObject
    {
        public GameObject gameObject { get; set; }

        public Transform transform { get => gameObject.transform; set => gameObject.transform = value; }

        public Renderer renderer { get => gameObject.GetComponent<Renderer>();}

        public virtual void Start()
        {

        }

        public virtual void Update(double time)
        {

        }

        public T AddComponent<T>() where T : Component
            => gameObject.AddComponent<T>();

        public Component AddComponent(Component component)
            => gameObject.AddComponent(component);

        public T GetComponent<T>() where T : Component
            => gameObject.GetComponent<T>();
    }
}
