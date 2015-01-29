using UnityEngine;
using System.Collections;

public class HealthSys : MonoBehaviour {

	public int power;

	void OnCollisionEnter2D(Collision2D Col)
		{
			
 				if (Col.gameObject.tag == "DarkPlayer")
			    	{
				print ("black");
				GameVariables.darkWizHealth -= power;
		     	Destroy (gameObject);
				}else
				if (Col.gameObject.tag == "LightPlayer")
					{
					GameVariables.lightWizHealth -= power;
			print ("white");
					Destroy (gameObject);
				}
			
					
			
		}

	}
