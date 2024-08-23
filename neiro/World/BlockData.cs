using OpenTK.Mathematics;

namespace neiro.World
{
    public enum Faces
    {
        FRONT,
        BACK,
        LEFT,
        RIGHT,
        TOP,
        BOTTOM
    }

    public struct FaceData
    {
        public List<Vector3> vertices;
        public List<Vector2> uv;
    }

    public struct FaceDataRaw
    {
        public static readonly Dictionary<Faces, List<Vector3>> rawVertexData = new Dictionary<Faces, List<Vector3>>
        {
            {Faces.FRONT, new List<Vector3>()
            {
                new Vector3(-0.5f, 0.5f, 0.5f), // top left vert
                new Vector3(0.5f, 0.5f, 0.5f), // top right vert
                new Vector3(0.5f, -0.5f, 0.5f), // bottom right vert
                new Vector3(-0.5f, -0.5f, 0.5f), // bottom left vert
            } },
            {Faces.BACK, new List<Vector3>()
            {
                new Vector3(0.5f, 0.5f, -0.5f), // top left vert
                new Vector3(-0.5f, 0.5f, -0.5f), // top right vert
                new Vector3(-0.5f, -0.5f, -0.5f), // bottom right vert
                new Vector3(0.5f, -0.5f, -0.5f), // bottom left vert
            } },
            {Faces.LEFT, new List<Vector3>()
            {
                new Vector3(-0.5f, 0.5f, -0.5f), // top left vert
                new Vector3(-0.5f, 0.5f, 0.5f), // top right vert
                new Vector3(-0.5f, -0.5f, 0.5f), // bottom right vert
                new Vector3(-0.5f, -0.5f, -0.5f), // bottom left vert
            } },
            {Faces.RIGHT, new List<Vector3>()
            {
                new Vector3(0.5f, 0.5f, 0.5f), // top left vert
                new Vector3(0.5f, 0.5f, -0.5f), // top right vert
                new Vector3(0.5f, -0.5f, -0.5f), // bottom right vert
                new Vector3(0.5f, -0.5f, 0.5f), // bottom left vert
            } },
            {Faces.TOP, new List<Vector3>()
            {
                new Vector3(-0.5f, 0.5f, -0.5f), // top left vert
                new Vector3(0.5f, 0.5f, -0.5f), // top right vert
                new Vector3(0.5f, 0.5f, 0.5f), // bottom right vert
                new Vector3(-0.5f, 0.5f, 0.5f), // bottom left vert
            } },
            {Faces.BOTTOM, new List<Vector3>()
            {
                new Vector3(-0.5f, -0.5f, 0.5f), // top left vert
                new Vector3(0.5f, -0.5f, 0.5f), // top right vert
                new Vector3(0.5f, -0.5f, -0.5f), // bottom right vert
                new Vector3(-0.5f, -0.5f, -0.5f), // bottom left vert
            } }
        };
    }

}
