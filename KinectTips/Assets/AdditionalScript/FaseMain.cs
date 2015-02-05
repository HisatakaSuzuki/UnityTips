using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

//フェーズメイン
public class FaseMain : MonoBehaviour {

	[DllImport("user32.dll")]
	private extern static void keybd_event(//宣言
	                                       byte bVk,               // 仮想キーコード
	                                       byte bScan,             // ハードウェアスキャンコード
	                                       long dwFlags,          // 関数のオプション
	                                       long dwExtraInfo   // 追加のキーストロークデータ
	                                       );
	
	[SerializeField]

	/*int fase = 0;//現在のフェーズ
	int faseCopy = 0;//１つ前のフェーズ受け取り
	int rememberFase = 0; */
	float level = 0.8f;//閾値変更
	/*float time = 0;//秒数
	//int timeLevel = 10; //timeの閾値
	int Score = 0;//スコアを受けとる*/
	[SerializeField]
	private GameObject[]
	Bones = new GameObject[20];//現在のボーン情報取得
	private Vector3[,] 
	BonesSave = new Vector3[6, 20];//CSVファイルから読み込んだ値を格納

	int savenum = 0;
	
	//DepthCheck depth;

	void Start () {
		Debug.Log("0");
		//Save.ReadFile (ref BonesSave);
		//depth = gameObject.GetComponent<DepthCheck>();
	}

