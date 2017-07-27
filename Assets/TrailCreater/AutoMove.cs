using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoMove : MonoBehaviour {
	public float speed=1;
	public Transform exitend;
	public GameObject trail;
	Vector3 lastpos;

	float interval=1f;
	float timer=0f;

	// Use this for initialization
	void Start () {
		lastpos = exitend.position;
		timer=0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate( Vector3.forward * Time.deltaTime * speed);
		timer += Time.deltaTime;
		if(Input.GetAxis("Horizontal") != 0f){
			transform.Translate( Vector3.right* Input.GetAxis("Horizontal"));
		}
		if(timer>= interval){
			timer =0;
			GenerateTrail();
		}
	}

	Vector3 startpos,endpos;

	void GenerateTrail(){
		startpos = lastpos;
		endpos = exitend.position;

		trail = null;
		trail = new GameObject();
		trail.AddComponent<MeshFilter>();
		trail.AddComponent<MeshRenderer>();
		MeshGeneration();
		lastpos = endpos;
	}

	#region MeshGeneration
	List<Vector3> vertices;
	List<int> triangles;
	List<Vector3> normals;
	List<Vector2> uvmapping;
	
	void MeshGeneration(){
		vertices = new List<Vector3>();
		normals = new List<Vector3>();
		uvmapping = new List<Vector2>();
		triangles = new List<int>();
		
		Mesh mesh = new Mesh();
		trail.GetComponent<MeshFilter>().mesh = mesh;
		
		//Adding Vertices
		vertices.Add( startpos + Vector3.left *0.1f+ Vector3.up);
		vertices.Add( startpos + Vector3.right*0.1f + Vector3.up);
		vertices.Add( startpos + Vector3.right *0.1f+ Vector3.down);
		vertices.Add( startpos + Vector3.left *0.1f+ Vector3.down);
		
		vertices.Add( endpos + Vector3.left *0.1f+ Vector3.up);
		vertices.Add( endpos + Vector3.right *0.1f+ Vector3.up);
		vertices.Add( endpos + Vector3.right *0.1f+ Vector3.down);
		vertices.Add( endpos + Vector3.left *0.1f+ Vector3.down);
		mesh.vertices = vertices.ToArray();
		
		//Adding Triangles
		//Order vertices in counter clock wise from visible
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

		trail.GetComponent<MeshRenderer>().material.color = Color.red;
	} 
	

	#endregion
}

