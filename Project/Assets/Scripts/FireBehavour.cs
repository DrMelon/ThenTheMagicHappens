using UnityEngine;
using System.Collections;

public class FireBehavour : MonoBehaviour {

	public float fireballLifeSpan = 5;
	public float fireBallSpeed;
	public float next;
	private float totalTime;
	// Use this for initialization
	void Start () {
		totalTime = Time.time + fireballLifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * fireBallSpeed * Time.deltaTime);
		if (Time.time > totalTime) {
			Destroy (gameObject);
				}
	}
}
