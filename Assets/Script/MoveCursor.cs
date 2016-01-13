using UnityEngine;
using System.Collections;

public class MoveCursor : MonoBehaviour {
	public GameObject prefab;
	private GameObject cursor;
	public GameObject menu;
	private Vector3 clickPosition;
	public AudioClip select;
	// Use this for initialization
	void Start () {
//		menu = GameObject.Find ("PlayerMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//clickPosition=Input.mousePosition;
			//clickPosition.z=64f;
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
			
				if(hit.collider.gameObject.tag=="kyoten" || hit.collider.gameObject.tag=="kariKyoten"){
					this.GetComponent<AudioSource> ().PlayOneShot (select);
					menu.SetActive(true);
					GetComponent<PlayerGeneration>().kyotenpos=hit.transform.position;
				}
				else{
					Instantiate(prefab,hit.point+new Vector3(0,1,0),prefab.transform.rotation);
				}
			}
		}
	}
}
