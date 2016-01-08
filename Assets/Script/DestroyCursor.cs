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
		dis = 0;
	}
	
	// Update is called once per frame
	void Update () {
		clickPosition=Input.mousePosition;
		clickPosition.z=86f;
		position = Camera.main.ScreenToWorldPoint(clickPosition);
		float dis = Vector3.Distance (transform.position,position) - 44f;
		if(dis >= 5f){
			dis = 5f;
		}else if(dis <= -5f){
			dis = 5f;
		}
		Debug.Log (dis);
		if (position.x > position.z) {
			scalesize = position.x;
		} else {
			scalesize=position.z;
		}

		if (Input.GetMouseButton (0)) {
			gameObject.transform.localScale = new Vector3(dis * 10f,gameObject.transform.localScale.y,dis * 10f);
		}
	if (Input.GetMouseButtonUp (0)) {
			Destroy(this.gameObject);
			dis = 0;
		}
	}
}
