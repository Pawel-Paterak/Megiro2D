using Megiro2D.Controllers;
using Megiro2D.Engine;
using Megiro2D.Render.Enums;
using System.Drawing;

namespace Megiro2D.Render
{
    public class Renderer : Component
    {
        public PrimitiveType RenderType { get; set; } = PrimitiveType.Quads;
        public Mesh Mesh { get; set; } = new Mesh();
        public Color Color { get; set; } = Color.White;
        public Texture2D Texture { get; set; }
        public bool CanRender { get; set; } = true;

        public Renderer()
        {
            Name = "Renderer";
            WindowController.Singleton.RenderFrame += Render;
        }

        public override void OnDestroy()
        {
            WindowController.Singleton.RenderFrame -= Render;
        }

        public void Render(double time)
        {
            if (CanRender && gameObject != null)
                Meshbatch.Draw(Mesh, Texture, gameObject.transform.Position, gameObject.transform.Rotation, gameObject.transform.Scale, Color);
        }

    }
}
