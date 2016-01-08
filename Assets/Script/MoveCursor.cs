using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {
	public GameObject prefab;
	private GameObject cursor;
	public GameObject menu;
	private Vector3 clickPosition;
	static public string myname;
	// Use this for initialization
	void Start () {
		myname = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//clickPosition=Input.mousePosition;
			//clickPosition.z=64f;
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
<<<<<<< HEAD
			
				if(hit.collider.gameObject.tag=="kyoten"){
=======
			Instantiate(prefab,hit.point+new Vector3(0,1,0),prefab.transform.rotation);
				if(hit.collider.gameObject.tag=="kyoten" && hit.collider.gameObject.name != "E_kyoten_A"){
					myname = hit.collider.gameObject.name;
>>>>>>> origin/master
					menu.SetActive(true);
					//GetComponent<PlayerGeneration>().kyotenpos=hit.transform.position;
				}
				else{
					Instantiate(prefab,hit.point+new Vector3(0,1,0),prefab.transform.rotation);
				}
			}
		}
	}
}
