using UnityEngine;
using System.Collections;

public class HealthSys : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D Col)
		{
			
 				if (Col.gameObject.tag == "DarkPlayer")
			    	{
				print ("black");
				GameVariables.darkWizHealth -= 20;
		     	Destroy (gameObject);
				}else
				if (Col.gameObject.tag == "LightPlayer")
					{
			print( Col.gameObject );
					GameVariables.lightWizHealth -= 20;
			print ("white");
					Destroy (gameObject);
				}
			
					
			
		}

	}
