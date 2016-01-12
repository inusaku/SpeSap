using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	static public bool isClear;
	private float timer;
	public GameObject stage01;
	public GameObject stage02;
	public GameObject stage03;

	void Start(){
		if(GameObject.Find("system").GetComponent<system>().stageNum == 1){
			Instantiate(stage01);
		}
		if(GameObject.Find("system").GetComponent<system>().stageNum == 2){
			Instantiate(stage02);
		}
		if(GameObject.Find("system").GetComponent<system>().stageNum == 3){
			Instantiate(stage03);
		}
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
	}

	public void end (){
		Application.LoadLevel ("Title");
	}
	public void menuEnd (){
		GameObject.Find ("PlayerMenu").SetActive(false);
	}
}