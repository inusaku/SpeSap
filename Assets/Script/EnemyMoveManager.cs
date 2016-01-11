using UnityEngine;
using System.Collections;

public class EnemyMoveManager : MonoBehaviour                  //担当者：永江　汎用性はかなぐり捨てています。申し訳ありません。
{                                                              //SerchKyotenメソッドを少し換えればだいぶ汎用性が出るのですが、今回は不要と判断し、かなぐり捨てました。
    public GameObject m_Enemy;                                 //エネミーと拠点の距離をとるために使うGameObject型のメンバ変数です。
    private GameObject m_NearKyoten;                           //一番近い拠点を入れるための、GameObject型のメンバ変数です。

    void Start()                                               //起動時
    {
        m_NearKyoten = SerchKyoten(m_Enemy);                   //m_NearKyotenにSerchKyotenメソッドを使い、初期設定をします。
    }

    void Update()                                              //更新
    {
        m_NearKyoten = SerchKyoten(m_Enemy);                   //m_NearKyotenを起動し、調べなおします。
    }

    GameObject SerchKyoten(GameObject gameObject)              //現地点から一番近くて占拠されていない拠点を探すメソッドです。
    {
        float l_TmpDis = 0;                                    //距離を調べるため一時的に保持するためのローカル変数です。
        float l_NearDis = 99999;                               //最も近い拠点の距離を保持するためのローカル変数です。
        GameObject l_TargetKyoten = null;                      //この時点では拠点を見つけていないためnullを入れておきます。

        foreach (GameObject Kyoten in GameObject.FindGameObjectsWithTag("Place"))//foreachで"Place"というタグの付いたゲームオブジェクトを回します。
        {
            l_TmpDis = Vector3.Distance(Kyoten.transform.position, gameObject.transform.position);//2オブジェクト間の距離を取ります。

            if (l_NearDis > l_TmpDis && Kyoten.GetComponent<BaseCamp>().KyotenCheck() == false)//距離が現在保持している拠点より近く、まだ制圧できていないものならば
            {
                l_NearDis = l_TmpDis;                          //比較用に保持する拠点を近いものに変えて、
                l_TargetKyoten = Kyoten;                       //returnする拠点も近いものに変えます。
            }
        }

        if (l_NearDis == 99999) { Debug.Log("制圧　(`・ω・´)　完了"); }//デバッグ用です。
        else if (l_TargetKyoten == null) { Debug.Log("ぬるぽおおぉぉ(゜∀゜)ぉぉぉぉぉ!!!???"); }//デバッグ用です。
        else { Debug.Log("[" + (float)l_TargetKyoten.transform.position.x + "," + (float)l_TargetKyoten.transform.position.z + "]に向かいますよ～ ﾐ(　つ・ω・)つ"); }//デバッグ用です。

        return l_TargetKyoten;                                 //最も近くて占拠されていない拠点を返します。
    }

    public GameObject NearKyoten()                             //どの拠点が一番近いかを返すメソッドです。
    {
        return m_NearKyoten;                                   //ぬるっと返します。
    }
}
