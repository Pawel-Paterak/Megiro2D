using Megiro2D.Render;
using OpenTK;

namespace Megiro2D.Engine
{
    public class Component : EngineObject
    {
        public GameObject gameObject { get; set; } = null;
        public Transform transform { get => gameObject.transform; set => gameObject.transform = value; }
        public Renderer renderer { get => gameObject.GetComponent<Renderer>();}
        public Collider collider { get => gameObject.GetComponent<Collider>();}

        public T AddComponent<T>() where T : Component
            => gameObject.AddComponent<T>();

        public Component AddComponent(Component component)
            => gameObject.AddComponent(component);

        public T GetComponent<T>() where T : Component
            => gameObject.GetComponent<T>();

        public T[] GetComponents<T>() where T : Component
            => gameObject.GetComponents<T>();

        public void RemoveComponent<T>() where T : Component
            => gameObject.RemoveComponent<T>();

        public void RemoveComponent(Component component)
            => gameObject.RemoveComponent(component);

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnComponentAdd()
        {

        }

        public virtual void OnComponentRemove()
        {

        }

        public virtual void OnCollisionEnter(Collision collision)
        {

        }

        public virtual void OnCollisionStay(Collision collision)
        {

        }

        public virtual void OnCollisionExit(Collision collision)
        {

        }
    }
}
