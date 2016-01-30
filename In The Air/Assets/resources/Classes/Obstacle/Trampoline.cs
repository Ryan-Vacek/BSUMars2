using UnityEngine;
using System.Collections;

public class Trampoline : Obstacle {
	[SerializeField] protected float bounceCoefficient = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Vector2 newVel = coll.rigidbody.velocity;
		newVel.Normalize();
		newVel = -10 * Vector2.Dot(newVel, (Vector2) transform.up) * (Vector2) transform.up + newVel;
		this.durability -= 1;
		coll.rigidbody.velocity = newVel;
	}
}
