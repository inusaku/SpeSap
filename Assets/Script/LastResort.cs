using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastResort : MonoBehaviour //LastResort == "最後の手段"の英訳
{
    private bool m_End;                 //動作終了用のbool型
    private bool m_MouseOnOff;          //マウスがクリック(左)されているか確認するためのbool型
    private bool m_UseCheck;            //動作開始用のbool型
    private float m_Counter;            //カウント用のfloat型(現在どれだけチャージされているか等のカウントに使う)

    public ParticleSystem m_LR_Particle;//発動エフェクト用
    public GameObject m_LR_Hitter;      //Hit判定(切り札の当たり判定用)のGameObject
    public Image m_ChargeCircle;        //押している間チャージされるゲージを視覚的に確認できるようにするためのImage
    public int m_MaxTime;               //指定チャージ時間

    void Start()
    {
        m_End = false;                  //初期化(起動していないのでfalse)
        m_MouseOnOff = false;           //初期化
        m_UseCheck = false;             //初期化
        m_Counter = 0;                  //初期化

        m_LR_Hitter.SetActive(false);   //Hit判定は起動時までActive(true)にならないようにする
    }

    void Update()
    {
        if (m_End == true)              //もし1回使用したならば
        {
            return;                     //retrunして何もさせない
        }

        if (m_UseCheck == true)         //もし起動したならば
        {
            UseThis();                  //使用した際の処理を行う
        }
        else if (m_UseCheck == false)   //もし起動していないならば
        {
            MouseCheck();               //マウスがクリックされているかチェックして
            WhatSelect();               //クリックされているなら何をクリックしているかチェックして

            m_ChargeCircle.fillAmount = m_Counter / m_MaxTime;//チャージゲージを表示する
        }
    }

    public void MouseCheck()            //マウスがクリックしているかどうか
    {
        if (Input.GetMouseButton(0))
        {
            m_MouseOnOff = true;
        }
        else
        {
            m_MouseOnOff = false;
        }
    }

    public void WhatSelect()            //何をクリックしているかチェック
    {
        if (m_MouseOnOff == true)       //クリックしているなら
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Rayを画面のクリックした地点に飛ばして
            RaycastHit hit = new RaycastHit();//Rayが当たったかどうかを取得

            if (Physics.Raycast(ray, out hit))//Rayが飛んで当たっているならば
            {

                GameObject obj = hit.collider.gameObject;//当たっているGameObjectを取得

                if (obj == this.gameObject)//もし自身(LastResort)が当たっているなら
                {

                    if (m_Counter >= m_MaxTime)//m_Timer(現チャージ時間)が指定チャージ時間より多いかチェック
                    {
                        m_UseCheck = true;//多かったら起動
                        UseStart();     //起動時処理を行う
                    }
                    else                //多くないなら
                    {
                        m_Counter += 1 * Time.deltaTime;//Timerを足していく
                        //Debug.Log("選択成功");//デバッグ用
                    }

                }
                else    //もし自分が当たっていなかったら(自分以外のGameObjectが選ばれているならば)
                {
                    m_Counter = 0;//m_Timer(現チャージ時間)は0にしておく
                    //Debug.Log("選択失敗");
                }
            }
        }
        else if (m_MouseOnOff == false)//もしクリックされていないならば
        {
            m_Counter = 0;//m_Timer(現チャージ時間)は0にしておく
        }
    }

    private void UseStart()             //起動時処理
    {

        m_LR_Particle.Play();           //パーティクル(エフェクト)を起動
        m_LR_Hitter.SetActive(true);    //Hit判定(を持ったGameObject)を起動
        m_Counter = 3;                  //LastResortの持続時間をここで設定
    }

    public void UseThis()               //実行処理
    {
        m_ChargeCircle.CrossFadeAlpha(m_Counter / 3, 0, true);//表示していたチャージ時間(円形のチャージゲージ)を透明にしていく

        if (m_Counter <= 0)             //もし持続時間が0ならば
        {
            m_ChargeCircle.fillAmount = 0;//表示していたチャージ時間を0にする
            m_ChargeCircle.CrossFadeAlpha(1, 0, false);//チャージ時間のアルファ値を戻しておく
            m_LR_Hitter.SetActive(false);//Hit判定を終了させる
            m_LR_Particle.Stop();       //パーティクル(エフェクト)を止める
            m_End = true;               //実行内容終了
        }
        else                            //もし持続時間が残っているならば
        {
            m_Counter -= 1 * Time.deltaTime;//持続時間を減らしていく
        }
    }
}
