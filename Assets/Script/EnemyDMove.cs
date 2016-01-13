using UnityEngine;
using System.Collections;

public class EnemyDMove : MonoBehaviour {
	public NavMeshAgent agent;
  	private GameObject m_TargetObject;
  	private Transform m_Target;
 	private EnemyMoveManager m_EMM;
	float speed = 2.0f;
	float gravity = 100.0f;
	
	public bool isEnabled = false;
	private int frame;
	void start()
	{
		frame = 0;
		if (agent == null) { agent = this.gameObject.GetComponent<NavMeshAgent>(); }
		m_EMM = this.gameObject.GetComponent<EnemyMoveManager>();
		m_TargetObject = m_EMM.NearTarget();
		m_Target = m_TargetObject.transform;
    	}
	
	// Update is called once per frame
	void Update()
	{
		if (frame > 3) {
			m_EMM = this.gameObject.GetComponent<EnemyMoveManager>();
			m_TargetObject = m_EMM.NearTarget();
			m_Target = m_EMM.NearTarget().transform;

			Vector3 moveDirection = Vector3.zero;
			CharacterController controller = GetComponent<CharacterController>();

			Vector3 l_TargetDirection = m_Target.position;
			l_TargetDirection.y = 0;
//			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(l_TargetDirection - transform.position), Time.time * 0.1f);
//			Quaternion rotate = Quaternion.LookRotation(l_TargetDirection - transform.position);

			moveDirection += transform.forward * 1;
			moveDirection.y -= gravity * Time.deltaTime;
			agent.destination = m_Target.position;
		}
		frame ++;
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			isEnabled = true;
			m_Target = col.transform;
		}
		
	}
	
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
		{
			isEnabled = false;
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player")
		{
			isEnabled = true;
		}
	}
}
