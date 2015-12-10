using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	public float recast;
	public float Atk;
	private GameObject enemyOb;
	private GameObject kyotenOb;
	// Use this for initialization
	void Start () {
		Atk = this.GetComponent<PlayerStatus> ().Atk;
	}
	void Attack()
	{
		Damage (Atk);
		Debug.Log("HIT");
	}
	public void Damage(float damege)
	{
		if(enemyOb != null){
			enemyOb.GetComponent<Enemy> ().life -= damege;
		}else if(kyotenOb != null){
			kyotenOb.GetComponent<SpaceLife> ().Life -= damege;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "enemy"){
			enemyOb = col.gameObject;
			InvokeRepeating ("Attack", recast,recast);
			GetComponent<NavMeshAgent> ().speed = 0;
		}
		else if(col.gameObject.tag == "kyoten"){
			kyotenOb = col.gameObject;
			InvokeRepeating ("Attack", recast,recast);
			GetComponent<NavMeshAgent> ().speed = 0;
		}
	}
	void OnTriggerExit(Collider col)
	{
		CancelInvoke("Attack");
	}
}
