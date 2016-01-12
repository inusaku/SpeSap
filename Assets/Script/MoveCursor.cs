﻿using UnityEngine;
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


		if (Input.GetMouseButtonDown (0)) {
			//clickPosition=Input.mousePosition;
			//clickPosition.z=64f;
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){
			
				if(hit.collider.gameObject.tag=="kyoten" && hit.collider.gameObject.name != "E_kyoten_A"){
					menu.SetActive(true);
					GetComponent<PlayerGeneration>().kyotenpos=hit.transform.position;
					Debug.Log("kyotenn");
				}
				else{
					Instantiate(prefab,hit.point+new Vector3(0,1,0),prefab.transform.rotation);
				}
			}
		}
	}
}
