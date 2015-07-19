﻿//-----------------------------------------------------------------
// This script handles the layer settings window.
// At the moment all changes are aplied instantly. Maybe add a
// preview and make changes cancelable
//-----------------------------------------------------------------

using UnityEngine;
using UnityEditor;

public class UPALayerSettings : EditorWindow {
	
	public static UPALayerSettings window;
	
	public UPALayer layer;
	
	private string name;

	public static void Init (UPALayer layer) {
		// Get existing open window or if none, make new one
		window = (UPALayerSettings)EditorWindow.GetWindow (typeof (UPALayerSettings));
		window.title = layer.name + " - Settings";
		
		window.position = new Rect(Screen.width/2 + 260/2f,Screen.height/2 - 80, 360, 170);
		window.ShowPopup();
		
		window.layer = layer;
	}
	
	void OnGUI () {
		// Edit name and visibility
		GUILayout.Label ("General", EditorStyles.boldLabel);
		layer.name = EditorGUILayout.TextField ("Name: ", layer.name);
		layer.enabled = EditorGUILayout.Toggle ("Visible: ", layer.enabled);
		//exportImg = (UPAImage)EditorGUILayout.ObjectField (exportImg, typeof(UPAImage), false);

		// Edit blend mode and opacity
		GUILayout.Label ("Blending", EditorStyles.boldLabel);
		layer.mode = (UPALayer.BlendMode) EditorGUILayout.EnumPopup ("Mode: ", layer.mode);
		layer.opacity = EditorGUILayout.IntSlider ("Opacity: ", Mathf.RoundToInt(layer.opacity * 100), 0, 100) / 100f;
	}
}