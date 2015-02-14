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

    public int Player = 0;
    public Gestures GestureManager;

    public Vector2 MinPosition;
    public Vector2 MaxPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {
        //DEBUG MOVEMENT CODE 
        if (this.gameObject.tag == "DarkPlayer")
        {
            if (Input.GetKey("left"))
            {
                transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("right"))
            {
                transform.Translate(Vector2.right * -playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("up"))
            {
                transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(Vector2.up * -playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("n"))
            {
                GestureManager.Player_Cast[Player] = true;
            }

            if (GestureManager.Player_Cast[Player] && Player == 0)
            {
                GestureManager.Player_Cast[Player] = false;
                if (Time.time > nextCastDark)
                {
                    nextCastDark = Time.time + refireValueDark;
                    darkSpellID = GetComponent<ComboBase>().CastSpell();

                    float multi = 1;
                    if (darkSpellID == 0)
                        Instantiate(_1STMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 1)
                        Instantiate(_2NDMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 2)
                        Instantiate(_3RDMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 3)
                        Instantiate(_4THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 4)
                        Instantiate(_5THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 5)
                        Instantiate(_6THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 6)
                        Instantiate(_7THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 7)
                        Instantiate(_8THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 8)
                        Instantiate(_9THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (darkSpellID == 9)
                        Instantiate(_10THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                }

            }
        }
        if (this.gameObject.tag == "LightPlayer")
        {
            if (Input.GetKey("a"))
            {
                transform.Translate(Vector2.right * -playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(Vector2.up * -playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
            }
            if (Input.GetKey("m"))
            {
                GestureManager.Player_Cast[Player] = true;
            }
            if (GestureManager.Player_Cast[Player] && Player == 1)
            {
                GestureManager.Player_Cast[Player] = false;
                if (Time.time > nextCastLight)
                {
                    nextCastLight = Time.time + refireValueLight;

                    lightSpellID = GetComponent<ComboBase>().CastSpell();

                    float multi = 1;
                    if (lightSpellID == 0)
                        Instantiate(_1STMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 1)
                        Instantiate(_2NDMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 2)
                        Instantiate(_3RDMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 3)
                        Instantiate(_4THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 4)
                        Instantiate(_5THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 5)
                        Instantiate(_6THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 6)
                        Instantiate(_7THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 7)
                        Instantiate(_8THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 8)
                        Instantiate(_9THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                    if (lightSpellID == 9)
                        Instantiate(_10THMagic, magicSpawn.position, Quaternion.Euler(multi * new Vector3(magicSpawn.eulerAngles.x, magicSpawn.eulerAngles.y, magicSpawn.eulerAngles.z)));
                }

            }
        }

        Vector3 current = transform.localPosition;
        {
            current.x = Mathf.Max(current.x, MinPosition.x); // Clamp to minimum x
            current.y = Mathf.Max(current.y, MinPosition.y); // Clamp to minimum y
            current.x = Mathf.Min(current.x, MaxPosition.x); // Clamp to maximum x
            current.y = Mathf.Min(current.y, MaxPosition.y); // Clamp to maximum y
        }
        transform.localPosition = current;
    }
}