﻿using System;
using System.Collections.Generic;

namespace Megiro2D.Engine
{
    public class GameObject : EngineObject
    {
        public Transform transform { get; set; } = new Transform();

        private readonly List<Component> components = new List<Component>();

        public T AddComponent<T>() where T : Component
        {
            Component component = null;
            component = (T)Activator.CreateInstance(typeof(T));
            component.gameObject = this;
            components.Add(component);

            return (T)component;
        }

        public Component AddComponent(Component component)
        {
            component.gameObject = this;
            components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
                if (component is T)
                    return component as T;
            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<Component> components = new List<Component>();
            foreach (Component component in this.components)
                if (component is T)
                    components.Add(component);

            return components.ToArray() as T[];
        }
    }
}
