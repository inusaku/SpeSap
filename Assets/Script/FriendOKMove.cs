using UnityEngine;
using System.Collections;

public class FriendOKMove : MonoBehaviour
{
    GameObject target1;
    //GameObject target2;

    float  speed = 2f;
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

                moveDirection += transform.forward * 5f;
                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime * speed);
            
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy")
        {
            isPSW = true;
            target1 = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            isPSW = false;
            target1 = null;
        }
    }
    void OnTriggerStay(Collider col)
    {
        //プレイヤーが有効範囲内に存在する場合Playerを追いかける
        if (col.tag == "Enemy")
        {
            isPSW = true;
			target1 = col.gameObject;
        }

    }
}





 