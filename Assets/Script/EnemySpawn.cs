using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public GameObject Enemy;    //敵オブジェクト
<<<<<<< HEAD
	public GameObject enemyHP;
    public float count = 1;     //一度に何体のオブジェクトをスポーンさせるか
=======
    public float count = 5;     //一度に何体のオブジェクトをスポーンさせるか
>>>>>>> origin/MIRAI
    public float interval = 5;  //何秒おきに敵を発生させるか
    private float timer;        //経過時間
    private int max_count = 1;
	int enemyCount;
    bool SpawnFlag;

    // Use this for initialization
    void Start () {
        Spawn(); //初期スポーン
    }
	
	// Update is called once per frame
	void Update () {
		enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        timer += Time.deltaTime;    //経過時間加算
        if (timer >= interval)
        {
			SpawnFlag = true;
            if (SpawnFlag)
            {
                Spawn();    //スポーン実行
                timer = 0;  //初期化
				SpawnFlag = false;
            }
        }

    }
    void Spawn()
    {
<<<<<<< HEAD
		if (enemyCount <= 100){
	        for (int i = 0; i < count; i++)
	        {
	            float x = Random.Range(0f, 0f);
	            float z = Random.Range(0f, 0f);
	            Vector3 pos = new Vector3(x, 1f, z) + transform.position;
	            GameObject.Instantiate(Enemy, pos, Quaternion.identity);
				GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
	        }
		}
=======
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(10f, 0f);
            float z = Random.Range(0f, 0f);
            Vector3 pos = new Vector3(x, 1f, z) + transform.position;
            GameObject.Instantiate(Enemy, pos, Quaternion.identity);
        }
>>>>>>> origin/MIRAI
    }
}
