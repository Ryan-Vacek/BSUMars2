using UnityEngine;
using System.Collections;

public class PlacementIcon : MonoBehaviour {

	[SerializeField] GameObject spawnObject;
	bool mouseDown = false;
	Vector3 startingPos;

	// Use this for initialization
	void Start () {
		startingPos = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseDown) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.z = gameObject.transform.position.z;
			gameObject.transform.position = pos;
		} else {
			gameObject.transform.localPosition = startingPos;
		}
	}

	public void OnMouseDown() {
		mouseDown = true;
	}

	public void OnMouseUp() {
		// Do some magic check here to see if this is a valid spot to drop a trampoline
		Instantiate(spawnObject, gameObject.transform.position, gameObject.transform.rotation);
		mouseDown = false;
	}
}
