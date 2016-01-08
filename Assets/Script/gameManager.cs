using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
/*	private float timer;
	private bool isEnd;
	private bool isStart;
	private bool isStaff;
	public string stageSelect;
	public string staffScene;
	
	// Use this for initialization
	void Start () {
		timer = 0f;
		isEnd = false;
		isStart = false;
		isStaff = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isEnd == true || isStart == true || isStaff == true){
			timer += 0.9f * Time.deltaTime;
		}
		
		if(timer > 1f && isEnd == true){
			Application.Quit();
		}
		if(timer > 1f && isStart == true){
			Application.LoadLevel("" + stageSelect);
		}
		if(timer > 1f && isStaff == true){
			Application.LoadLevel("" + staffScene);
		}
	}
	
	public void end (){
		if(isEnd == false && isStart == false && isStaff == false){
			isEnd = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
	public void start (){
		if(isEnd == false && isStart == false && isStaff == false){
			isStart = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
	public void staff (){
		if(isEnd == false && isStart == false && isStaff == false){
			isStaff = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}*/
	public void end (){
		Application.LoadLevel ("Title");
	}
}