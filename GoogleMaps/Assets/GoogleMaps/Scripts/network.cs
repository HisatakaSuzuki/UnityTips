using UnityEngine;
using System.Collections;

public class network : MonoBehaviour {

	public string url = "http://crazydada.com/";
	public Texture2D tex = new Texture2D(1920,1080);
	//Material material;
	// Use this for initialization
	IEnumerator Download() {
		WWW www = new WWW("http://stat.ameba.jp/user_images/20130405/20/lelouch2937/1d/56/j/o0480048012489166876.jpg");
		yield return www;
		Debug.Log ("assetBundle:"+www.assetBundle);
		//Debug.Log ("audioClip:"+www.audioClip);
		Debug.Log ("bytes:"+www.bytes);
		Debug.Log ("bytesDownloaded:"+www.bytesDownloaded);
		Debug.Log ("error:"+www.error);
		Debug.Log ("isDone:"+www.isDone);
		//Debug.Log ("movie:"+www.movie);
		Debug.Log ("progress:"+www.progress);
		Debug.Log ("text:"+www.text);
		Debug.Log ("texture:"+www.texture);
		Debug.Log ("textureNonReadable:"+www.textureNonReadable);
		Debug.Log ("threadPriority:"+www.threadPriority);
		Debug.Log ("uploadProgress:"+www.uploadProgress);
		Debug.Log ("url:"+www.url);
		tex.LoadImage(www.bytes);
		material.mainTexture = tex as Texture;
	}


	void Start () {
		StartCoroutine (Download());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
