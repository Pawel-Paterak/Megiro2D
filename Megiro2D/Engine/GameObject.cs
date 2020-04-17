namespace Megiro2D.Engine
{
    public class GameObject
    {
        public Transform transform { get; set; } = new Transform();

        public GameObject gameObject => this;
    }
}
