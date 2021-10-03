using Megiro2D;
using Megiro2D.Engine;
using Megiro2D.Render;
using Megiro2D.Resources;
using OpenTK;
using System.Windows.Forms;

namespace DebugConsole
{
    public class TestObject : MegiroBehaviour
    {
        public Vector3 RotationSpeed { get; set; } = new Vector3();

        public override void Start()
        {
            Name = "TestObject";
            Renderer renderer = GetComponent<Renderer>();
            renderer.Texture = EngineResources.LoadTexture("GameIcon32x32.png");
        }

        public override void Update()
        {
            transform.EulerAngles += RotationSpeed * new Vector3(0, Time.DeltaTime, 0);
        }
    }
}
