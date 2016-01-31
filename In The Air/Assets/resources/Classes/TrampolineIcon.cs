using UnityEngine;
using System.Collections;

public class TrampolineIcon : MonoBehaviour {

	[SerializeField] GameObject spawnObject;
	bool mouseDown = false;
	Vector3 startingPos;

	// Use this for initialization
	void Start () {
		startingPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseDown) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.z = gameObject.transform.position.z;
			gameObject.transform.position = pos;
		} else {
			gameObject.transform.position = startingPos;
		}
	}

	void OnMouseDown() {
		gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		mouseDown = true;
	}

	void OnMouseUp() {
		// Do some magic check here to see if this is a valid spot to drop a trampoline
		Instantiate(spawnObject, gameObject.transform.position, gameObject.transform.rotation);
		gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		mouseDown = false;
	}
}
