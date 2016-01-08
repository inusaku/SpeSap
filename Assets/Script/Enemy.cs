using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float life = 100;
    public float HP = 100;
    public float speed1 = 0.1f;
    public float speed2 = 0.2f;
	public GameObject gage;
	public float point;

	// Use this for initialization
	void Start () {
		gage = GameObject.Find ("SkillGage");
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
		gage.GetComponent<SkillGageSC> ().SkillPoint +=point;
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
