using neiro.Graphics;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace neiro.World
{
    internal class Chunk
    {
        private List<Vector3> chunkVerts;
        private List<Vector2> chunkUvs;
        private List<uint> chunkIndices;

        const int SIZE = 16;
        const int HEIGHT = 32;
        public Vector3 position;

        private uint indexCount;

        VAO chunkVAO;
        VBO chunkVertexVBO;
        VBO chunkUVVBO;
        IBO chunkIBO;

        Texture texture;

        public Chunk(Vector3 position) 
        {
            this.position = position;

            chunkVerts = new List<Vector3>();
            chunkUvs = new List<Vector2>();
            chunkIndices = new List<uint>();

            GenBlocks();
            BuildChunk();
        }

        public void GenChunk() //generate data
        {

        }
        public void GenBlocks() 
        {
            for (int i = 0; i < 3; i++)
            {
                Block block = new Block(new Vector3(i, 0, 0));

                int faceCount = 0;

                if (i == 0)
                {
                    var leftFaceData = block.GetFace(Faces.LEFT);
                    chunkVerts.AddRange(leftFaceData.vertices);
                    chunkUvs.AddRange(leftFaceData.uv);
                    faceCount++;
                }
                if (i == 2)
                {
                    var rightFaceData = block.GetFace(Faces.RIGHT);
                    chunkVerts.AddRange(rightFaceData.vertices);
                    chunkUvs.AddRange(rightFaceData.uv);
                    faceCount++;
                }

                var frontFaceData = block.GetFace(Faces.FRONT);
                chunkVerts.AddRange(frontFaceData.vertices);
                chunkUvs.AddRange(frontFaceData.uv);



                var backFaceData = block.GetFace(Faces.BACK);
                chunkVerts.AddRange(backFaceData.vertices);
                chunkUvs.AddRange(backFaceData.uv);

                var topFaceData = block.GetFace(Faces.TOP);
                chunkVerts.AddRange(topFaceData.vertices);
                chunkUvs.AddRange(topFaceData.uv);

                var bottomFaceData = block.GetFace(Faces.BOTTOM);
                chunkVerts.AddRange(bottomFaceData.vertices);
                chunkUvs.AddRange(bottomFaceData.uv);

                faceCount += 4;

                AddIndices(faceCount);
            }
        } // generate block faces given data
        public void AddIndices(int amtFaces)
        {
            for (int i = 0;i < amtFaces; i++)
            {
                chunkIndices.Add(0 + indexCount);
                chunkIndices.Add(1 + indexCount);
                chunkIndices.Add(2 + indexCount);
                chunkIndices.Add(2 + indexCount);
                chunkIndices.Add(3 + indexCount);
                chunkIndices.Add(0 + indexCount);

                indexCount += 4;
            }
        }
        public void BuildChunk() 
        {
            chunkVAO = new VAO();
            chunkVAO.Bind();

            chunkVertexVBO = new VBO(chunkVerts);
            chunkVAO.LinkToVAO(0, 3, chunkVertexVBO);

            chunkUVVBO = new VBO(chunkUvs);
            chunkUVVBO.Bind();
            chunkVAO.LinkToVAO(1, 2, chunkUVVBO);

            chunkIBO = new IBO(chunkIndices);

            texture = new Texture("dirtTexture.png");
        } // take data and process it for rendering 
        public void Render(ShaderProgram program) // drawing chunk
        {
            program.Bind();
            chunkVAO.Bind();
            chunkIBO.Bind();
            texture.Bind();
            GL.DrawElements(PrimitiveType.Triangles, chunkIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void Delete()
        {
            chunkVAO.Delete();
            chunkVertexVBO.Delete();
            chunkUVVBO.Delete();
            chunkIBO.Delete();
            texture.Delete();
        }
    }
}
