using UnityEngine;
using System.Collections;

public class F_EnemyOKMove : MonoBehaviour {
    GameObject target1;
    //GameObject target2;

    float speed = 1f;
    float gravity = 20f;

    private bool isPSW = false;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 moveDirection = Vector3.zero;
        if (isPSW == true)
        {

            Vector3 targetDirection1 = target1.transform.position;
            targetDirection1.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection1 - transform.position), Time.time * 0.1f);

            moveDirection += transform.forward * 1;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime * speed);

        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isPSW = true;
            target1 = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            isPSW = false;
            target1 = null;
        }
    }
    void OnTriggerStay(Collider col)
    {
        //プレイヤーが有効範囲内に存在する場合追いかける
        if (col.tag == "Player")
        {
            isPSW = true;
        }

    }
}

