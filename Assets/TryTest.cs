using UnityEngine;
using System.Collections;
using System;

public class TryTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		try{
			Grandparent();
		}
		catch (Exception e){
			Debug.Log("Caught");
		}

	}
	
	// Update is called once per frame
	void Grandparent () {
	
		Father();
	}

	void Father(){
		Child();
	}

	void Child(){
		int x=0;
		throw new System.Exception("Krish");
	}
}
