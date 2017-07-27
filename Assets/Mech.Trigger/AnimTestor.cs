using UnityEngine;
using System.Collections;

public class AnimTestor : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyUp(KeyCode.Z)){
			anim.SetTrigger("Flag Z");
		}
		if(Input.GetKeyUp(KeyCode.X)){
			anim.SetTrigger("Flag X");
		}

	}
}
