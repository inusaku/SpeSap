using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
    public GameObject Enemy;    //敵オブジェクト
	public GameObject enemyHP;
    public float count = 1;     //一度に何体のオブジェクトをスポーンさせるか
    public float interval = 5;  //何秒おきに敵を発生させるか
    private float timer;        //経過時間
    private int max_count = 1;
	int enemyCount;
    bool SpawnFlag;
	static public bool isDie_A;
	static public bool isDie_B;
    // Use this for initialization
    void Start () {
		isDie_A = false;
		isDie_B = false;
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
		if (enemyCount <= 100){
	        for (int i = 0; i < count; i++)
	        {
				if(GameObject.Find ("kyoten_A").GetComponent<BaseCamp>().isKyote_A == true){
					float x = Random.Range(5f, 0f);
					float z = Random.Range(5f, 0f);
					Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_A").transform.position;
					GameObject.Instantiate(Enemy, pos, Quaternion.identity);
					GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
				}
				if(GameObject.Find ("kyoten_B").GetComponent<BaseCamp>().isKyote_B == true){
					float x = Random.Range(5f, 0f);
					float z = Random.Range(5f, 0f);
					Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_B").transform.position;
					GameObject.Instantiate(Enemy, pos, Quaternion.identity);
					GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
				}
				if(GameObject.Find ("kyoten_C").GetComponent<BaseCamp>().isKyote_C == true){
					float x = Random.Range(5f, 0f);
					float z = Random.Range(5f, 0f);
					Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_C").transform.position;
					GameObject.Instantiate(Enemy, pos, Quaternion.identity);
					GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
				}
				if(Application.loadedLevelName == "Stage02"){
					if(GameObject.Find ("kyoten_D").GetComponent<BaseCamp>().isKyote_D == true){
						float x = Random.Range(5f, 0f);
						float z = Random.Range(5f, 0f);
						Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_D").transform.position;
						GameObject.Instantiate(Enemy, pos, Quaternion.identity);
						GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
					}
					if(GameObject.Find ("kyoten_E").GetComponent<BaseCamp>().isKyote_E == true){
						float x = Random.Range(5f, 0f);
						float z = Random.Range(5f, 0f);
						Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_E").transform.position;
						GameObject.Instantiate(Enemy, pos, Quaternion.identity);
						GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
					}
					if(GameObject.Find ("kyoten_F").GetComponent<BaseCamp>().isKyote_F == true){
						float x = Random.Range(5f, 0f);
						float z = Random.Range(5f, 0f);
						Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_F").transform.position;
						GameObject.Instantiate(Enemy, pos, Quaternion.identity);
						GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
					}
				}
				if(Application.loadedLevelName == "Stage03"){
					if(GameObject.Find ("kyoten_D").GetComponent<BaseCamp>().isKyote_D == true){
						float x = Random.Range(5f, 0f);
						float z = Random.Range(5f, 0f);
						Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_D").transform.position;
						GameObject.Instantiate(Enemy, pos, Quaternion.identity);
						GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
					}
					if(GameObject.Find ("kyoten_E").GetComponent<BaseCamp>().isKyote_E == true){
						float x = Random.Range(5f, 0f);
						float z = Random.Range(5f, 0f);
						Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("kyoten_E").transform.position;
						GameObject.Instantiate(Enemy, pos, Quaternion.identity);
						GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
					}
				}
				if(!isDie_A){
					float x = Random.Range(5f, 0f);
					float z = Random.Range(5f, 0f);
					Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("E_kyoten_A").transform.position;
					GameObject.Instantiate(Enemy, pos, Quaternion.identity);
					GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
				}

				if(Application.loadedLevelName == "Stage02" || Application.loadedLevelName == "Stage03" ){
					if(!isDie_B){
						float x = Random.Range(5f, 0f);
						float z = Random.Range(5f, 0f);
						Vector3 pos = new Vector3(x, 0.013f, z) + GameObject.Find ("E_kyoten_B").transform.position;
						GameObject.Instantiate(Enemy, pos, Quaternion.identity);
						GameObject.Instantiate(enemyHP, new Vector3(10000,0,0), Quaternion.identity);
					}
				}
			}
		}
	}
}