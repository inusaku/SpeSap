using UnityEngine;
using System.Collections;

public class LR_Hitter : MonoBehaviour
{
    //現在、tagなどの状況が自分には分からなかったのでお手数ですが、
    //こちらのメソッドを書き換えて適応させていただきますようお願い申し上げます。
    //お手数おかけして申し訳ありません。

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == (""))
        {
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == (""))
        {
            Destroy(other.gameObject);
        }
    }
}
