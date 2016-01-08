using UnityEngine;
using System.Collections;

public class CountMAX : MonoBehaviour {
    private GameObject nearObj;
    private float searchTime=0;
    public BaseCamp basecamp;
    public GameObject BaseCamp;

	// Use this for initialization
	void Start () {
        nearObj = serchTag(gameObject, "Place");
        basecamp = BaseCamp.GetComponent<BaseCamp>();
	}
	
	// Update is called once per frame
	void Update () {
        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Place");

            //経過時間を初期化
            searchTime = 0;
        }

        //対象の位置の方向を向く
        transform.LookAt(nearObj.transform);

        //自分自身の位置から相対的に移動する
        transform.Translate(Vector3.forward * 2.0f);
    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        string nearObjName = "BaceCamp";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Place")
        {
            if (basecamp.m_MaxPoint <= 100f)
            {
                nearObj = serchTag(gameObject, "Place");
                //対象の位置の方向を向く
                transform.LookAt(nearObj.transform);

                //自分自身の位置から相対的に移動する
                transform.Translate(Vector3.forward * 2.0f);

            }
        }

    }
}
