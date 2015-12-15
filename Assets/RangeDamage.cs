using UnityEngine;
using System.Collections;

public class RangeDamage : MonoBehaviour {
	private GameObject enemyOb;
	public GameObject player;
	private float atk;
	private float dmg;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		atk=player.GetComponent<PlayerStatus>().Atk;
		dmg = atk / 2;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Enemy") {
			enemyOb=col.gameObject;
			enemyOb.GetComponent<Enemy> ().life -=Mathf.Ceil(dmg);
			Debug.Log("RANGEHIT");
		}
	}
}
