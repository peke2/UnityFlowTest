using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowProc : MonoBehaviour {
	protected delegate void ProcStep();
	ProcStep nextStep;
	ProcStep currentStep;

	string nextSceneName;

	bool isEnd;
	bool isContinuous;

	void Start()
	{
#if !UNITY_EDITO
		Boot.makeBaseObjects();
#endif
		nextStep = null;
		currentStep = null;
		nextSceneName = null;
		isEnd = false;

		initFlow();
	}

	void Update()
	{
		if(isEnd)
		{
			return;
		}

		//Debug.Log("更新開始");
		updateFlow();
		//Debug.Log("更新終了");
	}

	protected void setNextStep(ProcStep step, bool isCont=false)
	{
		nextStep = step;
		isContinuous = isCont;
	}


	private void applyNextStep()
	{
		isContinuous = false;
		if(nextStep == null)
		{
			return;
		}
		//	次の処理を適用
		currentStep = nextStep;
		nextStep = null;
	}

	protected void endFlow()
	{
		//	設定されているシーンがあればセット
		if(nextSceneName != null)
		{
			var fm = SceneChanger.getSceneManager();
			fm.setNextSceneName(nextSceneName);
		}
		
		//	現在の処理は無し
		currentStep = null;
		//	終了
		isEnd = true;
	}

	protected virtual void initFlow()
	{
	}

	protected void updateFlow()
	{
		do {
			applyNextStep();

			if(currentStep != null)
			{
				currentStep();
			}
		} while(isContinuous);
	}

}
