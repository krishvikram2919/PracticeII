using UnityEngine;
using System.Collections;

namespace Voronoi{
	public class VSet{
		public Vector3 point;
		public Color color;
		public float lifetime;
	}
	public class Player : MonoBehaviour {
		public VoronoiRandom voronoi;

		Rigidbody rigidbody;
		Vector3 velocity;
		
		void Start () {
			rigidbody = GetComponent<Rigidbody> ();
		}
		
		void Update () {
			velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"),0).normalized * 10;
			if( Input.GetKeyUp(KeyCode.H) ){
				voronoi.length++;
				voronoi.points.Add( new Vector2(transform.localPosition.x,transform.localPosition.z));
				if(voronoi.points.Count%2 ==0)
					voronoi.colours.Add( Color.white);
				else
					voronoi.colours.Add( Color.blue);
				voronoi.Start();
			}
		}
		
		void FixedUpdate() {
			rigidbody.MovePosition (rigidbody.position + velocity * Time.fixedDeltaTime);
		}
	}


}
