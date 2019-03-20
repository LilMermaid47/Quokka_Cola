using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    [SerializeField]
    int nbPointX = 20;
    [SerializeField]
    int nbPointZ = 20;

    Mesh mesh;

    Vector3[] pointTriangle;
    int[] triangles;
    
    // Start is called before the first frame update
    void Build()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateTriangle();
        //CreateNewMesh();    
    }

    private void CreateTriangle()
    {
        pointTriangle = new Vector3[((nbPointX+1)*(nbPointZ+1))];
        int indice = 0;
         
        for (int z = 0; z <= nbPointZ; z++)
        {
            for (int x = 0; x <= nbPointX; x++)
            {
                pointTriangle[indice] = new Vector3(x, 0, z);
                indice++;
            }
        }

       /* triangles = new int[nbPointZ*nbPointX*6];
        int vert = 0;
        int tri = 0;
        for (int z = 0; z < nbPointZ-1; z++)
        {
            triangles[tri] = vert;
            triangles[tri+1] = vert + nbPointX;
            triangles[tri+2] = vert+1;
            triangles[tri+3] = vert+1;
            triangles[tri+4] = vert+nbPointX;
            triangles[tri+5] = vert+nbPointX+1;

            vert++;
            tri += 6;
        }*/
    }
    private void OnDrawGizmos()
    {
        if (pointTriangle == null)
            return;

        for (int i = 0; i < pointTriangle.Length; i++)
        {
            Gizmos.DrawSphere(pointTriangle[i], 0.1f);
        }
    }
    private void CreateNewMesh()
    {
        mesh.Clear();
        mesh.vertices = pointTriangle;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

}
