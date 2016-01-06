using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {
	public GameObject prefab;
	private GameObject cursor;
	private Vector3 clickPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			clickPosition=Input.mousePosition;
			clickPosition.z = 64f;
			Instantiate(prefab,Camera.main.ScreenToWorldPoint(clickPosition),prefab.transform.rotation);

		}
	}
}
