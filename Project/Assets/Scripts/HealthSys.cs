using UnityEngine;
using System.Collections;

public class HealthSys : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Col)
		{
			if (Col.gameObject.tag == "Magic")//Update tag in relation to magic 
			{
				if (this.gameObject.tag == "DarkPlayer")
			    	{
					GameVariables.lightWizHealth -= 1;
				}else
				if (this.gameObject.tag == "LightPlayer")
					{
					GameVariables.darkWizHealth -= 1;
			
				}
			}
					
			
		}

	}
