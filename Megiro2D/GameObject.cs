using Megiro2D.Render;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Megiro2D
{
    public class GameObject
    {
        public Transform Transform { get; set; } = new Transform();
        public Renderer Renderer { get; set; } = new Renderer();

        public void Render(double time)
        {
            GL.Translate(Transform.Position.X, Transform.Position.Y, Transform.Position.Z);
            GL.Rotate(Transform.Rotation.X, 1, 0, 0);
            GL.Rotate(Transform.Rotation.Y, 0, 1, 0);
            GL.Rotate(Transform.Rotation.Z, 0, 0, 1);

            GL.Begin((PrimitiveType)Renderer.RenderType);

            Color lastColor = Color.Empty;
            int colorNumber = 0;

            for (int i = 0; i < Renderer.Mesh.VerticesNumber.Length; i++)
            {
                if (Renderer.Mesh.Colors != null && Renderer.Mesh.Colors[colorNumber] != lastColor)
                {
                    lastColor = Renderer.Mesh.Colors[colorNumber];
                    GL.Color3(Renderer.Mesh.Colors[colorNumber]);
                }
                Vector3D vector = Renderer.Mesh.Vertices[Renderer.Mesh.VerticesNumber[i]];
                Vector3d vertex = new Vector3d(vector.X * Transform.Scale.X, vector.Y * Transform.Scale.Y, vector.Z * Transform.Scale.Z);
                GL.Vertex3(vertex);
                int nextColor = (i + 1) % 4;
                if (nextColor == 0)
                    colorNumber++;
            }

            GL.End();
            GL.Rotate(-Transform.Rotation.X, 1, 0, 0);
            GL.Rotate(-Transform.Rotation.Y, 0, 1, 0);
            GL.Rotate(-Transform.Rotation.Z, 0, 0, 1);
            GL.Translate(-Transform.Position.X, -Transform.Position.Y, -Transform.Position.Z);
        }
    }
}
