using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMoveManager : MonoBehaviour                                                     //担当者：永江　汎用性はかなぐり捨てています。申し訳ありません。
{                                                                                                 //SerchKyotenメソッドを少し換えればだいぶ汎用性が出るのですが、今回は不要と判断し、かなぐり捨てました。
    public GameObject m_Enemy;                                                                    //エネミーと拠点の距離をとるために使うGameObject型のメンバ変数です。
    private GameObject m_Target;
    private bool m_Seiatu;

    void Start()                                                                                  //起動時
    {
        m_Target = SerchTarget(m_Enemy);
        m_Seiatu = false;
    }

    void Update()                                                                                 //更新
    {
        m_Target = SerchTarget(m_Enemy);
    }

    private GameObject SerchTarget(GameObject gameObject)                                         //現地点から一番近くて占拠されていない拠点を探すメソッドです。
    {
        string l_Target = "Place";
        if (m_Seiatu == true) { l_Target = "Player"; }

        float l_TmpDis = 0;                                                                       //距離を調べるため一時的に保持するためのローカル変数です。
        float l_NearDis = 10000;                                                                  //最も近い拠点の距離を保持するためのローカル変数です。
        GameObject l_TargetObject = null;                                                         //この時点では拠点を見つけていないためnullを入れておきます。

        foreach (GameObject Target in GameObject.FindGameObjectsWithTag(l_Target))
        {
            l_TmpDis = Vector3.Distance(Target.transform.position, gameObject.transform.position);//2オブジェクト間の距離を取ります。

            if (m_Seiatu == true && l_NearDis > l_TmpDis)
            {
                l_NearDis = l_TmpDis;
                l_TargetObject = Target;
            }
            else if (Target.GetComponent<BaseCamp>().KyotenCheck() == false && l_NearDis > l_TmpDis)//距離が現在保持している拠点より近く、まだ制圧できていないものならば
            {
                l_NearDis = l_TmpDis;                                                            //比較用に保持する拠点を近いものに変えて、
                l_TargetObject = Target;                                                         //returnする拠点も近いものに変えます。
                m_Seiatu = false;
            }
        }

        if (l_TargetObject == null)
        {
            if (m_Seiatu == false) { m_Seiatu = true; }

            if (m_Seiatu == true) { l_TargetObject = NullSerch("Player"); }

            if (l_TargetObject == null){ l_TargetObject = NullSerch("Place"); }
        }

		return l_TargetObject;
    }

    private GameObject NullSerch(string tag)
    {
        float l_TmpDis = 0;
        float l_NearDis = 10000;
        GameObject l_TargetObject = null;

        foreach (GameObject Target in GameObject.FindGameObjectsWithTag(tag))
        {
            l_TmpDis = Vector3.Distance(Target.transform.position, this.gameObject.transform.position);

            if (l_NearDis > l_TmpDis)
            {
                l_NearDis = l_TmpDis;
                l_TargetObject = Target;
            }
        }

        return l_TargetObject;
    }//Nullを殺すための機械

    public GameObject NearTarget()
    {
        return m_Target;
    }
}
