using Megiro2D.Render;
using OpenTK;

namespace Megiro2D.Engine
{
    public class Component : EngineObject
    {
        public GameObject gameObject { get; set; } = null;

        public Transform transform { get => gameObject.transform; set => gameObject.transform = value; }

        public Renderer renderer { get => gameObject.GetComponent<Renderer>();}

        public T AddComponent<T>() where T : Component
            => gameObject.AddComponent<T>();

        public Component AddComponent(Component component)
            => gameObject.AddComponent(component);

        public T GetComponent<T>() where T : Component
            => gameObject.GetComponent<T>();

        public T[] GetComponents<T>() where T : Component
            => gameObject.GetComponents<T>();
    }
}
