using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {


	static Fader fader = null;

	public static Fader getFader()
	{
		return fader;
	}

	Color sourceColor;
	Color targetColor;
	float rate;
	bool isFadeing;

	Image fadePlane;

	// Use this for initialization
	void Start () {
		fader = this;

		rate = 0;
		sourceColor = new Color(0, 0, 0, 1);
		targetColor = new Color(0, 0, 0, 0);

		isFadeing = false;

		fadePlane = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(fadePlane != null)
		{
			Color color = (targetColor - sourceColor) * rate + sourceColor;
			fadePlane.color = color;
		}

		if(isFadeing)
		{
			rate += 0.05f;
			if(rate >= 1.0f)
			{
				isFadeing = false;
				rate = 0;
				sourceColor = targetColor;
			}
		}

	}

	public bool isFading()
	{
		return isFadeing;
	}

	public void fadeIn()
	{
		targetColor.a = 0;
		rate = 0;
		isFadeing = true;
	}

	public void fadeOut()
	{
		targetColor.a = 1;
		rate = 0;
		isFadeing = true;
	}

}
