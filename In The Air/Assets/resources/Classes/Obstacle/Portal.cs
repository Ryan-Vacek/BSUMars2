using UnityEngine;
using System.Collections;

public class Portal : Obstacle {
	public float warpTime = 0.1f;
	[SerializeField] private GameObject link;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D() {

	}

	/*IEnumerator Warp() {

	}*/
}
