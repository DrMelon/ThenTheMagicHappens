﻿using UnityEngine;
using System.Collections;

public class HealthBarLogic : MonoBehaviour {

	public int currentDarkHealth;
	public int currentDarkMana;
	public int currentLightHealth;
	public int currentlightMana;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
		currentDarkHealth = GameVariables.darkWizHealth;
		currentLightHealth = GameVariables.lightWizHealth;
		currentDarkMana = GameVariables.darkWizMana;
		currentlightMana= GameVariables.lightWizMana;

		if (currentDarkHealth <  100)
			{
				var bar90 = GameObject.Find ("100%BarDH");
				Destroy (bar90);
			}
				
		if (currentDarkHealth <  90)
			{
				var bar90 = GameObject.Find ("90%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  80)
			{
				var bar90 = GameObject.Find ("80%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  70)
			{
				var bar90 = GameObject.Find ("70%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  60)
			{
				var bar90 = GameObject.Find ("60%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  50)
			{
				var bar90 = GameObject.Find ("50%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  40)
			{
				var bar90 = GameObject.Find ("40%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  30)
			{
				var bar90 = GameObject.Find ("30%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  20)
			{
				var bar90 = GameObject.Find ("20%BarDH");
				Destroy (bar90);
			}
		if (currentDarkHealth <  10)
			{
				var bar90 = GameObject.Find ("10%BarDH");
				Destroy (bar90);
			}

		if (currentDarkMana <  100)
		{
			var bar90 = GameObject.Find ("100%BarDM");
			Destroy (bar90);
		}
		
		if (currentDarkMana <  90)
		{
			var bar90 = GameObject.Find ("90%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  80)
		{
			var bar90 = GameObject.Find ("80%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  70)
		{
			var bar90 = GameObject.Find ("70%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  60)
		{
			var bar90 = GameObject.Find ("60%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  50)
		{
			var bar90 = GameObject.Find ("50%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  40)
		{
			var bar90 = GameObject.Find ("40%BarDH");
			Destroy (bar90);
		}
		if (currentDarkMana <  30)
		{
			var bar90 = GameObject.Find ("30%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  20)
		{
			var bar90 = GameObject.Find ("20%BarDM");
			Destroy (bar90);
		}
		if (currentDarkMana <  10)
		{
			var bar90 = GameObject.Find ("10%BarDM");
			Destroy (bar90);
		}


		if (currentLightHealth <  100)
		{
			var bar90 = GameObject.Find ("100%BarLH");
			Destroy (bar90);
		}
		
		if (currentLightHealth <  90)
		{
			var bar90 = GameObject.Find ("90%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  80)
		{
			var bar90 = GameObject.Find ("80%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  70)
		{
			var bar90 = GameObject.Find ("70%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  60)
		{
			var bar90 = GameObject.Find ("60%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  50)
		{
			var bar90 = GameObject.Find ("50%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  40)
		{
			var bar90 = GameObject.Find ("40%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  30)
		{
			var bar90 = GameObject.Find ("30%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  20)
		{
			var bar90 = GameObject.Find ("20%BarLH");
			Destroy (bar90);
		}
		if (currentLightHealth <  10)
		{
			var bar90 = GameObject.Find ("10%BarLH");
			Destroy (bar90);
		}

}




	}


