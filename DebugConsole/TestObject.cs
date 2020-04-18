using Megiro2D;
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
        }

        public override void Update(double time)
        {
            transform.Rotation += RotationSpeed * new Vector3(0, (float)time, 0);
            if (renderer != null && renderer.Texture == null)
                renderer.Texture = EngineResources.LoadTexture("GameIcon32x32.png");
        }

        public override void OnDestroy()
        {
            MessageBox.Show("Destroing: " +Name);
        }
    }
}
