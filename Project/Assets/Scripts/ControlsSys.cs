 using UnityEngine;
using System.Collections;

public class ControlsSys : MonoBehaviour {

	public int keyValue;
	//SPELLS TO CAST
	public GameObject _1STMagic;
	public GameObject _2NDMagic;
	public GameObject _3RDMagic;
	public GameObject _4THMagic;
	public GameObject _5THMagic;
	public GameObject _6THMagic;
	public GameObject _7THMagic;
	public GameObject _8THMagic;
	public GameObject _9THMagic;
	public GameObject _10THMagic;

	public Transform magicSpawn;
	public float nextCastDark;
	public float refireValueDark;
	public float nextCastLight;
	public float refireValueLight;
	public float lightSpellID = 0;
	public float darkSpellID=0 ;
	public float playerSpeed;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
				//DEBUG MOVEMENT CODE 
				if (this.gameObject.tag == "DarkPlayer") {
						if (Input.GetKey ("left")) {
								transform.Translate (Vector2.right * playerSpeed * Time.deltaTime);
						}
						if (Input.GetKey ("right")) {
								transform.Translate (Vector2.right * -playerSpeed * Time.deltaTime);
						}
						if (Input.GetKey ("up")) {
								transform.Translate (Vector2.up * playerSpeed * Time.deltaTime);
						}
						if (Input.GetKey ("down")) {
								transform.Translate (Vector2.up * -playerSpeed * Time.deltaTime);
						}
						if (Input.GetKey ("m") && Time.time > nextCastDark) {
								nextCastDark = Time.time + refireValueDark;
								darkSpellID = GetComponent<ComboBase> ().CastSpell ();

								if (darkSpellID == 0)						
										Instantiate (_1STMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 1)
										Instantiate (_2NDMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 2)						
										Instantiate (_3RDMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 3)
										Instantiate (_4THMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 4)						
										Instantiate (_5THMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 5)
										Instantiate (_6THMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 6)						
										Instantiate (_7THMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 7)
										Instantiate (_8THMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 8)						
										Instantiate (_9THMagic, magicSpawn.position, magicSpawn.rotation);
								if (darkSpellID == 9)
										Instantiate (_10THMagic, magicSpawn.position, magicSpawn.rotation);

						
						}
				}
				if (this.gameObject.tag == "LightPlayer") {
						if (Input.GetKey ("a")) {
				transform.Translate (Vector2.right * -playerSpeed * Time.deltaTime);
							}
						if (Input.GetKey ("d")) {
				transform.Translate (Vector2.right * playerSpeed * Time.deltaTime);
							}
						if (Input.GetKey ("s")) {
				transform.Translate (Vector2.up * -playerSpeed * Time.deltaTime);
						}
						if (Input.GetKey ("w")) {
				transform.Translate (Vector2.up * playerSpeed * Time.deltaTime);
						}
						if (Input.GetKey ("space") && Time.time > nextCastLight) {
						nextCastLight = Time.time + refireValueLight;

						lightSpellID = GetComponent<ComboBase>().CastSpell();
				
					if (lightSpellID == 0)						
						Instantiate (_1STMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 1)
						Instantiate (_2NDMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 2)						
						Instantiate (_3RDMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 3)
						Instantiate (_4THMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 4)						
						Instantiate (_5THMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 5)
						Instantiate (_6THMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 6)						
						Instantiate (_7THMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 7)
						Instantiate (_8THMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 8)						
						Instantiate (_9THMagic, magicSpawn.position, magicSpawn.rotation);
					if (lightSpellID == 9)
						Instantiate (_10THMagic, magicSpawn.position, magicSpawn.rotation);

						}
				}
		}
}
