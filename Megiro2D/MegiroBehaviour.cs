using Megiro2D.Engine;
using Megiro2D.Render;
using Megiro2D.Resources;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Megiro2D
{
    public class MegiroBehaviour : Component
    {
        public Renderer Renderer { get; set; } = new Renderer();

        public MegiroBehaviour()
        {
            parent = this;
            AddComponent(this);
            Megiro.Singleton.AddBehaviour(this);
        }

        public virtual void RenderPrefix()
        {

        }

        public void Render(double time)
        {
            RenderPrefix();

            if(Renderer.Render)
                Meshbatch.Draw(Renderer.Mesh, Renderer.Texture, gameObject.transform.Position, gameObject.transform.Rotation, gameObject.transform.Scale, Renderer.Color);
        }
    }
}
