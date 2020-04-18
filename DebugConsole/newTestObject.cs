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
        private List<GameObject> gameObjects = new List<GameObject>();
        private GameObject camera;

        public override void Start()
        {
            Name = "newTestObject";
            transform.Position = new Vector3(0, 2, 0);
            AddComponent<Renderer>();
            camera = Instantiate(transform.Position + new Vector3(0, 0, 10), new Vector3(0, 0, 0), transform);
            camera.AddComponent<Camera>();
        }

        public override void Update(double time)
        {
            if(Input.KeyPress(OpenTK.Input.Key.L))
            {
                MessageBox.Show("clicked L");
            }

            if (Input.KeyRelease(OpenTK.Input.Key.K))
            {
                MessageBox.Show("clicked K");

            }

            Move(time);
            if (renderer.Texture == null)
                renderer.Texture = EngineResources.LoadTexture("Default.png");
        }

        private void Move(double time)
        {
            PlayerMove(time);
            CameraMove(time);
        }

        private void PlayerMove(double time)
        {
            Vector3 offset = new Vector3();
            if (Input.KeyDown(OpenTK.Input.Key.W))
                offset += new Vector3(0, 0, -10 * (float)time);

            if (Input.KeyDown(OpenTK.Input.Key.S))
                offset += new Vector3(0, 0, 10 * (float)time);

            if (Input.KeyDown(OpenTK.Input.Key.A))
                offset += new Vector3(-10 * (float)time, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.D))
                offset += new Vector3(10 * (float)time, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Space))
                offset += new Vector3(0, 10 * (float)time, 0);

            if (Input.KeyDown(OpenTK.Input.Key.ShiftLeft))
                offset += new Vector3(0, -10 * (float)time, 0);

            transform.Position += offset;
        }

        public void CameraMove(double time)
        {
            Vector3 offset = new Vector3();

            if (Input.KeyDown(OpenTK.Input.Key.Q))
                camera.transform.Rotation += new Vector3(0, -1 * (float)time, 0);

            if (Input.KeyDown(OpenTK.Input.Key.E))
                camera.transform.Rotation += new Vector3(0, 1 * (float)time, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Up))
                offset += new Vector3(0, 0, -10 * (float)time);

            if (Input.KeyDown(OpenTK.Input.Key.Down))
                offset += new Vector3(0, 0, 10 * (float)time);

            if (Input.KeyDown(OpenTK.Input.Key.Left))
                offset += new Vector3(-10 * (float)time, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.Right))
                offset += new Vector3(10 * (float)time, 0, 0);

            if (Input.KeyDown(OpenTK.Input.Key.ShiftRight))
                offset += new Vector3(0, 10 * (float)time, 0);

            if (Input.KeyDown(OpenTK.Input.Key.ControlRight))
                offset += new Vector3(0, -10 * (float)time, 0);

            if(camera != null)
                camera.transform.Position += offset;
        }
    }
}
