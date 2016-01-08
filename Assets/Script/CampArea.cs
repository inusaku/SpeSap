using UnityEngine;
using System.Collections;

public class CampArea : MonoBehaviour//担当者：永江
{
    public GameObject ThisAreaObject;//AreaObject(拠点の取得可能範囲担当オブジェクトを入れてください)
    public GameObject CampObject;    //CampObject(このAreaObjectと関連付ける拠点自身を入れてください)
    public GameObject Player;        //Player(プレイヤー自身を入れてください)
    private GameObject Enemy;         //Enemy(エネミー役自身を入れてください)
    public float AreaSize;           //Areaの直径を入力してください

    private bool m_Player = false;   //半径に入っている場合はtrue
    private bool m_Enemy = false;    //半径に入っている場合はtrue

    void Start()
    {
//        ThisAreaObject.transform.position = CampObject.transform.position;//位置の中心をCampObjectに強制的にあわせます
//        ThisAreaObject.transform.localScale = new Vector3(AreaSize, 0.2f, AreaSize);//半径＝入力値の半分です
        //このスクリプトをつけたオブジェクトのScaleはAreaSizeと同じものにしておくととてもわかりやすくなると思います
    }

    void Update()
    {
		Enemy = GameObject.Find ("EnemyO(Clone)");
		Player = GameObject.Find ("Player");
        DistanceP_C();
        DistanceE_C();
        Checker();
	}

    private void DistanceP_C()//拠点とPlayer・Campの距離を調べて一定以内なら拠点占拠ポイントを加算
    {
        if (Player == null) { return; }
        Vector3 camp_posi = CampObject.transform.position;
        Vector3 player_posi = Player.transform.position;

        float dis_1 = Vector3.Distance(camp_posi, player_posi);

        if (dis_1 <= AreaSize / 2)
        {
            m_Player = true;
            print("Playerがtrueになりました");
        }
        else if (dis_1 > AreaSize / 2)
        {
            m_Player = false;
            print("Playerがfalseになりました");
        }
    }

    private void DistanceE_C()//拠点とEnemy・Campの距離を調べて一定以内なら拠点占拠ポイントを加算
    {
        if (Enemy == null) { return; }
        Vector3 camp_posi = CampObject.transform.position;
        Vector3 enemy_posi = Enemy.transform.position;
        
        float dis_2 = Vector3.Distance(camp_posi, enemy_posi);
        
        if (dis_2 <= AreaSize / 2)
        {
            m_Enemy = true;
            print("Enemyがtrueになりました");
        }
        else if (dis_2 > AreaSize / 2)
        {
            m_Enemy = false;
            print("Enemyがfalseになりました");
        }
    }

    private void Checker()//boolをチェックしてBaseCamp内部のメソッドをに働きかける
    {
        if (m_Player == true)
        {
            CampObject.gameObject.SendMessage("GetCampPlayer", SendMessageOptions.DontRequireReceiver);
            //print("Playerの占領ポイントを加算しています");//デバッグ用
        }

        if (m_Enemy == true)
        {
            CampObject.gameObject.SendMessage("GetCampEnemy", SendMessageOptions.DontRequireReceiver);
            //print("Enemyの占領ポイントを加算しています");//デバッグ用
        }
    }
}
