using UnityEngine;
using System.Collections;

public class EnemyDMove : MonoBehaviour {
    //public GameObject target1;
    //public GameObject target2;
	public NavMeshAgent agent;
    public Transform target1;
    public Transform target2;
    float speed = 2.0f;
    float gravity = 100.0f;

    public bool isEnabled = false;
    void start()
	{
	}

    // Update is called once per frame
    void Update()
    {
		if(agent == null){
			agent = this.gameObject.GetComponent<NavMeshAgent>();	
		}
		if(target1 == null){
			target1 = GameObject.Find ("Player").transform;
		}
		if(target2 == null){
			target2 = GameObject.FindWithTag("Place").transform;
		}
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 moveDirection = Vector3.zero;
        Vector3 playerPos = target1.position;                 //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向と距離を求める。
        float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
        direction = direction.normalized;                   //単位化（距離要素を取り除く）
        direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。
        


        //プレイヤーが索敵範囲にいる際の処理
        if (isEnabled == true)
        {
            Vector3 target1Direction = target1.transform.position;
            target1Direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target1Direction - transform.position), Time.time * 0.1f);
            Quaternion rotate = Quaternion.LookRotation(target1.position - transform.position);
            rotate.x = rotate.z = 0;
            transform.rotation = rotate;

            moveDirection += transform.forward * 1;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime * speed);
        }
        else
        {
            Vector3 target2Direction = target2.transform.position;
            target2Direction.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target2Direction - transform.position), Time.time * 0.1f);
            Quaternion rotate = Quaternion.LookRotation(target2.position - transform.position);
            rotate.x = rotate.z = 0;
            transform.rotation = rotate;

            moveDirection += transform.forward * 1;
            moveDirection.y -= gravity * Time.deltaTime;
			agent.SetDestination(target2.transform.position);            

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isEnabled = true;
            target1 = col.transform;
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
