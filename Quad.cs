using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour {

    Vector3[] GetCubeVertices(Vector3 Size)
    {
        List<Vector3> vertices = new List<Vector3>();

        Vector3[] front = new Vector3[]
        {
            new Vector3(-Size.x, -Size.y, -Size.z),
            new Vector3(-Size.x, Size.y, -Size.z),
            new Vector3(Size.x, Size.y, -Size.z),
            new Vector3(Size.x, -Size.y, -Size.z)
        };

        Vector3[] back = new Vector3[]
       {
            new Vector3(Size.x, -Size.y, Size.z),
            new Vector3(Size.x, Size.y, Size.z),
            new Vector3(-Size.x, Size.y, Size.z),
            new Vector3(-Size.x, -Size.y, Size.z)
       };

        Vector3[] right = new Vector3[]
       {
            new Vector3(Size.x, -Size.y, Size.z),
            new Vector3(Size.x, Size.y, Size.z),
            new Vector3(Size.x, Size.y, -Size.z),
            new Vector3(Size.x, -Size.y, -Size.z)
       };

        Vector3[] left = new Vector3[]
        {
            new Vector3(-Size.x, -Size.y, -Size.z),
            new Vector3(-Size.x, Size.y, -Size.z),
            new Vector3(-Size.x, Size.y, Size.z),
            new Vector3(-Size.x, -Size.y, Size.z)
        };

        Vector3[] top = new Vector3[]
        {
            new Vector3(-Size.x, Size.y, -Size.z),
            new Vector3(-Size.x, Size.y, Size.z),
            new Vector3(Size.x, Size.y, Size.z),
            new Vector3(Size.x, Size.y, -Size.z)
         };

        Vector3[] Bottom = new Vector3[]
        {
            new Vector3(Size.x, -Size.y, Size.z),
            new Vector3(Size.x, -Size.y, -Size.z),
            new Vector3(-Size.x, -Size.y, -Size.z),
            new Vector3(-Size.x, -Size.y, Size.z)
        };

        vertices.AddRange(front);
        vertices.AddRange(right);
        vertices.AddRange(back);
        vertices.AddRange(left);
        vertices.AddRange(top);
        vertices.AddRange(Bottom);

        return vertices.ToArray();
    }

    int[] GetTrianglesArray(int StartIndex, bool Backward = true)
    {
        return new int[]
        {
            StartIndex,
            Backward ? StartIndex + 1: StartIndex + 2,
            Backward ? StartIndex + 2: StartIndex + 1,
            StartIndex,
            Backward ? StartIndex + 2: StartIndex + 3,
            Backward ? StartIndex + 3: StartIndex + 2
        };
    }

    int[] GetTriangles(Vector3[] vertices)
    {
        List<int> triangle = new List<int>();

        bool Backward = true;
        for(int i = 0; i < vertices.Length / 4; i++)
        {
            int[] quadTriangles = GetTrianglesArray(i * 4, Backward);
            triangle.AddRange(quadTriangles);
            Backward = !Backward;
        }

        return triangle.ToArray();
    }

    Vector2[] GetUVArray(Vector2 origin, Vector3 uvSize)
    {
        List<Vector2> uvs = new List<Vector2>();

        //Vector2[] front = new Vector2[]
        //{
        //    new Vector2(origin.x + uvSize.x , origin.y - (uvSize.y *2)),
        //    new Vector2(origin.x + uvSize.x , origin.y - uvSize.y),
        //    new Vector2(origin.x + (uvSize.x * 2) , origin.y - uvSize.y),
        //    new Vector2(origin.x + (uvSize.x * 2) ,origin.y - (uvSize.y *2))
        //};

        Vector2[] front = new Vector2[]
      {
            new Vector2(origin.x + uvSize.z, origin.y),
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y)
      };

        Vector2[] back = new Vector2[]
        {
            new Vector2(origin.x + uvSize.x + uvSize.z * 2, origin.y),
            new Vector2(origin.x + uvSize.x + uvSize.z * 2, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.x * 2 + uvSize.z * 2, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.x * 2 + uvSize.z * 2, origin.y),
        };

        Vector2[] right = new Vector2[]
       {
            new Vector2(origin.x , origin.y),
            new Vector2(origin.x , origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z , origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z , origin.y),
         };

        Vector2[] left = new Vector2[]
        {
            new Vector2(origin.x + uvSize.x + uvSize.z, origin.y),
            new Vector2(origin.x + uvSize.x + uvSize.z, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.x + uvSize.z * 2, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.x + uvSize.z * 2, origin.y),
        };

        Vector2[] top = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y)
          };

        Vector2[] Bottom = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.x + uvSize.z * 2, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.x + uvSize.z * 2, origin.y + uvSize.y),
        };

        //     //Bottom
        //     new Vector2(0.25f,0.875f),
        //     new Vector2(0.25f,1),
        //     new Vector2(0.375f,1),
        //     new Vector2(0.375f,0.875f),
        //};


        uvs.AddRange(front);
        uvs.AddRange(right);
        uvs.AddRange(back);
        uvs.AddRange(left);
        uvs.AddRange(top);
        uvs.AddRange(Bottom);

        return uvs.ToArray();

        //uvs.AddRange(front);

        //return uvs.ToArray();
    }

	void Start () {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();

       // Vector2[] uvs = new Vector2[]
       //{
       //     //new Vector2(0f,0f),
       //     //new Vector2(0f,1f),
       //     //new Vector2(1f,1f),
       //     //new Vector2(1f,0f),

       //     //front
       //     new Vector2(0.125f,0.75f),
       //     new Vector2(0.125f,0.875f),
       //     new Vector2(0.25f,0.875f),
       //     new Vector2(0.25f,0.75f),

       //     //top
       //     new Vector2(0.125f,0.875f),
       //     new Vector2(0.125f,1f),
       //     new Vector2(0.25f,1f),
       //     new Vector2(0.25f,0.875f),

       //     //Right
       //     new Vector2(0,0.75f),
       //     new Vector2(0,0.875f),
       //     new Vector2(0.125f,0.875f),
       //     new Vector2(0.125f,0.75f),

       //     //Left
       //     new Vector2(0.375f,0.75f),
       //     new Vector2(0.375f,0.875f),
       //     new Vector2(0.25f,0.875f),
       //     new Vector2(0.25f,0.75f),

       //     //Back
       //     new Vector2(0.375f,0.75f),
       //     new Vector2(0.375f,0.875f),
       //     new Vector2(0.5f,0.875f),
       //     new Vector2(0.5f,0.75f),

       //     //Bottom
       //     new Vector2(0.25f,0.875f),
       //     new Vector2(0.25f,1),
       //     new Vector2(0.375f,1),
       //     new Vector2(0.375f,0.875f),
       //};

        m.vertices = GetCubeVertices(new Vector3(5f, 5f, 5f));
        m.triangles = GetTriangles(m.vertices);
        m.uv = GetUVArray(new Vector2(0f, 0.75f), new Vector3(0.125f, 0.125f, 0.125f));


        mf.mesh = m;
	}
	
	void Update () {
		
	}
}


