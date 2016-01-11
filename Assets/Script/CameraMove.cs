using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public Vector3 min;
	public Vector3 max;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position; 
		pos.x=Mathf.Clamp (pos.x, min.x, max.x);
		pos.y=Mathf.Clamp (pos.y, min.y, max.y);
		pos.z=Mathf.Clamp (pos.z, min.z, max.z);

		float Scrollwheel = Input.GetAxis("Mouse ScrollWheel")*10;
		pos+=new Vector3(0,Scrollwheel * 10,0);
	if (Input.GetMouseButton (1)) {
			float mouse_x_delta = Input.GetAxis("Mouse X");
			float mouse_y_delta = Input.GetAxis("Mouse Y");
			pos+=new Vector3(mouse_x_delta,Scrollwheel,mouse_y_delta);
		}
		transform.position = pos;
	}
}
