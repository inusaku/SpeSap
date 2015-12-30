using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x, this.transform.position.y, player.transform.position.z);
	}
}