/*
   Vector3[] vertices = new Vector3[]
        {
            //Front
            new Vector3(-5f, -5f, -5f),
            new Vector3(-5f, 5f, -5f),
            new Vector3(5f, 5f, -5f),
            new Vector3(5f, -5f, -5f),

            //Top
            new Vector3(-5f, 5f, -5f),
            new Vector3(-5f, 5f, 5f),
            new Vector3(5f, 5f, 5f),
            new Vector3(5f, 5f, -5f),

            //Right
            new Vector3(5f, -5f, -5f),
            new Vector3(5f, 5f, -5f),
            new Vector3(5f, 5f, 5f),
            new Vector3(5f, -5f, 5f),

            //Left
            new Vector3(-5f, -5f, 5f),
            new Vector3(-5f, 5f, 5f),
            new Vector3(-5f, 5f, -5f),
            new Vector3(-5f, -5f, -5f),

            //Back
            new Vector3(5f, 5f, 5f),
            new Vector3(5f, -5f, 5f),
            new Vector3(-5f, -5f, 5f),
            new Vector3(-5f, 5f, 5f),

            //Bottom
            new Vector3(5f, -5f, 5f),
            new Vector3(5f, -5f, -5f),
            new Vector3(-5f, -5f, -5f),
            new Vector3(-5f, -5f, 5f),
        };
     
      int[] triangles = new int[] //3의 배수로 감
        {
            //Front
            0, 1, 2, 0, 2, 3,

            //Top
            4, 5, 6, 4, 6, 7,

            //Right
            8, 9, 10, 8, 10, 11,

            //Left
            12, 13, 14, 12, 14, 15,

            //Back
            16, 18, 17, 16, 19, 18,

            //Bottom
            20, 22, 21, 20, 23, 22
        };
     */
