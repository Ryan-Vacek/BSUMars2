using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	[SerializeField] private int waveSize = 3;
	[SerializeField] private float dudeInterval = 5f;
	private int activeDudes;
	private int score = 0;
	private float yTop;
	private float camWidth;
	private float xCoord;
	private Person[] dudes;

	// Use this for initialization
	void Start () {
		yTop = Camera.main.orthographicSize;
		camWidth = yTop * Camera.main.aspect;
		dudes = GameObject.FindObjectsOfType(typeof(Person)) as Person[];
		for (int i = 0; i < dudes.Length; i++)
			dudes[i].gameObject.SetActive(false);
		xCoord = Random.Range(-camWidth / 2f, camWidth / 2f);
		spawnWave();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("z"))
			spawnWave();
	}

	void OnTriggerEnter2D(Collider2D person) {
		score += person.gameObject.GetComponent<Person>().getScore();
		person.gameObject.SetActive(false);
		activeDudes--;
	}

	public void spawnWave() {
		StartCoroutine(spawnDudes());
	}

	IEnumerator spawnDudes() {
		int numDudes = waveSize;
		for (int i = 0; i < dudes.Length; i++) {
			if (!dudes[i].gameObject.activeInHierarchy) {
				yield return new WaitForSeconds(dudeInterval);
				// TODO: Add second interval for animation
				dudes[i].gameObject.transform.position = new Vector2(xCoord, yTop);
				dudes[i].gameObject.transform.eulerAngles = new Vector3(0f, 0f, 180f);
				dudes[i].gameObject.SetActive(true);
				if (numDudes == 1)
					break;
				numDudes--;
			}
		}
		xCoord = Random.Range(-camWidth / 2f, camWidth / 2f);
	}
}
