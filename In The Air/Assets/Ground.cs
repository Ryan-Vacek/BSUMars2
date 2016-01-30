using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum difficulty : int {
	easy,
	medium,
	hard
}

public class Ground : MonoBehaviour {

	List<Vector2> heightMap;
	difficulty diff = difficulty.easy;
	int height = 100;

	// Use this for initialization
	void Start () {
		int screenWidth = Screen.width;
		int heightDifferential = 0;

		switch (diff)
		{
		case difficulty.easy:
			heightDifferential = 6;
			for (int i = 0; i < 8; i++) {
				int heightDelta = (int) (heightDifferential * Random.value - heightDifferential / 2.0f);
				Vector2 vec2;
				vec2.x = (int) (Random.value * screenWidth);
				vec2.y = (int)(height + heightDelta);

				heightMap.Add (vec2);
			}
			break;
		case difficulty.medium:
			heightDifferential = 10;
			for (int i = 0; i < 16; i++) {
				int heightDelta = (int) (heightDifferential * Random.value - heightDifferential / 2.0f);
				Vector2 vec2;
				vec2.x = (int) (Random.value * screenWidth);
				vec2.y = (int)(height + heightDelta);

				heightMap.Add (vec2);
			}
			break;
		case difficulty.hard:
			heightDifferential = 14;
			for (int i = 0; i < 24; i++) {
				int heightDelta = (int) (heightDifferential * Random.value - heightDifferential / 2.0f);
				Vector2 vec2;
				vec2.x = (int) (Random.value * screenWidth);
				vec2.y = (int)(height + heightDelta);

				heightMap.Add (vec2);
			}
			break;
		default:
			break;
		}

		heightMap.Sort ((vec1, vec2) => vec1.x.CompareTo(vec2.x));

		for (int i = 0; i < heightMap.Count; i++) {
			print (heightMap [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
