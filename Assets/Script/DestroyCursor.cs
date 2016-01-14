using UnityEngine;
using System.Collections;

public class DestroyCursor : MonoBehaviour {
	private Vector3 position;
	private Vector3 screenToworldPosition;
	private Vector3 clickPosition;
	private float scalesize;
	private float dis;
	private Vector3 pos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000f)){
				pos=hit.point;
			} 
			float dispos=Vector3.Distance(gameObject.transform.position,pos);
			dispos=Mathf.Clamp(dispos,-50,50);
			gameObject.transform.localScale = new Vector3(dispos*2,gameObject.transform.localScale.y,dispos*2);
		}

	if (Input.GetMouseButtonUp (0)) {
			GetComponent<SphereCollider>().isTrigger=true;
			Destroy(this.gameObject,0.1f);
			dis = 0;
		}
	}
}
