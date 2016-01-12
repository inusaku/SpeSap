using UnityEngine;
using System.Collections;

public class titleManager : MonoBehaviour {
	private float timer;
	private bool isEnd;
	private bool isStart;
	private bool isStaff;
	public string stageSelect;
	public string staffScene;
	public AudioClip select01;
	private bool isSE;
	private Animator endAnim;
	private Animator startAnim;
	private Animator staffAnim;
	// Use this for initialization
	void Start () {
		timer = 0f;
		isEnd = false;
		isStart = false;
		isStaff = false;
		isSE = false;
		startAnim = GameObject.Find ("ui_gameStart").GetComponent<Animator> ();
		staffAnim = GameObject.Find ("ui_staff").GetComponent<Animator> ();
		endAnim = GameObject.Find ("ui_gameEnd").GetComponent<Animator> ();
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
			if(isSE == false){
				endAnim.SetBool("isEnd", true);
				isSE = true;
				this.GetComponent<AudioSource> ().PlayOneShot (select01);
			}
			isEnd = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
	public void start (){
		if(isEnd == false && isStart == false && isStaff == false){
			if(isSE == false){
				startAnim.SetBool("isStart", true);
				isSE = true;
				this.GetComponent<AudioSource> ().PlayOneShot (select01);
			}
			isStart = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
	public void staff (){
		if(isEnd == false && isStart == false && isStaff == false){
			if(isSE == false){
				staffAnim.SetBool("isStaff", true);
				isSE = true;
				this.GetComponent<AudioSource> ().PlayOneShot (select01);
			}
			isStaff = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}
}
