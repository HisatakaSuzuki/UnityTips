using UnityEngine;
using System.Collections;

public class vectors : MonoBehaviour {
	public static Vector3[] directions = new Vector3[]{
		Vector3.forward, Vector3.left,Vector3.right, 
		Vector3.back, Vector3.up, Vector3.down
	};
	public static int num = 0;
	public static string[] vecs = new string[]{
		"Vector3.forward", "Vector3.left", "Vector3.right", 
		"Vector3.back", "Vector3.up", "Vector3.down"
	};

	public static void increment(){
		if(num < 5){
			num++;
		}else{
			num = 0;
		}
	}

	public static void showDebug(){
		GUI.Label(new Rect(0,0,500,500),vecs[num] + " : " + directions[num]);
	}
}
