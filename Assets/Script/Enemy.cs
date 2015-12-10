using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float life = 100;
    public float HP = 100;
    public float speed1 = 0.1f;
    public float speed2 = 0.2f;


	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (life <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        speed1 = 0f;
        speed2 = 0f;
		OnDestroy ();
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
