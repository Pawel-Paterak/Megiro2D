using System;
using System.Windows.Forms;

namespace Megiro2D.Engine
{
    public class EngineObject
    {
        public string Name { get; set; } = "";

        public static void Destroy(EngineObject obj)
        {
            if (obj is MegiroBehaviour)
            {
                MegiroBehaviour behaviour = obj as MegiroBehaviour;
                behaviour.OnDestroy();
                Megiro.Singleton.RemoveBehaviour(behaviour);
            }

            if(obj is Component)
            {
                Component component = obj as Component;
                component.OnDestroy();
                component.OnComponentRemove();
                component.RemoveComponent(component);
            }
        }

        public virtual void OnDestroy()
        {

        }
    }
}
