using UnityEngine;
using System.Collections;

public class FireSpell : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationPerSecond = 180.0f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + (movementSpeed * Time.deltaTime));
        transform.position = Vector3.Lerp(transform.position, target, 1.0f);

        Vector3 rotTarget = new Vector3(0,0,transform.eulerAngles.z + (rotationPerSecond * Time.deltaTime));
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotTarget, 1.0f);
	}
}
