using UnityEngine;
using System.Collections;

public class TextureSize : MonoBehaviour {
	public Texture2D texture;
	public GameObject plane;
	public float aspect;
	// Use this for initialization
	void Start () {
		this.renderer.material.SetTexture (0, texture);
		//texture.Resize(texture.width, 424);
		//texture.Apply();
		//aspect = (float)(424) / texture.width;
		//plane.transform.localScale = new Vector3(1,1,aspect);
		//plane.transform.position = new Vector3 (0, -aspect, plane.transform.position.z);
		//Debug.Log (texture.width + "," + texture.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
