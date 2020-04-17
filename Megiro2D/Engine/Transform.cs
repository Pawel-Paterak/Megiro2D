using OpenTK;

namespace Megiro2D.Engine
{
    public class Transform
    {
        public Vector3 Position { get; set; } = new Vector3();
        public Vector3 Rotation {
            get => rotation;
            set
            {
                rotation.X = SetRotation(value.X);
                rotation.Y = SetRotation(value.Y);
                rotation.Z = SetRotation(value.Z);
            }
        }
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);

        private Vector3 rotation = new Vector3();

        private float SetRotation(float axis)
         => axis % 360;
    }
}
