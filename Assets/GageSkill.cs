using UnityEngine;
using System.Collections;

public class GageSkill : MonoBehaviour {
	public GameObject gage;
	public float par=1;
	private float HP;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Skill01()
	{
		if (gage.GetComponent<SkillGageSC> ().SkillPoint == 100) {
			GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject player in players) {
				HP=player.GetComponent<PlayerStatus> ().MAXHP*0.6f;
				player.GetComponent<PlayerStatus> ().HP+=HP;
			}
			gage.GetComponent<SkillGageSC> ().SkillPoint =0;
			Debug.Log ("BUTTEN");
		}
	}
	public void Skill02()
	{
		if (gage.GetComponent<SkillGageSC> ().SkillPoint == 100) {
			GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
			foreach (GameObject player in players) {
				player.GetComponent<NavMeshAgent> ().speed/=7.5f;
			}
			gage.GetComponent<SkillGageSC> ().SkillPoint =0;
			Debug.Log ("BUTTEN");
		}
	}
}
