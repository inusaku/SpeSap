using UnityEngine;
using System.Collections;

public class AttackArea_EO : MonoBehaviour {
    public float attack = 10f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("Damage", attack);
        }
    }
}
