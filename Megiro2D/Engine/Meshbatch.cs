using Megiro2D.Render;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Megiro2D.Engine
{
    public class Meshbatch
    {
        public static void Draw(Mesh mesh, Texture2D texture, Vector3 position, Vector3 rotation, Vector3 scale, Color color)
        {
            GL.Translate(position.X, position.Y, position.Z);
            GL.Rotate(rotation.X, 1, 0, 0);
            GL.Rotate(rotation.Y, 0, 1, 0);
            GL.Rotate(rotation.Z, 0, 0, 1);

            if (texture != null)
                GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < mesh.VerticesNumber.Length; i++)
            {
                Vector3 vertex = mesh.Vertices[mesh.VerticesNumber[i]] * scale;
                GL.TexCoord2(mesh.Coords2d[i]);
                GL.Vertex3(vertex);
            }

            GL.End();

            GL.Rotate(-rotation.Z, 0, 0, 1);
            GL.Rotate(-rotation.Y, 0, 1, 0);
            GL.Rotate(-rotation.X, 1, 0, 0);
            GL.Translate(-position.X, -position.Y, -position.Z);
        }
    }
}
