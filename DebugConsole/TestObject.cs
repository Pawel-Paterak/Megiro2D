using Megiro2D;
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
            gameObject.transform.Position = new Vector3(0, 0, 20);
            RotationSpeed = new Vector3(0, 90, 0);
        }

        public override void Update(double time)
        {
            gameObject.transform.Rotation += RotationSpeed * new Vector3(0, (float)time, 0);
        }

        public override void RenderPrefix()
        {
            if(Renderer.Texture == null)
                Renderer.Texture = ResourcesEngine.LoadTexture("GameIcon32x32.png");
        }
    }
}
