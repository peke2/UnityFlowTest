using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class Boot {

	[RuntimeInitializeOnLoadMethod]
	static void StartUp()
	{
		Debug.Log("Boot OK");
		makeBaseObjects();
	}

	static bool isBooted = false;

	public static void makeBaseObjects()
	{
		if(isBooted) return;

		var obj = new GameObject("MainManager");
		obj.AddComponent<MainManger>();
		obj.AddComponent<SceneChanger>();

		var fader = Resources.Load<GameObject>("Fader");
		var faderObject = GameObject.Instantiate(fader);
		faderObject.transform.SetParent(obj.transform, false);

		Object.DontDestroyOnLoad(obj);

		isBooted = true;
	}
}
