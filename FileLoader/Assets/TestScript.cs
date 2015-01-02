using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int[,] loadint = FileLoader.readTextAsInt ("maps_test");
		float[,] loadfloat = FileLoader.readTextAsFloat ("maps_test");
		double[,] loaddouble = FileLoader.readTextAsDouble ("maps_test");
		string[,] loadstring = FileLoader.readTextFileAsString ("maps_test");

		int len0 = loadstring.GetLength (0);
		int len1 = loadstring.GetLength (1);

		Debug.Log ("-------int---------");
		for (int i=0; i < len0; i++) {
			for(int j=0; j < len1; j++){
				Debug.Log(loadint[i,j]);
			}
		}

		Debug.Log ("-------float---------");
		for (int i=0; i < len0; i++) {
			for(int j=0; j < len1; j++){
				Debug.Log(loadfloat[i,j]);
			}
		}

		Debug.Log ("-------double---------");
		for (int i=0; i < len0; i++) {
			for(int j=0; j < len1; j++){
				Debug.Log(loaddouble[i,j]);
			}
		}

		Debug.Log ("-------string---------");
		for (int i=0; i < len0; i++) {
			for(int j=0; j < len1; j++){
				Debug.Log(loadstring[i,j]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
