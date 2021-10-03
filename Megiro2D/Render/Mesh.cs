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
            Coords2d = new Vector2[4];
            VerticesNumber = new int[24];

            Vertices[0] = new Vector3(-0.5f, -0.5f, -0.5f);
            Vertices[1] = new Vector3(-0.5f, 0.5f, -0.5f);
            Vertices[2] = new Vector3(0.5f, 0.5f, -0.5f);
            Vertices[3] = new Vector3(0.5f, -0.5f, -0.5f);

            Vertices[4] = new Vector3(0.5f, -0.5f, 0.5f);
            Vertices[5] = new Vector3(-0.5f, -0.5f, 0.5f);
            Vertices[6] = new Vector3(-0.5f, 0.5f, 0.5f);
            Vertices[7] = new Vector3(0.5f, 0.5f, 0.5f);

            Coords2d[0] = new Vector2(0, 0);
            Coords2d[1] = new Vector2(1, 0);
            Coords2d[2] = new Vector2(1, 1);
            Coords2d[3] = new Vector2(0, 1);

            //Back
            VerticesNumber[0] = 1;
            VerticesNumber[1] = 2;
            VerticesNumber[2] = 3;
            VerticesNumber[3] = 0;
            //Bottom
            VerticesNumber[4] = 0;
            VerticesNumber[5] = 3;
            VerticesNumber[6] = 4;
            VerticesNumber[7] = 5;
            //Left
            VerticesNumber[8] = 6;
            VerticesNumber[9] = 1;
            VerticesNumber[10] = 0;
            VerticesNumber[11] = 5;
            //Front
            VerticesNumber[12] = 7;
            VerticesNumber[13] = 6;
            VerticesNumber[14] = 5;
            VerticesNumber[15] = 4;
            //Top
            VerticesNumber[16] = 7;
            VerticesNumber[17] = 2;
            VerticesNumber[18] = 1;
            VerticesNumber[19] = 6;
            //Right
            VerticesNumber[20] = 2;
            VerticesNumber[21] = 7;
            VerticesNumber[22] = 4;
            VerticesNumber[23] = 3;
        }

        public static Mesh Plane()
        {
            Mesh mesh = new Mesh();

            mesh.Vertices = new Vector3[4];
            mesh.Coords2d = new Vector2[4];
            mesh.VerticesNumber = new int[4];

            mesh.Vertices[0] = new Vector3(1, 0, 1);
            mesh.Vertices[1] = new Vector3(-1, 0, 1);
            mesh.Vertices[2] = new Vector3(1, 0, -1);
            mesh.Vertices[3] = new Vector3(-1, 0, -1);


            mesh.Coords2d[0] = new Vector2(0, 0);
            mesh.Coords2d[1] = new Vector2(1, 0);
            mesh.Coords2d[2] = new Vector2(1, 1);
            mesh.Coords2d[3] = new Vector2(0, 1);

            mesh.VerticesNumber[0] = 3;
            mesh.VerticesNumber[1] = 1;
            mesh.VerticesNumber[2] = 0;
            mesh.VerticesNumber[3] = 2;

            return mesh;
        }
    }
}
