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
		heightMap = new List<Vector2> ();

		switch (diff)
		{
		case difficulty.easy:
			heightDifferential = 12;
			for (int i = 0; i < 8; i++) {
				int heightDelta = (int) (heightDifferential * Random.value - heightDifferential / 2.0f);
				Vector2 vec2;
				vec2.x = (int) (Random.value * screenWidth);
				vec2.y = (int)(height + heightDelta);

				heightMap.Add (vec2);
			}
			break;
		case difficulty.medium:
			heightDifferential = 20;
			for (int i = 0; i < 16; i++) {
				int heightDelta = (int) (heightDifferential * Random.value - heightDifferential / 2.0f);
				Vector2 vec2;
				vec2.x = (int) (Random.value * screenWidth);
				vec2.y = (int)(height + heightDelta);

				heightMap.Add (vec2);
			}
			break;
		case difficulty.hard:
			heightDifferential = 28;
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
		List<Vector3> vertices = new List<Vector3> ();
		List<Vector2> triangles = new List<Vector2> ();
		vertices.Add (new Vector3 (0, 0, 0));
		for (int i = 0; i < heightMap.Count; i++) {
			vertices.Add ((Vector3) heightMap[i]);
		}

		for (int i = 0; i < heightMap.Count; i++) {
			Vector3 vert = (Vector3) heightMap [i];
			vert.y = 0;
			vertices.Add (vert);
		}
		vertices.Add (new Vector3 (screenWidth, 0, 0));
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.vertices = vertices.ToArray();


		// Create a rectangle for every set of 4 points
		for (int i = 0; i < heightMap.Count-1; i++) {
			// rectangle 0 is point length-1, 0, 1, 2
			// rectangle 1 is point length-1, length-2, 2, 3

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
