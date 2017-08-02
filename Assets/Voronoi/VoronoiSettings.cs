using UnityEngine;
using System.Collections;

namespace Voronoi{

	public class VoronoiSettings:MonoBehaviour
	{
		void Awake(){
			Physics.gravity = new Vector3(0f,0f,9.81f);


		}
	}
}

