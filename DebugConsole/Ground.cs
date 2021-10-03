using Megiro2D;
using Megiro2D.Render;
using Megiro2D.Resources;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugConsole
{
    public class Ground : MegiroBehaviour
    {
        public override void Start()
        {
            Renderer renderer = AddComponent<Renderer>();
            renderer.Color = Color.Green;
            renderer.Mesh = Mesh.Plane();
            renderer.Texture = EngineResources.LoadTexture("ground.png");

            transform.Scale = new Vector3(100, 1, 100);
        }

        public override void Update()
        {

        }
    }
}
