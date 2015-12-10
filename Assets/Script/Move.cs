using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	private NavMeshAgent agent;
	private RaycastHit hit;
	private Ray ray;
	public float speed;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f)){
				GetComponent<NavMeshAgent> ().speed = speed;
				agent.SetDestination(hit.point);
			}       
		}
		if(Mathf.Abs(this.transform.position.x - hit.point.x) < 0.05f){
			GetComponent<NavMeshAgent> ().speed = 0;
		}
	}
}
