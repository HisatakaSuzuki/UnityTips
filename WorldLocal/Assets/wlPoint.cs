using UnityEngine;
using System.Collections;

public class wlPoint : MonoBehaviour {
	Vector3 point;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		point = transform.TransformPoint (vectors.directions[vectors.num]);
		Debug.DrawLine (transform.position, point, Color.blue);
		Debug.Log (point);

		//表示するdirectionを繰り上げる
		if(Input.GetKeyDown(KeyCode.Space)){
			vectors.increment();
		}
	}

	void OnGUI(){
		vectors.showDebug ();
	}
}
