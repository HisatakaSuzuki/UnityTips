using UnityEngine;
using System.Collections;

public class wlDirection : MonoBehaviour {
	Vector3 dir;
	//public Vector3 filter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		dir = transform.TransformDirection (vectors.directions[vectors.num]);
	//	dir = dir + filter;
		Debug.Log (dir);
		Debug.DrawLine (transform.position, dir, Color.red);

		//表示するdirectionを繰り上げる
		if(Input.GetKeyDown(KeyCode.Space)){
			vectors.increment();
		}
	}

	void OnGUI(){
		vectors.showDebug ();
	}
}
