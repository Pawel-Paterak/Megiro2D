using System.Drawing;

namespace Megiro2D.Render
{
    public class Mesh
    {
        public Vector3D[] Vertices { get; set; }
        public Color[] Colors { get; set; }
        public int[] VerticesNumber { get; set; }

        public Mesh()
        {
            Vertices = new Vector3D[8];
            Colors = new Color[6];
            VerticesNumber = new int[24];

            Colors[0] = Color.Red;
            Colors[1] = Color.Green;
            Colors[2] = Color.Blue;
            Colors[3] = Color.White;
            Colors[4] = Color.Orange;
            Colors[5] = Color.Pink;

            Vertices[0] = new Vector3D(-1.0f, -1.0f, -1.0f);
            Vertices[1] = new Vector3D(-1.0f, 1.0f, -1.0f);
            Vertices[2] = new Vector3D(1.0f, 1.0f, -1.0f);
            Vertices[3] = new Vector3D(1.0f, -1.0f, -1.0f);
            Vertices[4] = new Vector3D(1.0f, -1.0f, 1.0f);
            Vertices[5] = new Vector3D(-1.0f, -1.0f, 1.0f);
            Vertices[6] = new Vector3D(-1.0f, 1.0f, 1.0f);
            Vertices[7] = new Vector3D(1.0f, 1.0f, 1.0f);

            VerticesNumber[0] = 0;
            VerticesNumber[1] = 1;
            VerticesNumber[2] = 2;
            VerticesNumber[3] = 3;
            VerticesNumber[4] = 0;
            VerticesNumber[5] = 3;
            VerticesNumber[6] = 4;
            VerticesNumber[7] = 5;
            VerticesNumber[8] = 0;
            VerticesNumber[9] = 5;
            VerticesNumber[10] = 6;
            VerticesNumber[11] = 1;
            VerticesNumber[12] = 5;
            VerticesNumber[13] = 4;
            VerticesNumber[14] = 7;
            VerticesNumber[15] = 6;
            VerticesNumber[16] = 1;
            VerticesNumber[17] = 6;
            VerticesNumber[18] = 7;
            VerticesNumber[19] = 2;
            VerticesNumber[20] = 3;
            VerticesNumber[21] = 2;
            VerticesNumber[22] = 7;
            VerticesNumber[23] = 4;
        }
    }
}
