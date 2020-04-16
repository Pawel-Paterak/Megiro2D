namespace Megiro2D
{
    public class Transform
    {
        public Vector3D Position { get; set; } = new Vector3D();
        public Vector3D Rotation { get; set; } = new Vector3D();
        public Vector3D Scale { get; set; } = new Vector3D(1, 1, 1);
    }
}
