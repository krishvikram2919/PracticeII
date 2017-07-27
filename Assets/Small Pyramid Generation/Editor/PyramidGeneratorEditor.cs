using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


[CustomEditor(typeof(PyramidGenerator))]
public class PyramidGeneratorEditor : Editor {

	public override void OnInspectorGUI ()
	{
		//base.OnInspectorGUI ();
		
		PyramidGenerator mapgen = serializedObject.targetObject as PyramidGenerator;

		mapgen.randomlyGenerate = EditorGUILayout.Toggle("Randomise",mapgen.randomlyGenerate);
		if(!mapgen.randomlyGenerate){
			mapgen.position = EditorGUILayout.Vector3Field("Position", mapgen.position);
			mapgen.rotation = EditorGUILayout.Vector3Field("Rotation", mapgen.rotation);

			mapgen.height = EditorGUILayout.FloatField("Height", mapgen.height);
			mapgen.size = EditorGUILayout.FloatField("Size", mapgen.size);
		}

		if (GUILayout.Button("Generate"))
		{
			mapgen.GeneratePyramid();
		}

		if (GUILayout.Button("Save"))
		{
			mapgen.SavePyramid();
		}
	}
}
