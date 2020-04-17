using Megiro2D.Engine;
using Megiro2D.Render.Enums;
using System.Drawing;

namespace Megiro2D.Render
{
    public class Renderer
    {
        public PrimitiveType RenderType { get; set; } = PrimitiveType.Quads;
        public Mesh Mesh { get; set; } = new Mesh();
        public Color Color { get; set; } = Color.Empty;
        public Texture2D Texture { get; set; }
        public bool Render { get; set; } = true;
    }
}
