using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Megiro2D.Engine
{
    public class GameObject : EngineObject
    {
        public Transform transform { get; set; } = new Transform();

        private readonly List<Component> components = new List<Component>();

        public T AddComponent<T>() where T : Component
        {
            Component component = Activator.CreateInstance(typeof(T)) as Component;
            component.gameObject = this;
            component.OnComponentAdd();
            components.Add(component);
            return (T)component;
        }

        public Component AddComponent(Component component)
        {
            if (component != null)
            {
                component.gameObject = this;
                components.Add(component);
                component.OnComponentAdd();
                return component;
            }
            return null;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
                if (component != null)
                {
                    if (component is T)
                        return component as T;
                }
                else
                    components.Remove(component);
            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> components = new List<T>();
            foreach (Component component in this.components)
                if (component != null)
                {
                    if (component is T)
                        components.Add(component as T);
                }
                else
                    this.components.Remove(component);
            return components.ToArray();
        }

        public void RemoveComponent<T>() where T : Component
        {
            for (int i = 0; i < components.Count; i++)
                if (components[i] is T)
                    components.RemoveAt(i);
        }

        public void RemoveComponent(Component component)
        {
            if(components.Contains(component))
                components.Remove(component);
        }
    }
}
