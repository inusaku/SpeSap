using UnityEngine;
using System.Collections;

public class HP_hantei : MonoBehaviour {
	public bool isHP; 
	private int frame;
	// Use this for initialization
	void Start () {
		if(this.name == "Player01" || this.name == "Player01(Clone)" || this.name == "Player02(Clone)" || this.name == "Player03(Clone)"){
			this.name = "Player";
		}
		if(this.name == "Enemy01(Clone)" || this.name == "Enemy02(Clone)" || this.name == "Enemy03(Clone)"){
			this.name = "Enemy";
		}
		isHP = false;
		frame = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(isHP == true && frame < 3){
			frame ++;
			if(frame > 1 && this.name == "Player"){
				this.name = "Player_HP";
			}
			if(frame > 1 && this.name == "Enemy"){
				this.name = "Enemy_HP";
			}
		}
	}
}
