using UnityEngine;
using System.Collections;

public class EMM : MonoBehaviour {

    public GameObject m_Enemy;
    private GameObject m_NearKyoten;

	// Use this for initialization
	void Start () {
	m_NearKyoten= SerchKyoten(m_Enemy);
    }
	
	// Update is called once per frame
	void Update () {
        m_NearKyoten = SerchKyoten(m_Enemy);
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
        return l_TargetKyoten;                                 //最も近くて占拠されていない拠点を返します。
    }

    public GameObject NearKyoten()                             //どの拠点が一番近いかを返すメソッドです。
    {
        return m_NearKyoten;                                   //ぬるっと返します。
    }

}
