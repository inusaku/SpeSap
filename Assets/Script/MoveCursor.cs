using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {
	public GameObject prefab;
	private GameObject cursor;
	public GameObject menu;
	private Vector3 clickPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if (Input.GetMouseButtonDown (0)) {
			clickPosition=Input.mousePosition;
			clickPosition.z = 64f;
			Instantiate(prefab,Camera.main.ScreenToWorldPoint(clickPosition),prefab.transform.rotation);
=======
>>>>>>> origin/nepia


		if (Input.GetMouseButtonDown (0)) {
			//clickPosition=Input.mousePosition;
			//clickPosition.z=64f;
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
			Instantiate(prefab,hit.point+new Vector3(0,1,0),prefab.transform.rotation);
				if(hit.collider.gameObject.tag=="kyoten"){
					menu.SetActive(true);
					Debug.Log("kyotenn");
				}
			}
		}
	}
}
