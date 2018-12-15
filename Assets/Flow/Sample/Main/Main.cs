using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : FlowProc {
	protected override void initFlow()
	{
		Debug.Log("Main.initFlow()");
		setNextStep(init);
	}

	private void init()
	{
		Debug.Log("Main.init()");
		var fader = Fader.getFader();
		fader.fadeIn();

		setNextStep(update);
	}

	private void update()
	{
	}
}
