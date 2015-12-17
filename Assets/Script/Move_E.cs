using UnityEngine;
using System.Collections;

public class Move_E: MonoBehaviour {
    private Transform target,Place;
    private Vector3 vec = Vector3.zero;
    private CharacterController controller;
    Enemy enemy;
    Vector3 EnemyPosition;
    Vector3 EnemyRotation;
    public float limitDistance=100f;
 

    //public float directionX;
    




    // Use this for initialization
    void Start () {
        Place = GameObject.FindWithTag("Place").transform;
        target = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
        controller = (CharacterController)GetComponent("CharacterController");
       
        //updatePosituon();
	}

    // Update is called once per frame
    void Update() {
        Vector3 direction=transform.position;
        float distance = direction.sqrMagnitude;
        vec.y += Physics.gravity.y * Time.deltaTime;
        direction.y = 0f;
        direction = direction.normalized;
        controller.Move(vec * Time.deltaTime);
        
        if (controller.isGrounded)
        {
            vec.y = 0;
        }
        var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Place.position - transform.position), enemy.speed1).eulerAngles;
        newRotation.x = 0;
        transform.rotation = Quaternion.Euler(newRotation);
        //transform.rotation = Quaternion.LookRotation(transform.position - (Place.position - new Vector3(0, 0f, 0)));
        //transform.position -= transform.forward * enemy.speed2;
        transform.position += transform.forward * enemy.speed1;
        /*directionX = transform.position.x - target.position.x;
            if (directionX > 0.6)
        {
            enemy.speed1 = 0.05f;
            enemy.speed2 = 0.05f;
        }*/

        
    }

    void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.tag == "Player")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * enemy.speed1 * Time.deltaTime);
            enemy.speed1 = 0.05f;
            Debug.Log("true");
        }
        if (col.gameObject.tag=="Place")
        {

            enemy.speed1 = 0.0f;
            enemy.speed2 = 0.0f;
        }
        /*if (col.gameObject.tag == "CCC")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * enemy.speed1 * Time.deltaTime);
            enemy.speed1 = 0.0f;
            enemy.speed2 = 0.0f;
            Debug.Log("OK");
        }*/




    }

    void OnTriggerStay(Collider col)
    {
        /*if (col.gameObject.tag == "CCC")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * enemy.speed1 * Time.deltaTime);
            enemy.speed1 = 0.0f;
            enemy.speed2 = 0.0f;
            Debug.Log("message");
        }*/
      if (col.gameObject.tag == "Player")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * enemy.speed1 * Time.deltaTime);
            enemy.speed1 = 0.05f;
            
            //enemy.speed1 = 0.0f;
            //enemy.speed2 = 0.0f;
        }
       
        }

    void OnTriggerExit(Collider other)
    {
        

       if (other.tag == "Player")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * enemy.speed1 * Time.deltaTime);
            enemy.speed1 = 0.05f;
            

        }
        
    }
    void LateUpdate()
    {

    }
}
