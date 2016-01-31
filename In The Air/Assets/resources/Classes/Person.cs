using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public int health;
	private int score = 0;
	private float maxVel = 0f;
	private int obHit = 0;
	[SerializeField] protected GameObject blood;
	private Portal entered = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (GetComponent<Rigidbody2D>().velocity.magnitude > maxVel)
			maxVel = GetComponent<Rigidbody2D>().velocity.magnitude;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Instantiate (blood, transform.position, transform.rotation);
	}

	public Portal getPortal() {
		return entered;
	}

	public void setPortal(Portal portal) {
		entered = portal;
	}

	public void hitObst() {
		obHit++;
	}

	public int getScore() {
		return (int)maxVel + obHit;
	}
}
