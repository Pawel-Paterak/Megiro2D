namespace Megiro2D.Engine
{
    public class Texture2D
    {
        public int ID { get => id; }
        public int Width { get => width; }
        public int Height { get => height; }

        private int id;
        private int width;
        private int height;

        public Texture2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }
    }
}
