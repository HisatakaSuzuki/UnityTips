using UnityEngine;
using System.Collections;

public class OutCamera : MonoBehaviour {
	WebCamTexture webcam;
	WebCamDevice[] devices;
	string str = "";

	// Use this for initialization
	void Start () {
		devices= WebCamTexture.devices;
//		if(devices.Length > 0){
//			webcam = new WebCamTexture(devices[0].name ,Screen.width, Screen.height, 30);
//			webcam.Play();
//		}else{
//			Debug.Log("no out cam");	
//		}
	}

	void OnGUI(){
		if (webcam != null) {
			GUI.DrawTexture (new Rect (0, Screen.height / 2, Screen.width, Screen.height / 2), webcam);
		}
		if(GUI.Button(new Rect(0,Screen.height/2,250,25),"Start")){
			str = "start:";
			if(devices.Length > 0){
				webcam = new WebCamTexture(devices[0].name ,Screen.width, Screen.height, 30);
				str = devices[0].name;
				webcam.Play();
			}else{
				Debug.Log("no out cam");	
			}
		}
		GUI.TextArea (new Rect (Screen.width - 500, Screen.height / 2, 500, 50), str);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
