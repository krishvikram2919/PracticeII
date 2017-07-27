using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class PyramidGenerator : MonoBehaviour {

	//Spec
	public Vector3 position, rotation;
	public float height;
	[Range(1,20)]
	public float size;

	public bool randomlyGenerate;

	//Derivatives
	public Vector3[] corners;

	void Start () {
		GeneratePyramid();
	}
	
	public void GeneratePyramid () {
		corners = new Vector3[5];
		if(randomlyGenerate){
			position.x = 0;//Random.Range(-100,100);
			position.y = 0;
			position.z = 0;//Random.Range(-100,100);

			rotation.y = Random.Range(-100,100);
			rotation.y = 0f;
			rotation.z = 0f;

			height = Random.Range(5f,20f);
			size = Random.Range(5f,10f);
		}

		corners[0].x = position.x - size;
		corners[0].y = position.y;
		corners[0].z = position.z - size;
		
		corners[1].x = position.x + size;
		corners[1].y = position.y;
		corners[1].z = position.z - size;

		corners[2].x = position.x + size;
		corners[2].y = position.y;
		corners[2].z = position.z + size;

		corners[3].x = position.x - size;
		corners[3].y = position.y;		
		corners[3].z = position.z + size;

		corners[4].x = position.x;
		corners[4].y = position.y + height;
		corners[4].z = position.z;
		MeshGeneration();

	}

	public void SavePyramid(){

		if (mesh)
		{
			var savePath = "Assets/" + "Pyramid" + ".asset";
			Debug.Log("Saved Mesh to:" + savePath);
			AssetDatabase.CreateAsset(mesh, savePath);
		}

		//AssetDatabase.AddObjectToAsset (mesh, "pyramid.fbx");
		AssetDatabase.SaveAssets();
	}
	#region MeshGeneration
	List<Vector3> vertices;
	List<int> triangles;
	List<Vector3> normals;
	List<Vector2> uvmapping;
	Mesh mesh;
	void MeshGeneration(){
		vertices = new List<Vector3>();
		normals = new List<Vector3>();
		uvmapping = new List<Vector2>();
		triangles = new List<int>();
		
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		//Adding Vertices
		vertices.Add( corners[0] );
		vertices.Add( corners[1] );
		vertices.Add( corners[2] );
		vertices.Add( corners[3] );
		vertices.Add( corners[4]);
		mesh.vertices = vertices.ToArray();

		//Adding Triangles
		//Order vertices in counter clock wise from visible
		triangles.Add(4);
		triangles.Add(1);
		triangles.Add(0);

		triangles.Add(4);
		triangles.Add(2);
		triangles.Add(1);

		triangles.Add(4);
		triangles.Add(3);
		triangles.Add(2);

		triangles.Add(4);
		triangles.Add(0);
		triangles.Add(3);

		triangles.Add(2);
		triangles.Add(3);
		triangles.Add(0);

		triangles.Add(0);
		triangles.Add(1);
		triangles.Add(2);
		mesh.triangles = triangles.ToArray();

		//Adding Normals
		mesh.RecalculateNormals();
	} 
	
	/*
	void MeshGeneration(){
		vertices = new List<Vector3>();
		normals = new List<Vector3>();
		uvmapping = new List<Vector2>();
		triangles = new List<int>();
		
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		//Adding Vertices
		vertices.Add( corners[0] );
		vertices.Add( corners[1] );
		vertices.Add( corners[2] );
		vertices.Add( corners[3] );
		vertices.Add( corners[0] + Vector3.up*size);
		vertices.Add( corners[1]+ Vector3.up*size );
		vertices.Add( corners[2] + Vector3.up*size );
		vertices.Add( corners[3] + Vector3.up*size );
		mesh.vertices = vertices.ToArray();

		//Adding Triangles
		//Order vertices in counter clock wise
		triangles.Add(1);
		triangles.Add(0);
		triangles.Add(4);

		triangles.Add(4);
		triangles.Add(5);
		triangles.Add(1);

		triangles.Add(5);
		triangles.Add(6);
		triangles.Add(2);
		
		triangles.Add(2);
		triangles.Add(1);
		triangles.Add(5);

		triangles.Add(6);
		triangles.Add(7);
		triangles.Add(3);
		
		triangles.Add(3);
		triangles.Add(2);
		triangles.Add(6);

		triangles.Add(7);
		triangles.Add(4);
		triangles.Add(0);
		
		triangles.Add(0);
		triangles.Add(3);
		triangles.Add(7);

		triangles.Add(6);
		triangles.Add(5);
		triangles.Add(4);
		
		triangles.Add(4);
		triangles.Add(7);
		triangles.Add(6);

		triangles.Add(0);
		triangles.Add(1);
		triangles.Add(2);
		
		triangles.Add(2);
		triangles.Add(3);
		triangles.Add(0);
		mesh.triangles = triangles.ToArray();

		//Adding Normals
		mesh.RecalculateNormals();

		//Adding Texture

	}*/
	#endregion
}
