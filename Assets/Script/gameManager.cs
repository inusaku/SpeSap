using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	static public bool isClear;
	static public bool isFailed;
	private float timer;

	void Start(){
		timer = 0f;
		isClear = false;
	}
	void Update(){
		if(isClear == true){
			timer += Time.deltaTime;
			if(timer > 2f){
				Application.LoadLevel("stageSelect");
			}
		}
		if(isFailed == true){
			timer += Time.deltaTime;
			if(timer > 2f){
				Application.LoadLevel("Title");
			}
		}
	}

	public void end (){
		Application.LoadLevel ("Title");
	}
	public void menuEnd (){
		GameObject.Find ("PlayerMenu").SetActive(false);
	}
}