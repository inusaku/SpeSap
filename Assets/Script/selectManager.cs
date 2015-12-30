using UnityEngine;
using System.Collections;

public class selectManager : MonoBehaviour {
	private float timer;
	private bool isEnd;
	private bool isStart;
	public string mainScene;

	// Use this for initialization
	void Start () {
		timer = 0f;
		isEnd = false;
		isStart = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isEnd == true || isStart == true){
			timer += 0.9f * Time.deltaTime;
		}
		
		if(timer > 1f && isEnd == true){
			Application.LoadLevel("Title");
		}
		if(timer > 1f && isStart == true){
			Application.LoadLevel("" + mainScene);
		}
	}
	
	public void end (){
		if(isEnd == false && isStart == false){
			isEnd = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
	public void start (){
		if(isEnd == false && isStart == false){
			isStart = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
}