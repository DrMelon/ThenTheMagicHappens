using UnityEngine;
using System.Collections;

public class ControlsSys : MonoBehaviour {

	public static int keyValue;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
				//DEBUG MOVEMENT CODE 
				if (this.gameObject.tag == "DarkPlayer") {
						if (Input.GetKey ("left")) {
						transform.Translate (Vector2.right * 1 * Time.deltaTime);
							}
						if (Input.GetKey ("right")) {
						transform.Translate (Vector2.right * -1 * Time.deltaTime);
							}
						if (Input.GetKey ("up")) {
						transform.Translate (Vector2.up * -1 * Time.deltaTime);
							}
						if (Input.GetKey ("down")) {
						transform.Translate (Vector2.up * 1 * Time.deltaTime);
						}
                        if (Input.GetKey("space"))
                        {
                        }
						
				}
				if (this.gameObject.tag == "LightPlayer") {
						if (Input.GetKey ("a")) {
						transform.Translate (Vector2.right * 1 * Time.deltaTime);
							}
						if (Input.GetKey ("d")) {
						transform.Translate (Vector2.right * -1 * Time.deltaTime);
							}
						if (Input.GetKey ("s")) {
						transform.Translate (Vector2.up * -1 * Time.deltaTime);
						}
						if (Input.GetKey ("w")) {
						transform.Translate (Vector2.up * 1 * Time.deltaTime);
						}
				}
		}
}
