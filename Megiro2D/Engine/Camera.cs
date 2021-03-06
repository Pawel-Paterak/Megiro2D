using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace Megiro2D.Engine
{
    public class Camera : Component
    {
        public static Camera camera;

        public Camera()
        {
            Name = "Camera";
            if (camera == null)
                camera = this;
        }

        public void ApplyTransform(int width, int height)
        {
            Vector3 camPos = gameObject.transform.Position;
            Vector3 camRot = gameObject.transform.EulerAngles;

            float division = (360 / MathHelper.TwoPi);

            Matrix4 perspective = Matrix4.CreatePerspectiveOffCenter(width / 2, width / 2, height / 2, height / 2, 0.1f, 64f);
            perspective = Matrix4.CreateTranslation(-camPos);
            perspective = Matrix4.Mult(perspective, Matrix4.CreateRotationX(camRot.X / division));
            perspective = Matrix4.Mult(perspective, Matrix4.CreateRotationY(camRot.Y / division));
            perspective = Matrix4.Mult(perspective, Matrix4.CreateRotationZ(camRot.Z / division));

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref perspective);
        }
    }
}
