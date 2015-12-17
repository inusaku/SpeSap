using UnityEngine;
using System.Collections;

public class Friend_Spawn : MonoBehaviour {
    public GameObject Friend;
    public float count = 5;
    public float interval = 5;
    private float timer;
    private int max_count = 5;
    bool SpawnFlag;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            if(SpawnFlag)
            {
                Spawn();
                timer = 0;
            }
        }
	}
    void Spawn()
    {
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(10f, 0f);
            float z = Random.Range(0f, 0f);
            Vector3 pos = new Vector3(x, 1f, z) + transform.position;
            GameObject.Instantiate(Friend, pos, Quaternion.identity);
        }
    }

}
