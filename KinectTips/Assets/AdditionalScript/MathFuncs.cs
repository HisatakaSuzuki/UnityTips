using UnityEngine;
using System.Collections;

//ポーズの内積情報取得
public class MathFuncs : MonoBehaviour {

	//root: 元となる関節点
	//tar : 関節点の終点
	//user: 現在のユーザーの骨格情報
	//saved: 保存されているポーズの骨格情報
	
	public static float Dot(int root,int tar, int motion, GameObject[] user, Vector3[,] saved)
	{
		Vector3 vec1, vec2;
		vec1 = new Vector3();
		vec2 = new Vector3();
		
		vec1.x = user[root].transform.position.x - user[tar].transform.position.x;
		vec1.y = user[root].transform.position.y - user[tar].transform.position.y;
		vec1.z = user[root].transform.position.z - user[tar].transform.position.z;
		
		
		vec2.x = saved[motion,root].x - saved[motion,tar].x;
		vec2.y = saved[motion,root].y - saved[motion,tar].y;
		vec2.z = saved[motion,root].z - saved[motion,tar].z;
		
		float AA, BB, AB;
		
		AA = vec1.x * vec1.x + vec1.y * vec1.y + vec1.z * vec1.z;
		BB = vec2.x * vec2.x + vec2.y * vec2.y + vec2.z * vec2.z;
		AB = vec1.x * vec2.x + vec1.y * vec2.y + vec1.z * vec2.z;
		
		return (float)(AB / (System.Math.Sqrt(AA) * System.Math.Sqrt(BB)));
	}

}
