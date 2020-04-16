using Megiro2D.Render.Enums;

namespace Megiro2D.Render
{
    public class Renderer
    {
        public PrimitiveType RenderType { get; set; } = PrimitiveType.Quads;
        public Mesh Mesh { get; set; } = new Mesh();
    }
}
