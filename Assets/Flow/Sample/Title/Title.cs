using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : FlowProc {

	// Use this for initialization
/*	void Start () {
		
	}
*/	
	// Update is called once per frame
/*	void Update () {
		
	}
	*/
	protected override void initFlow()
	{
		setNextStep(init);
	}


	Text textCountDown;
	int countSeconds = 3;

	void updateCount(int sec)
	{
		if(textCountDown == null) return;

		textCountDown.text = sec.ToString();
	}

	private void init()
	{
		var fader = Fader.getFader();
		fader.fadeIn();

		var obj = GameObject.Find("TextCountDown");
		textCountDown = obj.GetComponent<Text>();

		setNextStep(update);
	}

	private void update()
	{
		Debug.Log("シーン更新");
		StartCoroutine(wait());
		setNextStep(fadeOut);
		//setNextStep(close, true);	//	同じフレーム内で連続して処理を呼び出す
	}

	bool isWaiting;
	IEnumerator wait()
	{
		isWaiting = true;
		for(var i = 0; i < countSeconds; i++)
		{
			updateCount(countSeconds - i);
			yield return new WaitForSeconds(1);
		}
		isWaiting = false;
	}

	private void fadeOut()
	{
		if(isWaiting) return;

		Fader.getFader().fadeOut();
		setNextStep(close);
	}

	private void close()
	{
		if(Fader.getFader().isFading()) return;

		SceneChanger.getSceneManager().setNextSceneName("Main");

		Debug.Log("シーン終了");
		endFlow();
	}
}
