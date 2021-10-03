using Megiro2D;
using Megiro2D.Controllers;
using Megiro2D.Engine;
using Megiro2D.Render;
using Megiro2D.Resources;
using OpenTK;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DebugConsole
{
    public class newTestObject : MegiroBehaviour
    {
        public GameObject camera;
        private float sensivity = 0.1f;
        float rotateSpeed = 40;

        public override void Start()
        {
            Name = "newTestObject";
            transform.Position = new Vector3(0, 2, 0);

            AddComponent<Renderer>();
            if (renderer.Texture == null)
                renderer.Texture = EngineResources.LoadTexture("Default.png");

            camera = Instantiate(transform.Position + new Vector3(0, 0, 10), new Vector3(0, 0, 0), transform);
            camera.AddComponent<Camera>();
            NewMesh();
        }

        private void NewMesh()
        {
            Mesh mesh = new Mesh();
            mesh.Coords2d = new Vector2[4];
            mesh.Coords2d[0] = new Vector2(0, 0);
            mesh.Coords2d[1] = new Vector2(1, 0);
            mesh.Coords2d[2] = new Vector2(1, 1);
            mesh.Coords2d[3] = new Vector2(0, 1);

            mesh.Vertices = new Vector3[8];
            mesh.Vertices[0] = new Vector3(0, 1, 5);
            mesh.Vertices[1] = new Vector3(0, 1, -5);
            mesh.Vertices[2] = new Vector3(0, -1, 5);
            mesh.Vertices[3] = new Vector3(0, -1, -5);

            mesh.Vertices[4] = new Vector3(1, 0, 5);
            mesh.Vertices[5] = new Vector3(1, 0, -5);
            mesh.Vertices[6] = new Vector3(-1, 0, 5);
            mesh.Vertices[7] = new Vector3(-1, 0, -5);


            mesh.VerticesNumber = new int[8];
            mesh.VerticesNumber[0] = 4;
            mesh.VerticesNumber[1] = 5;
            mesh.VerticesNumber[2] = 7;
            mesh.VerticesNumber[3] = 6;

            mesh.VerticesNumber[4] = 0;
            mesh.VerticesNumber[5] = 1;
            mesh.VerticesNumber[6] = 3;
            mesh.VerticesNumber[7] = 2;

            renderer.Mesh = mesh;
        }

        public override void Update()
        {
            transform.EulerAngles += new Vector3(-Input.MousePosition.Y * sensivity, -Input.MousePosition.X * sensivity, 0);
           // transform.EulerAngles = new Vector3(transform.EulerAngles.X, transform.EulerAngles.Y, 0);
            //transform.EulerAngles += new Vector3(-Input.MousePosition.Y * sensivity, -Input.MousePosition.X * sensivity, 0);
            Move();


            if (Input.KeyPress(OpenTK.Input.Key.KeypadPlus))
                rotateSpeed += 10;

            if (Input.KeyPress(OpenTK.Input.Key.KeypadMinus))
                rotateSpeed -= 10;

            if (Input.KeyDown(OpenTK.Input.Key.Keypad7))
                transform.EulerAngles += new Vector3(rotateSpeed * Time.DeltaTime, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad4))
                transform.EulerAngles = transform.EulerAngles * new Vector3(0, 1, 1);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad1))
                transform.EulerAngles += new Vector3(-rotateSpeed * Time.DeltaTime, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad8))
                transform.EulerAngles += new Vector3(0, rotateSpeed * Time.DeltaTime, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad5))
                transform.EulerAngles = transform.EulerAngles * new Vector3(1, 0, 1);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad2))
                transform.EulerAngles += new Vector3(0, -rotateSpeed * Time.DeltaTime, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad9))
                transform.EulerAngles += new Vector3(0, 0, rotateSpeed * Time.DeltaTime);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad6))
                transform.EulerAngles = transform.EulerAngles * new Vector3(1, 1, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Keypad3))
                transform.EulerAngles += new Vector3(0, 0, -rotateSpeed * Time.DeltaTime);
        }

        private void Move()
        {
            PlayerMove();
            CameraMove();
        }

        private void PlayerMove()
        {
            Vector3 offset = new Vector3();
            if (Input.KeyDown(OpenTK.Input.Key.W))
                offset += transform.Forward * 5 * Time.DeltaTime;

            if (Input.KeyDown(OpenTK.Input.Key.S))
                offset += -transform.Forward * 5 * Time.DeltaTime;

            if (Input.KeyDown(OpenTK.Input.Key.A))
                offset += transform.Left * 5 * Time.DeltaTime;

            if (Input.KeyDown(OpenTK.Input.Key.D))
                offset += -transform.Left * 5 * Time.DeltaTime;

            if (Input.KeyDown(OpenTK.Input.Key.Space))
                offset += transform.Top * 5 * Time.DeltaTime;

            if (Input.KeyDown(OpenTK.Input.Key.ShiftLeft))
                offset += -transform.Top * 5 * Time.DeltaTime;

            if (Input.KeyDown(OpenTK.Input.Key.Z))
                transform.EulerAngles += new Vector3(0, 90 * Time.DeltaTime, 0);
            if (Input.KeyDown(OpenTK.Input.Key.X))
                transform.EulerAngles += new Vector3(0, -90 * Time.DeltaTime, 0);

            transform.Position += offset;
        }

        public void CameraMove()
        {
            Vector3 offset = new Vector3();

            if (Input.KeyDown(OpenTK.Input.Key.Q))
                camera.transform.EulerAngles += new Vector3(0, -90 * Time.DeltaTime, 0);

            if (Input.KeyDown(OpenTK.Input.Key.E))
                camera.transform.EulerAngles += new Vector3(0, 90 * Time.DeltaTime, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Up))
                offset += new Vector3(0, 0, -10 * Time.DeltaTime);

            if (Input.KeyDown(OpenTK.Input.Key.Down))
                offset += new Vector3(0, 0, 10 * Time.DeltaTime);

            if (Input.KeyDown(OpenTK.Input.Key.Left))
                offset += new Vector3(-10 * Time.DeltaTime, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Right))
                offset += new Vector3(10 * Time.DeltaTime, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.ShiftRight))
                offset += new Vector3(0, 10 * Time.DeltaTime, 0);

            if (Input.KeyDown(OpenTK.Input.Key.ControlRight))
                offset += new Vector3(0, -10 * Time.DeltaTime, 0);

            if(camera != null)
                camera.transform.Position += offset;
        }
    }
}
