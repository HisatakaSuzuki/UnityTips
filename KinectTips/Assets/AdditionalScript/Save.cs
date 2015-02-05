using UnityEngine;
using System.Collections;
using System.IO;
using System;

//SaveとReadのクラス
public class Save : MonoBehaviour
{
		//CSVファイルにポーズ情報書き込む
		public static void LogSave (double num, double num2, double num3, int savenum)
		{
				StreamWriter sw;
				FileInfo fi;
				fi = new FileInfo (Application.dataPath + "/"+ savenum +".csv");
				sw = fi.AppendText ();
				sw.WriteLine (num + "," + num2 + "," + num3);
				sw.Flush ();
				sw.Close ();
		}

		//CSVファイルからポーズの3点の座標データを読取って,その値をVecter3型で返す.
		public static void ReadFile (ref Vector3[,] Bones)
		{
				for (int j=0; j<1; j++) {
						//ファイルパスの宣言
						FileInfo fi = new FileInfo (Application.dataPath + "/" + j + ".csv");
						//ファイル読み込み準備
						StreamReader sr = new StreamReader (fi.OpenRead ());

						//一行ずつデータを読取ってVector3型に格納
						for (int i= 0; i < 20; i++) {
								String str = sr.ReadLine ();
								Debug.Log (str);
								String[] str2 = str.Split (',');

								Vector3 point = new Vector3 ();
								point.x = float.Parse (str2 [0]);
								point.y = float.Parse (str2 [1]);
								point.z = float.Parse (str2 [2]);

								Bones [j, i] = point;
						}
						//ファイル読み込み後処理（クローズ）
						sr.Close ();
				}
		}
}
