using Megiro2D.Render;
using OpenTK;

namespace Megiro2D.Engine
{
    public class Collider : Component
    {
        public bool IsTrigger { get; set; }
        public Vector3 Offset { get; set; }
        public Mesh Mesh { get; set; }

        public override void OnComponentAdd()
        {
            
            Megiro.Singleton.AddCollider(this);
        }

        public override void OnComponentRemove()
        {
            Megiro.Singleton.RemoveCollider(this);
        }
    }
}
