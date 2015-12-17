using UnityEngine;
using System.Collections;

public class RangeDamage : MonoBehaviour {
	private GameObject enemyOb;
	private GameObject enemyEOOb;
	public GameObject player;
	private float atk;
	private float dmg;
	public float downdmg;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		atk=player.GetComponent<PlayerStatus>().Atk;
		dmg = atk / downdmg;
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
		if (col.gameObject.tag == "Enemy_EO") {
			enemyEOOb=col.gameObject;
			enemyEOOb.GetComponent<EnemyO> ().life -=Mathf.Ceil(dmg);
			Debug.Log("RANGEHIT");
		}

	}
}
