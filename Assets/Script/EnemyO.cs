using UnityEngine;
using System.Collections;

public class EnemyO : MonoBehaviour {
    public float life = 40;
    public float HP = 40;
    public float speed1 = 0.1f;
    public float speed2 = 0.1f;

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
        speed1 = 0f;
        speed2 = 0f;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}


