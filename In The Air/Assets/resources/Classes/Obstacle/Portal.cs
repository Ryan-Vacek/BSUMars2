using UnityEngine;
using System.Collections;

public class Portal : Obstacle {
	public float warpTime = 1f;
	[SerializeField] private GameObject link;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D warper) {
		if (!warper.GetComponent<Person>().getPortal()) {
			durability -= 1;
			link.GetComponent<Portal>().durability -= 1;
			warper.GetComponent<Person>().setPortal(this);
			warper.GetComponent<Person>().hitObst();
			StartCoroutine(Warp(warper.attachedRigidbody));
		}
	}

	void OnTriggerExit2D(Collider2D warper) {
		if (warper.GetComponent<Person>().getPortal() != this) {
			warper.GetComponent<Person>().hitObst();
			warper.GetComponent<Person>().setPortal(null);
		}
	}

	IEnumerator Warp(Rigidbody2D warper) {
		Vector2 newVel = warper.velocity;
		newVel.Normalize();
		newVel = warper.velocity.magnitude * link.transform.up;
		warper.GetComponent<SpriteRenderer>().enabled = false;
		warper.constraints = RigidbodyConstraints2D.FreezeAll;
		yield return new WaitForSeconds(warpTime);
		warper.GetComponent<SpriteRenderer>().enabled = true;
		warper.constraints = RigidbodyConstraints2D.None;
		warper.transform.position = link.transform.position;
		warper.velocity = newVel;
		warper.transform.rotation = link.transform.rotation;
	}
}
