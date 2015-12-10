using UnityEngine;
using System.Collections;

public class Move_E: MonoBehaviour {
    private Transform target;
    private Vector3 vec = Vector3.zero;
    private CharacterController controller;
    Enemy enemy;
    Vector3 EnemyPosition;
    Vector3 EnemyRotation;
    


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
        controller = (CharacterController)GetComponent("CharacterController");
	}
	
	// Update is called once per frame
	void Update () {
        vec.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(vec * Time.deltaTime);
        if (controller.isGrounded)
        {
            vec.y = 0;
        }
        var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position + transform.position), enemy.speed1).eulerAngles;
        //newRotation.x = 0;
        //transform.rotation = Quaternion.Euler(newRotation);
        transform.rotation = Quaternion.LookRotation(transform.position - (target.position - new Vector3(0, 0f, 0)));
        transform.position -= transform.forward * enemy.speed2;
       

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemy.speed1 = 0f;
            enemy.speed2 = 0f;

        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemy.speed1 = 0f;
            enemy.speed2 = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.speed1 = 0.05f;
            enemy.speed2 = 0.05f;

        }
    }
}
