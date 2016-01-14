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
	// Use this for initialization
	void Start () {
		Atk = this.GetComponent<PlayerStatus> ().Atk;

	}
	void Attack()
	{
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

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy"){
			Debug.Log("ENEMYHI");
			enemyOb = col.gameObject;
			kyotenOb=null;
			InvokeRepeating ("Attack", recast,recast);
			GetComponent<NavMeshAgent> ().speed = 0;
			enemytype=col.GetComponent<UnitType>().name;
		}
		else if(col.gameObject.tag == "E_kyoten"){
			kyotenOb = col.gameObject;
			enemyOb=null;
			InvokeRepeating ("Attack", recast,recast);
			GetComponent<NavMeshAgent> ().speed = 0;
		}
	}
	void OnTriggerExit(Collider col)
	{
		CancelInvoke("Attack");
	}
}
