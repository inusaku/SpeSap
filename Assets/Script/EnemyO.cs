using UnityEngine;
using System.Collections;

public class EnemyO : MonoBehaviour {
    public float life = 40;
    public float HP = 40;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Damage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}


