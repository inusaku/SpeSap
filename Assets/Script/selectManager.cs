using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class selectManager : MonoBehaviour {
	private float timer;
	private bool isEnd;
	private bool isStart;
	public string mainScene;
	private int num;
	public Sprite stage1;
	public Sprite stage2;
	public Sprite stage3;
	// Use this for initialization
	void Start () {
		num = 0;
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

		if(num == 0){
			GameObject.Find ("ui_R").GetComponent<Image>().color = new Color(1,1,1,1);
			GameObject.Find ("ui_R").GetComponent<Image>().raycastTarget = true;
			GameObject.Find ("ui_L").GetComponent<Image>().color = new Color(1,1,1,0);
			GameObject.Find ("ui_L").GetComponent<Image>().raycastTarget = false;
			GameObject.Find ("ui_stageNum").GetComponent<Image>().sprite = stage1;
		}else if(num == 1){
			GameObject.Find ("ui_R").GetComponent<Image>().color = new Color(1,1,1,1);
			GameObject.Find ("ui_R").GetComponent<Image>().raycastTarget = true;
			GameObject.Find ("ui_L").GetComponent<Image>().color = new Color(1,1,1,1);
			GameObject.Find ("ui_L").GetComponent<Image>().raycastTarget = true;
			GameObject.Find ("ui_stageNum").GetComponent<Image>().sprite = stage2;
		}else if(num == 2){
			GameObject.Find ("ui_R").GetComponent<Image>().color = new Color(1,1,1,0);
			GameObject.Find ("ui_R").GetComponent<Image>().raycastTarget = false;
			GameObject.Find ("ui_L").GetComponent<Image>().color = new Color(1,1,1,1);
			GameObject.Find ("ui_L").GetComponent<Image>().raycastTarget = true;
			GameObject.Find ("ui_stageNum").GetComponent<Image>().sprite = stage3;
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
	public void R (){
		num ++;
	}
	public void L (){
		num --;
	}
}