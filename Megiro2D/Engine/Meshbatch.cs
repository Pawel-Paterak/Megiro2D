using Megiro2D.Render;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Megiro2D.Engine
{
    public class Meshbatch
    {
        public static void Draw(Mesh mesh, Texture2D texture, Transform transform, Color color)
        {
            Vector3 position = transform.Position;
            Vector3 rotation = transform.EulerAngles;

            GL.PushMatrix();
            GL.Translate(position);
            GL.Rotate(rotation.X, 1, 0, 0);
            GL.Rotate(rotation.Y, 0, 1, 0);
            GL.Rotate(rotation.Z, 0, 0, 1);

            GL.DepthMask(false);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            if (texture != null)
                GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(PrimitiveType.Quads);

            if (color != Color.Empty)
                GL.Color3(color);

            for (int i = 0; i < mesh.VerticesNumber.Length; i++)
            {
                GL.TexCoord2(mesh.Coords2d[i % mesh.Coords2d.Length]);

                Vector3 vertex = mesh.Vertices[mesh.VerticesNumber[i]] * transform.Scale;
                GL.Vertex3(vertex);
            }

            GL.End();

            GL.PopMatrix();
        }
    }
}
