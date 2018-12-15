using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	string nextSceneName;

	static SceneChanger sceneManager = null;

	static public SceneChanger getSceneManager()
	{
		return sceneManager;
	}


	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		sceneManager = this;
	}
	
	// Update is called once per frame
	void Update () {
		changeScene();
	}


	public void setNextSceneName(string name)
	{
		nextSceneName = name;
	}


	void changeScene()
	{
		if(nextSceneName != null)
		{
			SceneManager.LoadScene(nextSceneName);
			nextSceneName = null;
		}
	}
}
