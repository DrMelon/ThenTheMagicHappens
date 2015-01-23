using UnityEngine;
using System.Collections;

public class FireSpell : MonoBehaviour
{
    public float rotationPerSecond = 180.0f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 rotTarget = new Vector3(0,0,transform.eulerAngles.z + (rotationPerSecond * Time.deltaTime));
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotTarget, 1.0f);
	}
}
