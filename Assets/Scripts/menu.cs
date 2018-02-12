using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	private int o_x;
	private int o_y;
	public int buttonW;
	public int buttonH;


	// Use this for initialization
	void Start () {
		buttonW = 200;
		buttonH = 150;
		o_x = Screen.width / 2 - buttonW / 2;
		o_y = Screen.height / 2 - buttonH * 2;
	}

	void OnGUI() {
		var C1 = GUI.backgroundColor;
    GUI.backgroundColor = Color.green;

		if(GUI.Button(new Rect(o_x, o_y, buttonW + 5, buttonH), "Roll a ball")) {
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(o_x, o_y + buttonH + 10, buttonW, buttonH), "Dont touch the cows")) {
			Application.LoadLevel(2);
		}
		if(GUI.Button(new Rect(o_x, o_y + buttonH * 2 + 20, buttonW, buttonH), "Exit")) {
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
	}
}
