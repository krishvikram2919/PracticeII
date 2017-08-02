using UnityEngine;
using System.Collections;

public class Corou : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartCorou(){
		StartCoroutine( A () );
	}


	IEnumerator A(){

		Debug.Log("Enter A");
		yield return null;
		StartCoroutine( B () );
		Debug.Log("Exit A");
		
	}

	IEnumerator B(){
		
		Debug.Log("Enter B");
		yield return new WaitForSeconds(2f);
		Debug.Log("Exit B");
		
	}
}
