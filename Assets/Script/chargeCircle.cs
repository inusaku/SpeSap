using UnityEngine;
using System.Collections;

public class chargeCircle : MonoBehaviour {
	private Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.name == "ChargeCircle"){
			target = GameObject.Find ("LastResort_A").transform;
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 20f, screenPos.z);
		}
		if(this.gameObject.name == "ChargeCircle02"){
			target = GameObject.Find ("LastResort_B").transform;
			var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
			var localPos = Vector2.zero;
			this.transform.position = new Vector3(screenPos.x, screenPos.y + 20f, screenPos.z);
		}
	}
}
