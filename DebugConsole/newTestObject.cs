using Megiro2D;
using Megiro2D.Resources;
using OpenTK;
using System.Windows.Forms;

namespace DebugConsole
{
    public class newTestObject : MegiroBehaviour
    {
        public override void Start()
        {
            gameObject.transform.Position = new Vector3(0, 0, 0);
        }

        public override void Update(double time)
        {
           // gameObject.transform.Rotation += new Vector3(0, 90, 0) * new Vector3(0, (float)time, 0);
        }

        public override void RenderPrefix()
        {
            if(Renderer.Texture == null)
                Renderer.Texture = ResourcesEngine.LoadTexture("Default.png");
        }
    }
}
