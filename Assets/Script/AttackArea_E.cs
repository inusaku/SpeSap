using UnityEngine;
using System.Collections;

public class AttackArea_E : MonoBehaviour
{
    public float attack = 10f;
	public float timer;
	bool isDamage;
    // Use this for initialization
    void Start()
    {
		isDamage = false;
		timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if(isDamage){
			timer += Time.deltaTime;
		}
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			isDamage = true;
			if(timer > 3){
				other.GetComponent<PlayerStatus>().HP -= attack;
				timer = 0;
			}
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			isDamage = false;
			timer = 0;
		}
	}
}
