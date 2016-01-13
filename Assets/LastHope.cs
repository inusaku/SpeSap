using UnityEngine;
using System.Collections;

public class LastHope : MonoBehaviour {
	public GameObject hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider col){
		if(col.gameObject.tag == "Enemy"){
			Destroy(col.gameObject);
			Instantiate(hit, col.transform.position, Quaternion.identity);
		}
	}
}
