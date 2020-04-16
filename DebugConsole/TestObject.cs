using Megiro2D;

namespace DebugConsole
{
    public class TestObject : MegiroBehaviour
    {
        public float RotationSpeed { get; set; } = 0;

        public override void Start()
        {

        }

        public override void Update(double time)
        {
            Transform.Rotation += new Vector3D(0, RotationSpeed, 0) * time;
        }
    }
}
