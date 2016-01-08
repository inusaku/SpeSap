using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
	public GameObject uiHP;
	// Use this for initialization
	void Start () {
		Instantiate (uiHP);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