	void Update () {

		//Debug.Log (time);
		//time += Time.deltaTime;
		//test
		//if(Input.GetKeyDown(KeyCode.F12)){
	//		kinectW.depth ();
			//Debug.Log(depth.checkPlayer());
		//}

		//CSVファイルにセーブするとき使用,使わないときコメントアウトする
		if (Input.GetKeyDown (KeyCode.A)) {
			for (int i = 0; i < Bones.Length; i++) {
				Debug.Log ("Saveしてます:(" + Bones [i].transform.localPosition.x + "," + Bones [i].transform.localPosition.y + "," + Bones [i].transform.localPosition.z + ")");
				Save.LogSave (Bones [i].transform.localPosition.x, Bones [i].transform.localPosition.y, Bones [i].transform.localPosition.z,savenum);
			}
			savenum++;
		}//ここまで

//		if(MathFuncs.Dot (7, 5, 0, Bones, BonesSave) >= level ){
//			Debug.Log ("成功！");
//		}else{
//			Debug.Log("失敗！");
//		}

		/*switch (fase) {

			case 0://Demo画面{

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;
					
					//Demo画面表示
					gameObject.SendMessage ("setFadeEff", 5);
					gameObject.SendMessage ("changeContent", 6);
					keybd_event((byte)0x4F, (byte)0, (long)0, (long)0);//O

					Debug.Log ("fase0");
					
				}
				
				if (time > 10) {//後で差しかえ
					gameObject.SendMessage ("playSE", 1);
					fase = 1;
					
				}

				
						break;
		
			case 1://Title1

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time=0;
					//Title1画面表示
					gameObject.SendMessage ("changeContent", 1);
					gameObject.SendMessage ("playVE", 1);
					Debug.Log ("fase1");
				}

		
				if (time > 9) {
						fase = 2;
				}
	

				if(Input.GetKeyDown (KeyCode.L)){
					//人が認識されてないと
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}

				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}

			
						break;

			case 2://Title2_1
				
				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;
					//Title2_1画面表示
					
					gameObject.SendMessage ("playVE", 2);
					Debug.Log ("fase2");
				}

				

				if (time > 17) {
					//各ポーズの判定で使う
					//case2,4,6,8に同様に記述する
					if(MathFuncs.Dot (7, 5, 0, Bones, BonesSave) >= level && MathFuncs.Dot (11, 9, 0, Bones, BonesSave) >= level
					   && MathFuncs.Dot (9, 8, 0, Bones, BonesSave) >= level && MathFuncs.Dot (5, 4, 0, Bones, BonesSave) >= level){
						gameObject.SendMessage ("playSE", 2);
						Score = 1;
					}
					fase = 3;
				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}

								break;
		
			case 3://Titlle2_2

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;

					//Title2_2画面表示
					gameObject.SendMessage ("setFadeEff", 1);
					gameObject.SendMessage ("changeContent", 2);
					gameObject.SendMessage ("playVE", 3);
					keybd_event((byte)0x50, (byte)0, (long)0, (long)0);	//p

					Debug.Log ("fase3");
				}

				if (time > 4) {

					fase = 4;
					
				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}

						break;
		
			case 4://Game1_1
				
				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;

					//Game1_1画面表示
				    gameObject.SendMessage ("playVE", 4);

					Debug.Log ("fase4");
				}
				
				if (time > 34) {
					//各ポーズの判定で使う
					//case2,4,6,8に同様に記述する
					if(MathFuncs.Dot (7, 5, 1, Bones, BonesSave) >= level && MathFuncs.Dot (11, 9, 1, Bones, BonesSave) >= level
					   && MathFuncs.Dot (9, 8, 1, Bones, BonesSave) >= level && MathFuncs.Dot (5, 4, 1, Bones, BonesSave) >= level){
						gameObject.SendMessage ("playSE", 3);
						Score = 2;
						
					}
					fase = 5;
				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}

						break;

			case 5://Game1_2

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;
					
					//Game1_2画面表示
					gameObject.SendMessage ("setFadeEff", 2);
					gameObject.SendMessage ("changeContent", 3);
					gameObject.SendMessage ("playVE", 5);
					keybd_event((byte)0x51, (byte)0, (long)0, (long)0);
					
					Debug.Log ("fase5");
				}
				
				if (time > 10) {
					
					fase = 6;

				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}

						break;

			case 6://Game2_1

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;

					//Game2_1画面表示
					gameObject.SendMessage ("playVE", 6);
					Debug.Log ("fase6");
				}
				
				

				if (time > 22) {
					if(MathFuncs.Dot (7, 5, 2, Bones, BonesSave) >= level && MathFuncs.Dot (11, 9, 2, Bones, BonesSave) >= level
					   && MathFuncs.Dot (9, 8, 2, Bones, BonesSave) >= level && MathFuncs.Dot (5, 4, 2, Bones, BonesSave) >= level){
						gameObject.SendMessage ("playSE", 4);
						Score = 3;
					}
					fase = 7;
				}
				
				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}
						break;
			
			case 7://Game2_2

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;

					//Game2_2画面表示
					gameObject.SendMessage ("setFadeEff", 3);
					gameObject.SendMessage ("changeContent", 4);
					gameObject.SendMessage ("playVE", 7);
					keybd_event((byte)0x52, (byte)0, (long)0, (long)0);//R

					Debug.Log ("fase7");
				}
				
				if (time > 13) {
					
					fase = 8;
				
				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}

						break;
			
			case 8://Game3_1

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;
					
					//Game3_1画面表示
					gameObject.SendMessage ("playVE", 8);
					Debug.Log ("fase8");
				}
				
				if (time > 26) {
					if(MathFuncs.Dot (7, 5, 3, Bones, BonesSave) >= level && MathFuncs.Dot (11, 9, 3, Bones, BonesSave) >= level
					   && MathFuncs.Dot (9, 8, 3, Bones, BonesSave) >= level && MathFuncs.Dot (5, 4, 3, Bones, BonesSave) >= level){
						gameObject.SendMessage ("playSE", 5);
						Score = 4;
					}
					fase = 9;
				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}
						break;
			
			case 9://Game3_2

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;

					//Game3_2画面表示
					gameObject.SendMessage ("setFadeEff", 4);
					gameObject.SendMessage ("changeContent", 5);
					//スコアでVoice変わる
					if(Score >= 3){
						gameObject.SendMessage ("playVE", 9);
					}else{
						gameObject.SendMessage ("playVE", 10);
					}
					keybd_event((byte)0x53, (byte)0, (long)0, (long)0);
					Score = 0;
					Debug.Log ("fase9");
				}
				
				if (time > 10) {
					
					fase = 10;
				}
			

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}
						break;

			case 10://End

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					rememberFase = fase;
					time = 0;

					gameObject.SendMessage ("playVE", 11);
					Debug.Log ("fase10");
				}

				if (time > 8) {						
					fase = 0;
				}

				if(Input.GetKeyDown (KeyCode.L)){//20秒後
					
					fase = 11;
					
				}

				if(Input.GetKeyDown (KeyCode.M)){ //1から10まで同じように記述キー操作は差し替え
					//近づきすぎるとcase12へ移行
					fase = 12;
				}
				
				if(Input.GetKeyDown (KeyCode.N)){
					//Kinect団子状態case14へ移行
					fase = 14;
				}
						break;
			
			case 11://Empty

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					time = 0;

					//警告（画面,Voice)
					gameObject.SendMessage ("playVE", 12);
					Debug.Log ("fase11");
				}
				
				

				//人を認識したら前のcaseに戻る
				if(Input.GetKeyDown (KeyCode.X)){
					fase = rememberFase;
				}

				if (time > 10) {
						fase = 13;
				}
						break;
			
			case 12://Near

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					time = 0;

					//警告（画面,Voice)近すぎます
					gameObject.SendMessage ("playVE", 13);
					Debug.Log ("fase12");
				}

				
				//体験者が離れると前のcaseに戻る
				if(Input.GetKeyDown (KeyCode.Y)){
					fase = rememberFase;
				}

				if (time > 10) {
					fase = 13;
				}
						break;
			
			case 13://Shame

				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					time = 0;
					
					//警告（画面,Voice)ミッション失敗
					gameObject.SendMessage ("playVE", 14);

					Debug.Log ("fase13");
				}

				if (time > 13) {
					fase = 0;
				}
						break;
			
			case 14://KinectError
				if(faseCopy != fase){//最初の一回だけ実行
					faseCopy = fase;
					time = 0;

					//KinectError警告（画面,Voice)団子状態です
					gameObject.SendMessage ("playVE", 15);
					Debug.Log ("fase14");
				}

				
				//団子状態解消後,前のcaseに戻る
				if(Input.GetKeyDown (KeyCode.Z)){
					fase = rememberFase;
				}

				if (time > 8) {
					fase = 13;

				}
						break;
		

			default:

						break;
		}*/



		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
			
	}
		
}

