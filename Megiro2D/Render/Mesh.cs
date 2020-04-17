using OpenTK;

namespace Megiro2D.Render
{
    public class Mesh
    {
        public Vector3[] Vertices { get; set; }
        public Vector2[] Coords2d { get; set; }
        public int[] VerticesNumber { get; set; }

        public Mesh()
        {
            Vertices = new Vector3[8];
            Coords2d = new Vector2[24];
            VerticesNumber = new int[24];

            Vertices[0] = new Vector3(-1.0f, -1.0f, -1.0f);
            Vertices[1] = new Vector3(-1.0f, 1.0f, -1.0f);
            Vertices[2] = new Vector3(1.0f, 1.0f, -1.0f);
            Vertices[3] = new Vector3(1.0f, -1.0f, -1.0f);

            Vertices[4] = new Vector3(1.0f, -1.0f, 1.0f);
            Vertices[5] = new Vector3(-1.0f, -1.0f, 1.0f);
            Vertices[6] = new Vector3(-1.0f, 1.0f, 1.0f);
            Vertices[7] = new Vector3(1.0f, 1.0f, 1.0f);

            Coords2d[0] = new Vector2(0, 0);
            Coords2d[1] = new Vector2(1, 0);
            Coords2d[2] = new Vector2(1, 1);
            Coords2d[3] = new Vector2(0, 1);

            Coords2d[4] = new Vector2(0, 0);
            Coords2d[5] = new Vector2(1, 0);
            Coords2d[6] = new Vector2(1, 1);
            Coords2d[7] = new Vector2(0, 1);

            Coords2d[8] = new Vector2(0, 0);
            Coords2d[9] = new Vector2(1, 0);
            Coords2d[10] = new Vector2(1, 1);
            Coords2d[11] = new Vector2(0, 1);

            Coords2d[12] = new Vector2(0, 0);
            Coords2d[13] = new Vector2(1, 0);
            Coords2d[14] = new Vector2(1, 1);
            Coords2d[15] = new Vector2(0, 1);

            Coords2d[16] = new Vector2(0, 0);
            Coords2d[17] = new Vector2(1, 0);
            Coords2d[18] = new Vector2(1, 1);
            Coords2d[19] = new Vector2(0, 1);

            Coords2d[20] = new Vector2(0, 0);
            Coords2d[21] = new Vector2(1, 0);
            Coords2d[22] = new Vector2(1, 1);
            Coords2d[23] = new Vector2(0, 1);

            VerticesNumber[0] = 1;
            VerticesNumber[1] = 2;
            VerticesNumber[2] = 3;
            VerticesNumber[3] = 0;

            VerticesNumber[4] = 0;
            VerticesNumber[5] = 3;
            VerticesNumber[6] = 4;
            VerticesNumber[7] = 5;

            VerticesNumber[8] = 6;
            VerticesNumber[9] = 1;
            VerticesNumber[10] = 0;
            VerticesNumber[11] = 5;

            VerticesNumber[12] = 7;
            VerticesNumber[13] = 6;
            VerticesNumber[14] = 5;
            VerticesNumber[15] = 4;

            VerticesNumber[16] = 7;
            VerticesNumber[17] = 2;
            VerticesNumber[18] = 1;
            VerticesNumber[19] = 6;

            VerticesNumber[20] = 2;
            VerticesNumber[21] = 7;
            VerticesNumber[22] = 4;
            VerticesNumber[23] = 3;
        }
    }
}
