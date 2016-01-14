using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	public float recast;
	private float Atk;
	private GameObject enemyOb;
	private GameObject kyotenOb;
	public GameObject normalhitpar;
	public string type;
	public string enemytype;
	private bool chast;
	private float chastTimer;
	public float timer;
	// Use this for initialization
	void Start () {
		Atk = this.GetComponent<PlayerStatus> ().Atk;
		chast = true;
	}
	void Attack()
	{
		chastTimer = timer;
		if (type == "ATK" && enemytype == "SPEED") {
			Damage (Atk*2);
			Debug.Log ("HIT");
		}
		if (type == "ATK" && enemytype == "DEF") {
			Damage (Atk/2);
			Debug.Log ("DHIT");
		}
		if (type == "ATK" && enemytype == "ATK") {
			Damage (Atk);
			Debug.Log ("HIT");
		}

		if (type == "DEF" && enemytype == "SPEED") {
			Damage (Atk/2);
			Debug.Log ("HIT");
		}
		if (type == "DEF" && enemytype == "DEF") {
			Damage (Atk);
			Debug.Log ("HIT");
		}
		if (type == "DEF" && enemytype == "ATK") {
			Damage (Atk*2);
			Debug.Log ("HIT");
		}
		if (type == "SPEED" && enemytype == "SPEED") {
			Damage (Atk);
			Debug.Log ("HIT");
		}

		if (type == "SPEED" && enemytype == "DEF") {
			Damage (Atk*2);
			Debug.Log ("HIT");
		}
		if (type == "SPEED" && enemytype == "ATK") {
			Damage (Atk/2);
			Debug.Log ("HIT");
		}
	}
	void Update () {
		type = GetComponent<UnitType> ().name;
		chastTimer -= 1 * Time.deltaTime;
		if (chastTimer <= 0) {
			chast=true;
		}
	}
	public void Damage(float damege)
	{
		if (enemyOb != null) {
				enemyOb.GetComponent<Enemy> ().life -= damege;
			Instantiate (normalhitpar, enemyOb.transform.position, Quaternion.identity);
		}
		else if(kyotenOb != null){
			kyotenOb.GetComponent<SpaceLife> ().Life -= damege;
			Instantiate(normalhitpar,kyotenOb.transform.position,Quaternion.identity);
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (chast == true) {
			if (col.gameObject.tag == "Enemy") {
				chast=false;
				Debug.Log ("ENEMYHI");
				enemyOb = col.gameObject;
				kyotenOb = null;
				Attack();
				GetComponent<NavMeshAgent> ().speed = 0;
				enemytype = col.GetComponent<UnitType> ().name;

			} else if (col.gameObject.tag == "E_kyoten") {
				chast=false;
				kyotenOb = col.gameObject;
				enemyOb = null;
				Attack();
				GetComponent<NavMeshAgent> ().speed = 0;

			}
		}
	}
	

	void OnTriggerExit(Collider col)
	{
		CancelInvoke("Attack");
	}
}
