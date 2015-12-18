using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	private NavMeshAgent agent;
	private RaycastHit hit;
	private Ray ray;
	private bool moveset;
	private float speed;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		speed = gameObject.GetComponent<PlayerStatus> ().speed;
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)&&moveset==true){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f)){
				GetComponent<NavMeshAgent> ().speed = speed;
				agent.SetDestination(hit.point);
				moveset=false;
			}       
		}
		if(Mathf.Abs(this.transform.position.x - hit.point.x) < 0.05f){
			GetComponent<NavMeshAgent> ().speed = 0;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Cursor") {
			moveset=true;
			Debug.Log("cursorhit");
		}
	}
}
