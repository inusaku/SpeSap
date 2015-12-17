using UnityEngine;
using System.Collections;

public class Move_Friend : MonoBehaviour {
    private Transform target;
    private Vector3 vec = Vector3.zero;
    public CharacterController controller;
    Friend friend;
    Vector3 F_Position;
    Vector3 F_Rotation;
    public float speed = 3;
    public float limitdistance = 1000f;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Place").transform;
        friend = GetComponent<Friend>();
        controller = (CharacterController)GetComponent("CharacterController");
	
	}

    // Update is called once per frame
    void Update()
    {
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
        var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position + transform.position), friend.speed1).eulerAngles;
        transform.rotation = Quaternion.LookRotation(transform.position - (target.position - new Vector3(0, target.position.y - 0.4f, 0)));
        transform.position -= transform.forward * friend.speed2;

        if (distance >= limitdistance)
        {
            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Place")
        {
            friend.speed1 = 0f;
            friend.speed2 = 0f;
        }
    }
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag=="Place")
        {
            friend.speed1 = 0f;
            friend.speed2 = 0f;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag=="Place")
        {
            friend.speed1 = 0f;
            friend.speed2 = 0f;
        }
        if(col.gameObject.tag=="Friend")
        {
            friend.speed1 = 0.02f;
            friend.speed2 = 0.02f;
        }
    }





}

