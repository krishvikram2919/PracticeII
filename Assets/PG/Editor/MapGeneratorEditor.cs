using UnityEditor;
using UnityEngine;
using System.Collections;


[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();

		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Update"))
		{
			MapGenerator mapgen = serializedObject.targetObject as MapGenerator;
			mapgen.GenerateMap();
		}

		EditorGUILayout.EndHorizontal();
	}
}
