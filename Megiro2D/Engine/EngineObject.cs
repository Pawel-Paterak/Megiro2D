using System.Windows.Forms;

namespace Megiro2D.Engine
{
    public class EngineObject
    {
        public string Name { get; set; } = "";

        public static void Destroy(EngineObject obj)
        {
            if (obj is GameObject)
            {
                GameObject gameObject = obj as GameObject;
                Component[] components = gameObject.GetComponents<Component>();
                foreach (var component in components)
                {
                    if (component is MegiroBehaviour)
                    {
                        MessageBox.Show("remove " + component.Name + " component");
                        MegiroBehaviour behaviour = component as MegiroBehaviour;
                        behaviour.OnDestroy();
                        Megiro.Singleton.RemoveBehaviour(behaviour);
                    }
                }

                for (int i = 0; i < gameObject.transform.ChildCount; i++)
                    Destroy(gameObject.transform.GetChild(i));
            }

            if (obj is MegiroBehaviour)
            {
                MegiroBehaviour behaviour = obj as MegiroBehaviour;
                MessageBox.Show("remove " + behaviour.Name + " component");
                behaviour.OnDestroy();
                Megiro.Singleton.RemoveBehaviour(behaviour);
            }
        }

        public virtual void OnDestroy()
        {

        }
    }
}
