using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	public float recast;
	private float Atk;
	private GameObject enemyOb;
	private GameObject kyotenOb;
	public GameObject normalhitpar;
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
			Instantiate(normalhitpar,enemyOb.transform.position,Quaternion.identity);
		}
		if(kyotenOb != null){
			kyotenOb.GetComponent<SpaceLife> ().Life -= damege;
			Instantiate(normalhitpar,kyotenOb.transform.position,Quaternion.identity);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Enemy"){
			Debug.Log("ENEMYHI");
			enemyOb = col.gameObject;
			InvokeRepeating ("Attack", recast,recast);
			GetComponent<NavMeshAgent> ().speed = 0;
		}
		if(col.gameObject.tag == "kyoten"){
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
