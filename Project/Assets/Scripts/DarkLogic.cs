using UnityEngine;
using System.Collections;

public class DarkLogic : MonoBehaviour {

	public bool is100;
	public bool is90;
	public bool is80;
	public bool is70;
	public bool is60;
	public bool is50;
	public bool is40;
	public bool is30;
	public bool is20;
	public bool is10;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	switch (GameVariables.darkWizHealth) {
				case 89:
			if (this.gameObject.gameObject.tag == "90")
			{
				Destroy(gameObject);
			}
				break;
				case 80:
			break;
				case 70:
			break;
				case 60:
			break;
				case 50:
			break;
				case 40:
			break;
				case 30:
			break;
				case 20:
			break;
				case 10:
			break;
				case 0:
			break;
	}
	}
}
