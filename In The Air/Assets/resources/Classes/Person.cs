using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public int health;
	private int score = 0;
	[SerializeField] protected GameObject blood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay2D(Collision2D collision) {
		Instantiate (blood, transform.position, transform.rotation);
	}
}
