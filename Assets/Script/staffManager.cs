using UnityEngine;
using System.Collections;

public class staffManager : MonoBehaviour {
	private float timer;
	private bool isEnd;
	public AudioClip select;
	private bool isSE; 
	// Use this for initialization
	void Start () {
		timer = 0f;
		isEnd = false;
		isSE = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isEnd == true){
			timer += 0.9f * Time.deltaTime;
		}		
		if(timer > 1f && isEnd == true){
			Application.LoadLevel("Title");
		}
	}
	
	public void end (){
		if(isEnd == false){
			if(isSE == false){
				isSE = true;
				this.GetComponent<AudioSource> ().PlayOneShot (select);
			}
			isEnd = true;
			GameObject.Find("ui_fead").GetComponent<Animator>().SetBool("isStart", true);
		}
	}	
}