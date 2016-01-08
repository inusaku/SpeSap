using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour {

	public enum enumType{
		Bomb,
		AtkBuffer,
		Heal,
	}
	public enumType TYPE;
	public float par=1;
	private float mag;
	public float bufftimer;
	public bool buffset=true;
	// Use this for initialization
	void Start () {
		mag = GetComponent<PlayerStatus> ().MAXHP /par;
		switch (TYPE) {
	
		}
	}
	
	// Update is called once per frame
	void Update () {

		switch (TYPE) {
		case enumType.Bomb:
			Bomb();
			break;
		case enumType.Heal:
			Heal();
			break;
		case enumType.AtkBuffer:
			if(GetComponent<PlayerStatus>().HP<=mag&&buffset==true){
			AtkBuffer();
			}
			break;
		}
		bufftimer-=1*Time.deltaTime;
		if (bufftimer <= 0) {
			GetComponent<PlayerStatus>().Atk=GetComponent<PlayerStatus>().MAXATK;
		}
	}
	public void Bomb(){
		if (gameObject.GetComponent<PlayerStatus> ().HP <= 0) {
			Debug.Log ("BOMB");
		}
	}
	public void AtkBuffer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
				foreach (GameObject player in players) {
				player.GetComponent<PlayerStatus> ().Atk *= 1.1f;
			player.GetComponent<PlayerSkill>().bufftimer=30;
			buffset=false;
				}
	}
	public void Heal(){
		Debug.Log ("HEAL!!");
	}

}
