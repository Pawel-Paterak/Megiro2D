using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Megiro2D.Engine
{
    public class Component
    {
        public string name { get; set; } = "Default";
        public GameObject gameObject { get; set; } = new GameObject();

        public Component parent { get; set; }

        private readonly List<Component> components = new List<Component>();

        public virtual void Start()
        {

        }

        public virtual void Update(double time)
        {

        }

        public T AddComponent<T>() where T : Component
        {
            Component component = null;
            if (parent != this && parent != null)
                parent.AddComponent<T>();
            else
            {
                component = (T)Activator.CreateInstance(typeof(T));
                component.parent = parent;
                components.Add(component);
                Megiro.Singleton.AddBehaviour(component);
            }

            return (T)component;
        }

        public Component AddComponent(Component component)
        {
            if (parent != this && parent != null)
                parent.AddComponent(component);
            else
            {
                component.parent = parent;
                components.Add(component);
            }

            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            if (parent == this)
            {
                foreach (Component component in components)
                    if (component is T)
                        return component as T;
            }
            else
            {
                foreach (Component component in parent.components)
                    if (component is T)
                        return component as T;
            }
            return null;
        }
    }
}
