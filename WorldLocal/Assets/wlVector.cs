using UnityEngine;
using System.Collections;

public class wlVector : MonoBehaviour {
	Vector3 vector;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		vector = transform.TransformVector (vectors.directions[vectors.num]);
		Debug.DrawLine (transform.position, vector, Color.green);
		Debug.Log (vector);
		
		//表示するdirectionを繰り上げる
		if (Input.GetKeyDown (KeyCode.Space)) {
			vectors.increment ();
		}
	}

	void OnGUI(){
		vectors.showDebug ();
	}
}
