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

	// Use this for initialization
	void Start () {
		switch (TYPE) {
		case enumType.AtkBuffer:
			AtkBuffer();
			break;
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
		}
	}
	public void Bomb(){
		if (gameObject.GetComponent<PlayerStatus> ().HP <= 0) {
			Debug.Log ("BOMB");
		}
	}
	public void AtkBuffer(){
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject player in players) {
			player.GetComponent<PlayerStatus>().Atk*=2;
		}
		Debug.Log ("ATK!!");
	}
	public void Heal(){
		Debug.Log ("HEAL!!");
	}

}
