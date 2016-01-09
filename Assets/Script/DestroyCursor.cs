using UnityEngine;
using System.Collections;

public class DestroyCursor : MonoBehaviour {
	private Vector3 position;
	private Vector3 screenToworldPosition;
	private Vector3 clickPosition;
	private float scalesize;
	private float dis;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			float mouse_x_delta = Input.GetAxis("Mouse X");
			float mouse_y_delta = Input.GetAxis("Mouse Y");
			dis += mouse_x_delta + mouse_y_delta;
			dis = Mathf.Clamp (dis, -5, 5);
			gameObject.transform.localScale = new Vector3(dis * 10f,gameObject.transform.localScale.y,dis * 10f);
		}

	if (Input.GetMouseButtonUp (0)) {
			Destroy(this.gameObject);
			dis = 0;
		}
	}
}
