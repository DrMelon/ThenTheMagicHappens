using UnityEngine;
using System.Collections;

public class HealthSys : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Col)
		{
			
 				if (Col.gameObject.tag == "DarkPlayer")
			    	{
				print ("health");
				GameVariables.darkWizHealth -= 20;
		     	Destroy (gameObject);
				}else
				if (Col.gameObject.tag == "LightPlayer")
					{
					GameVariables.darkWizHealth -= 1;
			
				}
			
					
			
		}

	}
