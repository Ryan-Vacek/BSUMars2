using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum difficulty : int {
	easy,
	medium,
	hard
}

public class Ground : MonoBehaviour {

	difficulty diff = difficulty.easy;
	float height = 1;
	List<Vector3> vertices;
	List<int> triangles;
	List<Vector2> uv;

	// Use this for initialization
	void Start () {
		vertices = new List<Vector3> ();
		triangles = new List<int> ();
		uv = new List<Vector2> ();
		generateMeshValues (Camera.main.orthographicSize * 2 * Camera.main.aspect);

		Mesh mesh = GetComponent<MeshFilter>().mesh;
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uv.ToArray ();
		mesh.RecalculateNormals ();

		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
		pos.z = 0;
		gameObject.transform.position = pos;
		Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D> ();
		rb.gravityScale = 0;
		rb.constraints = RigidbodyConstraints2D.FreezeAll;

		PolygonCollider2D pc = gameObject.AddComponent<PolygonCollider2D> ();
		List<Vector2> pts = new List<Vector2> ();
		foreach (Vector3 pt in vertices) {
			pts.Add ((Vector2)pt);
		}
		pc.points = pts.ToArray ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generateMeshValues(float width) {
		List<Vector2> heightMap = new List<Vector2> ();
		heightMap.Add (new Vector2 (0, height));
		float heightDifferential = 0;
		float screenWidth = width;

		switch (diff)
		{
		case difficulty.easy:
			heightDifferential = 0.12f;
			for (int i = 0; i < 8; i++) {
				float heightDelta = heightDifferential * Random.value - heightDifferential / 2.0f;
				Vector2 vec2;
				vec2.x = Random.value * screenWidth;
				vec2.y = height + heightDelta;

				heightMap.Add (vec2);
			}
			break;
		case difficulty.medium:
			heightDifferential = 0.24f;
			for (int i = 0; i < 32; i++) {
				float heightDelta = heightDifferential * Random.value - heightDifferential / 2.0f;
				Vector2 vec2;
				vec2.x = Random.value * screenWidth;
				vec2.y = height + heightDelta;

				heightMap.Add (vec2);
			}
			break;
		case difficulty.hard:
			heightDifferential = 0.36f;
			for (int i = 0; i < 64; i++) {
				float heightDelta = heightDifferential * Random.value - heightDifferential / 2.0f;
				Vector2 vec2;
				vec2.x = Random.value * screenWidth;
				vec2.y = height + heightDelta;

				heightMap.Add (vec2);
			}
			break;
		default:
			break;
		}

		heightMap.Add (new Vector2 (screenWidth, height));

		heightMap.Sort ((vec1, vec2) => vec1.x.CompareTo(vec2.x));

		// First add all the top vertices that we already created (height changed ones)
		for (int i = 0; i < heightMap.Count; i++) {
			vertices.Add ((Vector3) heightMap[i]);
			uv.Add(new Vector2(heightMap[i].x / screenWidth, 1));
		}

		// Second add all the bottom vertices that we haven't created, that we know have y at 0
		for (int i = heightMap.Count - 1; i >= 0; i--) {
			Vector3 vert = (Vector3) heightMap [i];
			vert.y = 0;
			vertices.Add (vert);
			uv.Add(new Vector2(heightMap[i].x / screenWidth, 0));
		}

		// Create a rectangle for every set of 4 points
		for (int i = 0; i < heightMap.Count-1; i++) {
			// rectangle 0 is point length-2, length-1, 0, 1
			// rectangle 1 is point length-3, length-2, 1, 2
			triangles.Add(i);
			triangles.Add(i+1);
			triangles.Add(vertices.Count - 1 - i);
			triangles.Add(i+1);
			triangles.Add(vertices.Count - 1 - (i+1));
			triangles.Add(vertices.Count - 1 - i);
		}
	}

	// Some gizmos just for the editor
	static bool drawn = false;
	void OnDrawGizmos () {
		if(drawn) {
			return;
		}

		vertices = new List<Vector3> ();
		triangles = new List<int> ();
		uv = new List<Vector2> ();

		generateMeshValues (Camera.main.orthographicSize * 2 * Camera.main.aspect);

		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uv.ToArray ();
		mesh.RecalculateNormals ();

		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
		pos.z = 0;
		gameObject.transform.position = pos;
		drawn = true;
		Gizmos.DrawMesh (mesh);
	}
}
