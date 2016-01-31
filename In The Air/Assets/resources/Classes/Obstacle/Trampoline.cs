using UnityEngine;
using System.Collections;

public class Trampoline : Obstacle {
	[SerializeField] protected float bounceCoefficient = 1f;
	[SerializeField] protected int numSprings = 10;

	// Use this for initialization
	void Start () {
		GameObject hookPrefab = Resources.Load("Prefabs/Trampoline Hook") as GameObject;
		GameObject newHook;
		SpringJoint2D spring;
		float sdStep = 0.2f / (numSprings - 1);
		for (int i = 0; i < numSprings; i++) {
			newHook = Instantiate(hookPrefab) as GameObject;
			newHook.transform.parent = transform;
			newHook.transform.localPosition = new Vector2(-0.1f + i * sdStep, -0.15f);
			spring = gameObject.AddComponent<SpringJoint2D>();
			spring.connectedBody = newHook.GetComponent<Rigidbody2D>();
			spring.anchor = new Vector2(-0.1f + i * sdStep, 0);
			spring.connectedAnchor = Vector2.zero;
			spring.dampingRatio = 0.5f;
			spring.frequency = 0.8f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		coll.gameObject.GetComponent<Person>().hitObst();
		this.durability -= 1;
	}
}
