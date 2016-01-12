using UnityEngine;
using System.Collections;

public class menu_des : MonoBehaviour {
	private int frame;
	private bool isStart;
	// Use this for initialization
	void Start () {
		frame = 0;
		isStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isStart){
		frame ++;
			if(frame > 0){
				isStart = true;
				this.gameObject.SetActive(false);
			}
		}
	}
}
