﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseCamp : MonoBehaviour//担当者：永江
{
    public GameObject m_actersPrefab_Player;//Player側の生産物を入れてください
    public GameObject m_actersPrefab_Enemy; //Enemy側の生産物を入れてください
    public float m_Interbal;                //一回生産した後に何秒待つか入力してください
    public int m_Number;                    //一回に何体生産するか入力してください
    public float m_PubMaxPoint;             //MaxPoint_pubという名の通りMaxPointの指定用public intです

    private GameObject m_NowProduct;        //現在生産予定のGameObject
    private Vector2 m_MaxNumber;            //InterbalとNumberの最大値を保存しておくためのVector2です
    private float m_Counter;                //拠点占拠ポイントをカウント(加算)して使用するためのfloatです
    private int m_PlayerNumber;             //Playerの種類(右側(1) or 左側(2)　|　Player(1) or Enemy(2)　等々の種類分け)です
    public int m_MaxPoint;               //拠点占拠ポイントの最大値(試験運用用に[public]を用意してありますが、
                                            //細かく決まった場合は[private]のみにして、コンストラクタで指定する予定です)
	private Slider enemySlider;
	private Slider playerSlider;
	float enemySliVal;
	float playerSliVal;
    float playerHP;
	float enemyHP;

	public bool isKyote_A;
	public bool isKyote_B;
	public bool isKyote_C;
	public bool isKyote_D;
	public bool isKyote_E;
	public bool isKyote_F;
	public float speed;
	void Start()
    {
		isKyote_A = false;
		isKyote_B = false;
		isKyote_C = false;
		isKyote_D = false;
		isKyote_E = false;
		isKyote_F = false;
		m_MaxNumber.x = m_Interbal;
        m_MaxNumber.y = m_Number;
        m_MaxPoint = (int)m_PubMaxPoint / 2;            //マイナス(最大値 / 2) <= 0 <= プラス(最大値 / 2)　が拠点占拠ポイントの範囲になります

        m_NowProduct = null;
        m_Counter = 0;
        m_PlayerNumber = 0;
		speed = 0;
		if(this.gameObject.name == "kyoten_A"){
			enemySlider = GameObject.Find("ui_P_kyotenHP_A").GetComponent<Slider>();
			playerSlider = GameObject.Find("ui_E_kyotenHP_A").GetComponent<Slider>();
		}
		if(this.gameObject.name == "kyoten_B"){
			enemySlider = GameObject.Find("ui_P_kyotenHP_B").GetComponent<Slider>();
			playerSlider = GameObject.Find("ui_E_kyotenHP_B").GetComponent<Slider>();
		}
		if(this.gameObject.name == "kyoten_C"){
			enemySlider = GameObject.Find("ui_P_kyotenHP_C").GetComponent<Slider>();
			playerSlider = GameObject.Find("ui_E_kyotenHP_C").GetComponent<Slider>();
		}
		if(this.gameObject.name == "kyoten_D"){
			enemySlider = GameObject.Find("ui_P_kyotenHP_D").GetComponent<Slider>();
			playerSlider = GameObject.Find("ui_E_kyotenHP_D").GetComponent<Slider>();
		}
		if(this.gameObject.name == "kyoten_E"){
			enemySlider = GameObject.Find("ui_P_kyotenHP_E").GetComponent<Slider>();
			playerSlider = GameObject.Find("ui_E_kyotenHP_E").GetComponent<Slider>();
		}
		if(this.gameObject.name == "kyoten_F"){
			enemySlider = GameObject.Find("ui_P_kyotenHP_F").GetComponent<Slider>();
			playerSlider = GameObject.Find("ui_E_kyotenHP_F").GetComponent<Slider>();
		}

		enemySliVal = 15;
		playerSliVal = 15;
		if (Application.loadedLevelName == "Stage02") {
			if (this.gameObject.name == "kyoten_F") {
				playerHP = 30;
				enemyHP = 0;
				m_Counter = 15;
			} else if (this.gameObject.name == "kyoten_D") {
				playerHP = 0;
				enemyHP = 30;
				m_Counter = -15;
			} else {
				playerHP = 15;
				enemyHP = 15;
			}
		} else {
			playerHP = 15;
			enemyHP = 15;
		}
	}
	
	void Update()
    {
		if (playerHP > 20f) {
			GetComponent<Renderer> ().material.color = Color.blue;
			if(this.gameObject.name == "kyoten_A"){
				GameObject.Find("base_kyoten_A").tag = "kariKyoten";
			}
			if(this.gameObject.name == "kyoten_B"){
				GameObject.Find("base_kyoten_B").tag = "kariKyoten";
			}
			if(this.gameObject.name == "kyoten_C"){
				GameObject.Find("base_kyoten_C").tag = "kariKyoten";
			}
			if(this.gameObject.name == "kyoten_D"){
				GameObject.Find("base_kyoten_D").tag = "kariKyoten";
			}
			if(this.gameObject.name == "kyoten_E"){
				GameObject.Find("base_kyoten_E").tag = "kariKyoten";
			}
			if(this.gameObject.name == "kyoten_F"){
				GameObject.Find("base_kyoten_F").tag = "kariKyoten";
			}
			this.tag = "Place";
		} else if (playerHP > 10f && playerHP < 20f) {
			GetComponent<Renderer> ().material.color = Color.green;
			this.tag = "Place";
			if(this.gameObject.name == "kyoten_A"){
				GameObject.Find("base_kyoten_A").tag = "Respawn";
				isKyote_A = false;
			}
			if(this.gameObject.name == "kyoten_B"){
				GameObject.Find("base_kyoten_B").tag = "Respawn";
				isKyote_B = false;
			}
			if(this.gameObject.name == "kyoten_C"){
				GameObject.Find("base_kyoten_C").tag = "Respawn";
				isKyote_C = false;
			}
			if(this.gameObject.name == "kyoten_D"){
				GameObject.Find("base_kyoten_D").tag = "Respawn";
				isKyote_D = false;
			}
			if(this.gameObject.name == "kyoten_E"){
				GameObject.Find("base_kyoten_E").tag = "Respawn";
				isKyote_E = false;
			}
			if(this.gameObject.name == "kyoten_F"){
				GameObject.Find("base_kyoten_F").tag = "Respawn";
				isKyote_F = false;
			}
		} else if(playerHP >= 0f && playerHP < 10f){
			GetComponent<Renderer> ().material.color = Color.red;
			this.tag = "Place";
			if(this.gameObject.name == "kyoten_A"){
				GameObject.Find("base_kyoten_A").tag = "Respawn";
				isKyote_A = true;
			}
			if(this.gameObject.name == "kyoten_B"){
				GameObject.Find("base_kyoten_B").tag = "Respawn";
				isKyote_B = true;
			}
			if(this.gameObject.name == "kyoten_C"){
				GameObject.Find("base_kyoten_C").tag = "Respawn";
				isKyote_C = true;
			}
			if(this.gameObject.name == "kyoten_D"){
				GameObject.Find("base_kyoten_D").tag = "Respawn";
				isKyote_D = true;
			}
			if(this.gameObject.name == "kyoten_E"){
				GameObject.Find("base_kyoten_E").tag = "Respawn";
				isKyote_E = true;
			}
			if(this.gameObject.name == "kyoten_F"){
				GameObject.Find("base_kyoten_F").tag = "Respawn";
				isKyote_F = true;
			}
		}
        CampPointChecker();
        MakerChecker();
        //print("現在のカウンターは[" + m_Counter + "]");//デバッグ用
    }

	public void GetCampPlayer()//拠点占拠ポイント加算(Player)
	{
		m_Counter += speed * Time.deltaTime;
		if(enemyHP >= 0f){
			enemyHP -= speed * Time.deltaTime;
		}
		if(playerHP <= 30f){
			playerHP += speed * Time.deltaTime;
		}
		enemySliVal = enemyHP;
		playerSliVal = playerHP;
		enemySlider.value = enemySliVal;
		playerSlider.value = playerSliVal;
        //print("Player側に加算しました");//デバッグ用
    }

    public void GetCampEnemy()//拠点占拠ポイント加算(Enemy)
    {
		m_Counter += speed * Time.deltaTime;
		if (enemyHP <= 30f) {
			enemyHP -= speed * Time.deltaTime;
		}
		if (playerHP >= 0f) {
			playerHP += speed * Time.deltaTime;
		}
		enemySliVal = enemyHP;
		playerSliVal = playerHP;
		enemySlider.value = enemySliVal;
		playerSlider.value = playerSliVal;
//		print("Enemy側に加算しました");//デバッグ用
    }

    private void CampPointChecker()//拠点ポイントのチェック(±MaxPoint / 3点を超えると獲得)(-MaxPoint <= 0 <= MaxPoint)
    {
        if (m_Counter > (float)m_MaxPoint / 3)
        {
            m_PlayerNumber = 1;
            if (m_Counter >= m_MaxPoint)
            {
                m_Counter = m_MaxPoint;
            }
        }
        else if (m_Counter < (float)-m_MaxPoint / 3)
        {
            m_PlayerNumber = 2;
            if (m_Counter <= -m_MaxPoint)
            {
                m_Counter = -m_MaxPoint;
            }
        }

        if (m_Counter <= m_MaxPoint / 3 && m_PlayerNumber == 1)
        {
            m_PlayerNumber = 0;
        }

        if (m_Counter >= -m_MaxPoint / 3 && m_PlayerNumber == 2)
        {
            m_PlayerNumber = 0;
        }
    }

    private void MakerChecker()//仲間生産機のインターバルと生産数を管理
    {
        if (m_PlayerNumber == 0) { return; }//PlayerNumber == 0 は誰も占拠していない状況なので、return

        if (m_Interbal <= 0)
        {
            if (m_Number > 0)
            {
                m_Number -= 1;
                ActerMaker();
                //print("PlayerNumber側生産中です");//デバッグ用
                //現在、PlayerNumber 1 = Player || 2 = Enemy となっています
            }
            else if (m_Number <= 0)
            {
                m_Interbal = m_MaxNumber.x;
                m_Number = (int)m_MaxNumber.y;
                //print("生産終了ですです");//デバッグ用
            }
        }
        else if (m_Interbal > 0)
        {
            m_Interbal -= 1 * Time.deltaTime;
            //print("休息中です");//デバッグ用
        }
    }

    private void ActerMaker()//仲間生産機本体
    {
        if (m_PlayerNumber == 0) { return; }

        if (m_PlayerNumber == 1) {
		} else if (m_PlayerNumber == 2) {
		//	m_NowProduct = Instantiate (m_actersPrefab_Enemy);
			//print("acters = Enemyです");//デバッグ用
		} else {
			this.tag = "place";
			if(this.gameObject.name == "kyoten_A"){
				GameObject.Find("base_kyoten_A").tag = "Respawn";
			}
			if(this.gameObject.name == "kyoten_B"){
				GameObject.Find("base_kyoten_B").tag = "Respawn";
			}
			if(this.gameObject.name == "kyoten_C"){
				GameObject.Find("base_kyoten_C").tag = "Respawn";
			}
			if(this.gameObject.name == "kyoten_D"){
				GameObject.Find("base_kyoten_D").tag = "Respawn";
			}
			if(this.gameObject.name == "kyoten_E"){
				GameObject.Find("base_kyoten_E").tag = "Respawn";
			}
			if(this.gameObject.name == "kyoten_F"){
				GameObject.Find("base_kyoten_F").tag = "Respawn";
			}
		}

        //召還位置を(Random.Range.(こ, こ))の二つの値の間のランダムから決定する(X, Y, Z の各種設定可能)ための記述です
/*        m_NowProduct.GetComponent<Rigidbody>().position = new Vector3(Random.Range(-1f, 1f),
                                                                      Random.Range(0.5f, 0.5f),
                                                                      Random.Range(-1f, 1f));

        //召還後のVelocity(移動速度)を上記と同じ方法でランダム決定するための記述です
        m_NowProduct.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5f, 5f),
                                                                      Random.Range(0.5f, 0.5f),
                                                                      Random.Range(-5f, 5f));
        //print("actersを生産しました");//デバッグ用
<<<<<<< HEAD
*/    }
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			speed ++;
		}
		if(col.gameObject.tag == "Enemy"){
			speed --;
		}
	} 
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			speed --;
		}
		if(col.gameObject.tag == "Enemy"){
			speed ++;
		}
	} 
	public bool KyotenCheck()//Enemyの挙動用に、Enemy側が占拠しているかどうかをReturnするメソッドを追加しました(永江.1月9日)
	{
		if (m_Counter <= -14.3)//試験運用中に最後の拠点のm_Counterが[-14.68~~]で止まってしまうバグが発生していたためコレを追加しました。
		{//仮にゲーム中にm_Counterが[-15]になりきらずとも、視覚的にゲージがMaxでしっかり占拠できている場合は次の拠点を狙います。
			return true;
		}
		
		return false;
	}
}
