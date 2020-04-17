using Megiro2D.Controllers;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Windows.Forms;

namespace Megiro2D.Engine
{
    public class Camera : MegiroBehaviour
    {

        public override void Start()
        {
            Renderer.Render = false;
            gameObject.transform.Position = new Vector3(0, 0, 5);
            gameObject.transform.Rotation = new Vector3(0, 0, 0);
        }

        public override void Update(double time)
        {
            if (Input.KeyDown(OpenTK.Input.Key.Q))
                gameObject.transform.Rotation += new Vector3(0, -1 * (float)time, 0);
            if (Input.KeyDown(OpenTK.Input.Key.E))
                gameObject.transform.Rotation += new Vector3(0, 1 * (float)time, 0);

            if (Input.KeyDown(OpenTK.Input.Key.W))
                gameObject.transform.Position += new Vector3(0, 0, -10 * (float)time);
            if (Input.KeyDown(OpenTK.Input.Key.S))
                gameObject.transform.Position += new Vector3(0, 0, 10 * (float)time);
            if (Input.KeyDown(OpenTK.Input.Key.A))
                gameObject.transform.Position += new Vector3(-10 * (float)time, 0, 0);
            if (Input.KeyDown(OpenTK.Input.Key.D))
                gameObject.transform.Position += new Vector3(10 * (float)time, 0, 0);
            if (Input.KeyDown(OpenTK.Input.Key.Space))
                gameObject.transform.Position += new Vector3(0, 10 * (float)time, 0);
            if (Input.KeyDown(OpenTK.Input.Key.ShiftLeft))
                gameObject.transform.Position += new Vector3(0, -10 * (float)time, 0);
        }

        public void ApplyTransform(int width, int height)
        {
            Vector3 camPos = gameObject.transform.Position;
            Vector3 camRot = gameObject.transform.Rotation;

            Matrix4 perspective = Matrix4.CreatePerspectiveOffCenter(width / 2, width / 2, height / 2, height / 2, 0.1f, 64f);
            perspective = Matrix4.CreateTranslation(-camPos);
            perspective = Matrix4.Mult(perspective, Matrix4.CreateRotationX(camRot.X));
            perspective = Matrix4.Mult(perspective, Matrix4.CreateRotationY(camRot.Y));
            perspective = Matrix4.Mult(perspective, Matrix4.CreateRotationZ(camRot.Z));

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref perspective);
        }
    }
}
