using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngineInternal;

public class TimeInspector : EditorWindow {
	public float TimeScale;
	
	[MenuItem("Editor Tools/Time Inspector", false, 100)]
	private static void Init()
	{
		TimeInspector window = (TimeInspector)EditorWindow.GetWindow(typeof(TimeInspector), false, "Custom Settings");
	}
	private void OnGUI(){
		GUILayout.Label("Custom Settings", EditorStyles.largeLabel);

		EditorGUILayout.BeginVertical(EditorStyles.inspectorDefaultMargins );
		Time.timeScale = EditorGUILayout.FloatField("TimeSpeed",Time.timeScale);
		GUILayout.Space(10f);
		if (GUILayout.Button("Reset Time"))
		{
			Time.timeScale=1f;
		}
		EditorGUILayout.EndVertical();
	}

	private void OnInspectorUpdate()
	{
		Repaint();
	}
}
