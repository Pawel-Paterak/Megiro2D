using Megiro2D.Controllers;
using Megiro2D.Engine;
using System.Drawing;

namespace Megiro2D.Render
{
    public class Renderer : Component
    {
        public Mesh Mesh { get; set; } = new Mesh();
        public Color Color { get; set; } = Color.White;
        public Texture2D Texture { get; set; }
        public bool CanRender { get; set; } = true;

        public override void OnComponentAdd()
        {
            WindowController.Singleton.RenderFrame += Render;
        }

        public override void OnComponentRemove()
        {
            WindowController.Singleton.RenderFrame -= Render;
        }

        public void Render()
        {
            if (CanRender && gameObject != null)
                Meshbatch.Draw(Mesh, Texture, gameObject.transform, Color);
        }

    }
}
