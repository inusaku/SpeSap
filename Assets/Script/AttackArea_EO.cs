using UnityEngine;
using System.Collections;

public class AttackArea_EO : MonoBehaviour {
    public float attack;
	private GameObject enemy;
	private bool isAtk;
	private float timer;
    // Use this for initialization
    void Start () {
		isAtk = false;
		timer = 0;
		attack = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAtk == true) {
			timer += Time.deltaTime;
			if (timer > 5f) {
				enemy.SendMessage ("Damage", attack);
				timer = 0f;
			}
		} else {
			timer = 0f;
		}
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
			isAtk = true;
			enemy = other.gameObject;
        }
    }
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			isAtk = false;
			enemy = null;
		}
	}
}
