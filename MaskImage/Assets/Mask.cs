using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour {
	public Texture2D main;
	public Texture2D back;
	public Texture2D mask;
	public Material mat;
	public Rect scRect;

	// Use this for initialization
	void Start () {
		scRect = new Rect (0, 0, Screen.width, Screen.height);
		mat.SetTexture ("_MainTex", main);
		mat.SetTexture ("_BackTex", back);
		mat.SetTexture ("_MaskTex", mask);

		Debug.Log (main.width + "," + main.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		if (Event.current.type == EventType.Repaint) {
			Graphics.DrawTexture(scRect,main,mat);
		}
	}
}
