using Megiro2D.Engine;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megiro2D
{
    public class MegiroCollider
    {
        public List<Collider> Colliders = new List<Collider>();

        public void Update()
        {
            foreach (Collider oCollider in Colliders)
                foreach (Collider tCollider in Colliders)
                    if (oCollider != tCollider && oCollider.gameObject != tCollider.gameObject)
                        Collision(oCollider, tCollider);
        }

        private void Collision(Collider one, Collider two)
        {
            Vector3 dPosition = one.transform.Position - two.transform.Position;

            for(int o=0; o<one.Mesh.VerticesNumber.Length; o+=4)
            {
                int verticesNumberOne1 = one.Mesh.VerticesNumber[o];
                int verticesNumberOne2 = one.Mesh.VerticesNumber[o+1];
                int verticesNumberOne3 = one.Mesh.VerticesNumber[o+2];
                int verticesNumberOne4 = one.Mesh.VerticesNumber[o+3];
                Vector3[] dOne = new Vector3[4];
                dOne[0] = dPosition + one.Mesh.Vertices[verticesNumberOne1] + one.Offset;
                dOne[1] = dPosition + one.Mesh.Vertices[verticesNumberOne2] + one.Offset;
                dOne[2] = dPosition + one.Mesh.Vertices[verticesNumberOne3] + one.Offset;
                dOne[3] = dPosition + one.Mesh.Vertices[verticesNumberOne4] + one.Offset;

                for (int t = 0; t < two.Mesh.VerticesNumber.Length; t+=4)
                {
                    int verticesNumberTwo1 = two.Mesh.VerticesNumber[t];
                    int verticesNumberTwo2 = two.Mesh.VerticesNumber[t+1];
                    int verticesNumberTwo3 = two.Mesh.VerticesNumber[t+2];
                    int verticesNumberTwo4 = two.Mesh.VerticesNumber[t+3];
                    Vector3[] dTwo = new Vector3[4];
                    dTwo[0] = dPosition + two.Mesh.Vertices[verticesNumberTwo1] + two.Offset;
                    dTwo[1] = dPosition + two.Mesh.Vertices[verticesNumberTwo2] + two.Offset;
                    dTwo[2] = dPosition + two.Mesh.Vertices[verticesNumberTwo3] + two.Offset;
                    dTwo[3] = dPosition + two.Mesh.Vertices[verticesNumberTwo4] + two.Offset;

                    for(int oV = 0; oV < dOne.Length; oV++)
                    {
                        for (int oV2 = 0; oV2 < dOne.Length; oV2++)
                        {
                            for (int tV = 0; tV < dTwo.Length; tV++)
                            {
                                for (int tV2 = 0; tV2 < dTwo.Length; tV2++)
                                {
                                    if(oV != oV2 && tV != tV2)
                                    {
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}