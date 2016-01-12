using UnityEngine;
using System.Collections;

public class MoveTotarget : MonoBehaviour
{
  Transform player;
    public Transform target2;
    NavMeshAgent agent;
    public float limitDistance = 100f;
    public float speed = 3f;

    

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target2 = GameObject.FindGameObjectWithTag("Place").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

      

    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;                 //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向と距離を求める。
        float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
        direction = direction.normalized;                   //単位化（距離要素を取り除く）
        direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。

        //プレイヤーの距離が一定以上でなければ、敵キャラクターはプレイヤーへ近寄ろうとしない
        if (distance >= limitDistance)
        {

            //プレイヤーとの距離が制限値以上なので普通に近づく
            transform.position = transform.position + (direction * speed * Time.deltaTime);

        }
        else if (distance < limitDistance)
        {

            //プレイヤーとの距離が制限値未満（近づき過ぎ）なので、後退する。
            transform.position = transform.position- (direction * speed * Time.deltaTime);
        }

      

    }
   
       
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            agent.destination = player.position;
            Debug.Log("AAA");
        }
    }

}
