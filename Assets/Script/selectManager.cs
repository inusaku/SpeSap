using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class selectManager : MonoBehaviour {
	private float timer;
	private bool isEnd;
	private bool isStart;
	public string stage01;
	public string stage02;
	public string stage03;
	private int num;
	public Sprite stage1;
	public Sprite stage2;
	public Sprite stage3;
	public AudioClip select01;
	public AudioClip select02;
	public AudioClip select03;
	private bool isSE;
	private GameObject cam;
	// Use this for initialization
	void Start () {
		num = 0;
		timer = 0f;
		isEnd = false;
		isStart = false;
		isSE = false;
		cam = GameObject.Find ("Main Camera");
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
			GameObject.Find("ui_loading").GetComponent<Image>().color = new Color(1,1,1,1);
			if(num == 0){
				Application.LoadLevel("" + stage01);
			}
			if(num == 1){
				Application.LoadLevel("" + stage02);
			}
			if(num == 2){
				Application.LoadLevel("" + stage03);
			}
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
		cam.GetComponent<Animator> ().SetInteger ("num", num);
	}
	
	public void end (){
		if(isEnd == false && isStart == false){
			isEnd = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
		if(isSE == false){
			isSE = true;
			GameObject.Find("ui_gameEnd").GetComponent<Animator>().SetBool("isEnd", true);
			this.GetComponent<AudioSource> ().PlayOneShot (select01);
		}
	}
	public void start (){
		if(isEnd == false && isStart == false){
			isStart = true;
			this.GetComponent<AudioSource> ().pitch = 0.5f;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
		if(isSE == false){
			isSE = true;
			GameObject.Find("ui_gameStart").GetComponent<Animator>().SetBool("isStart", true);
			this.GetComponent<AudioSource> ().pitch = 0.75f;
			this.GetComponent<AudioSource> ().PlayOneShot (select02);
		}
	}
	public void R (){
		num ++;
		this.GetComponent<AudioSource> ().pitch = 0.75f;
		this.GetComponent<AudioSource> ().PlayOneShot (select03);
	}
	public void L (){
		num --;
		this.GetComponent<AudioSource> ().pitch = 0.75f;
		this.GetComponent<AudioSource> ().PlayOneShot (select03);
	}
}