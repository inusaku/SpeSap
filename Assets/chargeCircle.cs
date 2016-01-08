using UnityEngine;
using System.Collections;

public class chargeCircle : MonoBehaviour {
	private Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.Find ("LastResort").transform;
		var screenPos = GameObject.Find("Main Camera").GetComponent<Camera>().WorldToScreenPoint(target.position);
		var localPos = Vector2.zero;
		this.transform.position = new Vector3(screenPos.x, screenPos.y + 20f, screenPos.z);
	}
}
