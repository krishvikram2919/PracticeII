using UnityEngine;
using System.Collections;

public class ProjectileOnclick : MonoBehaviour {
	bool flgToggle=true;
	Vector3 initPos;
	Rigidbody rb;
	[SerializeField] Transform mtarget;
	[SerializeField] float _angle;
	// Use this for initialization
	void Awake () {
		initPos = transform.position;
		rb = transform.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonUp (0))
			OnMouseUp ();
	}

	void OnMouseUp(){

		if (!flgToggle)
			resetObject ();
		else
			ThrowObject ();
		flgToggle = !flgToggle;
	}

	void resetObject(){
		rb.velocity *= 0f;
		rb.useGravity = false;

		transform.position = initPos;
	}

	void ThrowObject(){
		rb.useGravity = true;

		//_angle is angle in degrees

		// source and target positions
		Vector3 pos = transform.position;
		Vector3 target = mtarget.position;
		
		// distance between target and source
		float dist = Vector3.Distance(pos, target);
		
		// rotate the object to face the target
		transform.LookAt(target);
		
		// calculate initival velocity required to land the cube on target using the formula (9)
		float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * _angle * 2)));

		float Vy, Vz;   // y,z components of the initial velocity
		
		Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * _angle);
		Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * _angle);
		
		// create the velocity vector in local space
		Vector3 localVelocity = new Vector3(0f, Vy, Vz);
		
		// transform it to global vector
		Vector3 globalVelocity = transform.TransformVector(localVelocity);
		
		// launch the cube by setting its initial velocity
		rb.velocity = globalVelocity;
	}
}
