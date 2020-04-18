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

        public void Render(double time)
        {
            if (CanRender && gameObject != null)
                Meshbatch.Draw(Mesh, Texture, gameObject.transform.Position, gameObject.transform.Rotation, gameObject.transform.Scale, Color);
        }

    }
}
