 using UnityEngine;
using System.Collections;

public class ControlsSys : MonoBehaviour {

	public int keyValue;
	public GameObject fireMagic;
	public GameObject waterMagic;

	public Transform magicSpawn;
	public float nextCastDark;
	public float refireValueDark;
	public float nextCastLight;
	public float refireValueLight;
	public float lightSpellID;
	public float darkSpellID;


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

						if (Input.GetKey ("m") && Time.time > nextCastDark) {
						nextCastDark = Time.time + refireValueDark;
							darkSpellID = GetComponent<ComboBase>().CastSpell();

						if (darkSpellID == 1)						
								Instantiate (fireMagic, magicSpawn.position, magicSpawn.rotation);
						if (darkSpellID == 2)
								Instantiate (waterMagic, magicSpawn.position, magicSpawn.rotation);
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
						if (Input.GetKey ("space") && Time.time > nextCastLight) {
						nextCastLight = Time.time + refireValueLight;

						lightSpellID = GetComponent<ComboBase>().CastSpell();
				
						if (lightSpellID == 1)						
							Instantiate (fireMagic, magicSpawn.position, magicSpawn.rotation);
						if (lightSpellID == 2)
							Instantiate (waterMagic, magicSpawn.position, magicSpawn.rotation);
						}
				}
		}
}
