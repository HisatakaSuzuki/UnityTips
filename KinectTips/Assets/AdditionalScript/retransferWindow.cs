using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;


public class retransferWindow : MonoBehaviour {

/*
	[DllImport("User32.dll")]
	private static extern bool MoveWindow(
		IntPtr hwnd,
		int x,
		int y,
		int nWidth,
		int nHeight,
		bool bRepaint
	); 
*/
	[DllImport("User32.dll")]
	private static extern IntPtr FindWindow(
		System.String className,	//検索をかけるWindowClassの名前　指定しない場合はnull
		System.String windowName	//検索をかけるWindowTitle
	);
	
	[DllImport("User32.dll")]
	private static extern long GetWindowLong(
		IntPtr	hWnd,               // ウインドウのハンドル
		int		nIndex              // 取得するデータ値のインデックス
	);
	
	[DllImport("User32.dll")]
	private static extern long SetWindowLong(
		IntPtr	hWnd,               // ウインドウのハンドル
		int		nIndex,             // 設定するデータ値のインデックス
		long	dwNewLong           // 新しい値
	);
	
	[DllImport("User32.dll")]
	private static extern bool SetWindowPos(
		IntPtr	hWnd,               // ウインドウのハンドル
//		IntPtr	hWndInsertAfter,    // 配置順序のハンドル
		int		hWndInsertAfter,    // 配置順序のハンドル
		int		X,                  // x位置
		int		Y,                  // x位置
		int		cx,                 // 幅
		int		cy,                 // 高さ
		uint	uFlags              // ウインドウ位置のオプション
	);
	
/*	[DllImport("User32.dll")]
//	private static extern bool GetWindowRect(IntPtr hwnd, UnityEngine.Rect winRect);
//	private static extern bool GetWindowRect(IntPtr hwnd, RECT winRect);
/*	[StructLayout(LayoutKind.Sequential)]
	public struct RECT{
		public int left;
		public int top;
		public int right;
		public int bottom;
	}/**/
	
	
	public string windowTitle = "AppTitle";
	public string saveFileName = "posData";
	
	private int winPosX =0;
	private int winPosY =0;
	private int winWidth =600;
	private int winHeight =800;
	private IntPtr wPtr;
//	private RECT winRect;
	// Use this for initialization
	void Start () {
		long windowStyle = 0;
		read();
		////////////////////////////////////////////
		//ウィンドウスタイルの変更                   //
		//参照：http://ahk.xrea.jp/misc/Styles.html//
		////////////////////////////////////////////
		wPtr = FindWindow(null, windowTitle);
		windowStyle = GetWindowLong(wPtr,(-16));
		windowStyle = windowStyle | ((long) 0x00000000 );	//フラグを立てるサンプル
		windowStyle = windowStyle &~((long) 0x00000000 );	//フラグを折るサンプル
		windowStyle = windowStyle &~((long) 0x00400000 );	//WS_DLGFRAME(二重境界を持ちタイトルを持たない)を折る
		windowStyle = windowStyle &~((long) 0x00800000 );	//WS_BORDER(境界を持つ)を折る

		SetWindowLong(wPtr,(-16),windowStyle);
		SetWindowPos(wPtr,0,winPosX, winPosY, winWidth, winHeight,(uint)0x60);
//		MoveWindow(wPtr, winPosX, winPosY, winWidth, winHeight, true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F5)){
			write();
		}
	}
    void write(){
//	 	GetWindowRect(wPtr, winRect);
	    FileInfo flInf = new FileInfo(Application.dataPath+"/"+saveFileName+".txt");

	     StreamWriter sw = flInf.AppendText();

	     sw.WriteLine(winPosX);
	     sw.WriteLine(winPosY);
	     sw.WriteLine(winWidth);
	     sw.WriteLine(winHeight);
	     sw.Flush();
	     sw.Close(); 
    }
 
    // 読み込み
	void read () {
	    FileInfo flInf = new FileInfo(Application.dataPath+"/"+saveFileName+".txt");
	    if (!flInf.Exists){
			write();
		}
		
		StreamReader sr = new StreamReader(flInf.OpenRead());
		winPosX = int.Parse( sr.ReadLine()) ;
		winPosY = int.Parse( sr.ReadLine()) ;
		winWidth = int.Parse( sr.ReadLine()) ;
		winHeight = int.Parse( sr.ReadLine()) ;
       sr.Close();
    }
}

