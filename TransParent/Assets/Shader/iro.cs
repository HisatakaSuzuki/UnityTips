using UnityEngine;
using System.Collections;

public class iro : MonoBehaviour {
	Texture2D tex = new Texture2D(256,256);
	// Use this for initialization
	void Start () {
		tex.filterMode = FilterMode.Point;
		this.renderer.material.SetColor ("_MaskColoc", Color.black);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
