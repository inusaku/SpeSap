using UnityEngine;
using System.Collections;


public class Move_EO : MonoBehaviour {
    private Transform target;
    private Vector3 vec = Vector3.zero;
    private CharacterController controller;
    EnemyO enemyO;
    Vector3 EO_Position;
    Vector3 EO_Rotation;
    public float speed = 3; //移動速度
    public float limitDistance = 1000f;

    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Place").transform;
        enemyO = GetComponent<EnemyO>();
        controller = (CharacterController)GetComponent("CharacterController");
        
    }
	
	// Update is called once per frame
	void Update () {
        vec.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(vec * Time.deltaTime);
        Vector3 direction = transform.position;
        float distance = direction.sqrMagnitude;
        direction = direction.normalized;
        direction.y = 0f;
        if (controller.isGrounded)
        {
            vec.y = 0;
        }
        var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position + transform.position), enemyO.speed1).eulerAngles;
        //newRotation.x = 0
        //transform.rotation = Quaternion.Euler(newRotation);
        transform.rotation = Quaternion.LookRotation(transform.position - (target.position - new Vector3(0, target.position.y - 0.4f, 0)));
        transform.position -= transform.forward * enemyO.speed2;

        if (distance >= limitDistance)
        {
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Place")
        {
            enemyO.speed1 = 0f;
            enemyO.speed2 = 0f;

        }
        
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Place")
        {
            enemyO.speed1 = 0f;
            enemyO.speed2 = 0f;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Place")
        {
            enemyO.speed1 = 0.0f;
            enemyO.speed2 = 0.0f;

        }
        if (col.gameObject.tag == "Enemy_EO")
        {
            enemyO.speed1 = 0.02f;
            enemyO.speed2 = 0.02f;
        }
    }


}
