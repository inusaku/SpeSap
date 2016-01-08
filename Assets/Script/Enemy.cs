using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float life = 100;
    public float HP = 100;



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
       
		OnDestroy ();
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
