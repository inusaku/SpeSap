using UnityEngine;
using System.Collections;

public class AttackArea_E : MonoBehaviour
{
    private GameObject player;
    private float atk;
    public float recast;
    public GameObject Enemy;
    private GameObject kyoten;
    public GameObject normalhitpar;
    //public float timer;
    //bool isDamage;
    // Use this for initialization
    //private bool isQuitting = false;

    void Start()
    {
        atk = Enemy.GetComponent<Enemy>().atk;
        //isDamage = false;
        //timer = 0;
    }
    void Attack()
    {
        Damage(atk);
        Debug.Log("HIT");
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isDamage){
            //timer += Time.deltaTime;
        }*/
    }

    void Damage(float damage)
    {
        if (player != null)
        {
            player.GetComponent<PlayerStatus>().HP -= damage;
            Instantiate(normalhitpar, player.transform.position, Quaternion.identity);
        }
        else if (kyoten != null)
        {
            kyoten.GetComponent<SpaceLife>().Life -= damage;
            Instantiate(normalhitpar, kyoten.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("Damage", atk);
            Debug.Log("OK");
            player = other.gameObject;
            kyoten = null;
            InvokeRepeating("Attack", recast, recast);
        }
        else if (other.gameObject.tag == "kyoten")
        {
            if (other.gameObject.name == "P_kyoten_A")
            {
                kyoten = other.gameObject;
                player = null;
                InvokeRepeating("Attack", recast, recast);
            }
        }

    }


}
