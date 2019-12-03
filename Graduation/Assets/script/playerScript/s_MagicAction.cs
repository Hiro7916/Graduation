using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>プレイヤーの魔法アクション</summary>
public class s_MagicAction : MonoBehaviour
{
    ///<summary>現在セットしている魔法の名前表示UI</summary>
    public GameObject magicUI;
    ///<summary>現在の魔法のレベル表示UI</summary>
    public GameObject magicLvUI;
    ///<summary>現在の魔法の番号</summary>
    private int nowMagicNumber;
    ///<summary>現在発動した魔法</summary>
    private GameObject activeParticl;
    ///<summary>最後に発動したオブジェクト</summary>
    private GameObject preParticl;

    // Start is called before the first frame update
    void Start()
    {
        //魔法の番号を0番目に初期化
        nowMagicNumber = 0;
        //選択中の魔法の名前を表示
        string str = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).name;
        magicUI.GetComponent<s_MagicUI_Control>().UI_Change(str.Remove(0, 2));
        //lv表表示の変更
        int lv = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetLv();
        magicLvUI.GetComponent<s_MagicLvControl>().ChengeText(lv.ToString());
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void MagicUpdate(Transform tra)
    {
        //プレイヤー以外からの呼び出しを受け付けない
        if (tra.tag != "Player")
            return;

        ChangeNowMagicNumber();
        PlayMagic();
    }
    ///<summary>選択中の魔法を切り替える</summary>
    private void ChangeNowMagicNumber()
    {
        ChanegeNowMagicNumUp();
        ChanegeNowMagicNumDown();
    }
    ///<summary>選択魔法を次に切り替える</summary>
    private void ChanegeNowMagicNumUp()
    {
        //コントローラーのR1かKキーが押されたとき
        if (Input.GetButtonDown("R_Trigger")||Input.GetKeyDown(KeyCode.K))
        {
            //番号を増やしたときリストの範囲外にあるか
            if (nowMagicNumber < GetComponent<s_PlayerHaveMagic>().GetHaveMagicCount() - 1)
                nowMagicNumber++;
            else
                nowMagicNumber = 0;

            //選択中の魔法の名前を表示
            string str = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).name;
            magicUI.GetComponent<s_MagicUI_Control>().UI_Change(str.Remove(0, 2));

            //lv表表示の変更
            int lv = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetLv();
            magicLvUI.GetComponent<s_MagicLvControl>().ChengeText(lv.ToString());
        }
    }
    ///<summary>選択魔法を前に戻す</summary>
    private void ChanegeNowMagicNumDown()
    {
        //コントローラーのL1かHキーが押されたとき
        if (Input.GetButtonDown("L_Trigger") || Input.GetKeyDown(KeyCode.H))
        {
            //番号を減らしたときリストの範囲外にあるか
            if (nowMagicNumber > 0)
                nowMagicNumber--;
            else
                nowMagicNumber = GetComponent<s_PlayerHaveMagic>().GetHaveMagicCount() - 1;

            //選択中の魔法の名前を表示
            string str = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).name;
            magicUI.GetComponent<s_MagicUI_Control>().UI_Change(str.Remove(0, 2));

            //lv表表示の変更
            int lv = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetLv();
            magicLvUI.GetComponent<s_MagicLvControl>().ChengeText(lv.ToString());
        }
    }
    ///<summary>現在選択中の魔法に経験値を追加</summary>
    public void AddExp(int num)
    {
        //経験値を追加
        GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().AddExp(num);

        //lv表表示の変更
        int lv = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetLv();
        magicLvUI.GetComponent<s_MagicLvControl>().ChengeText(lv.ToString());
    }


    ///<summary>魔法を使う</summary>
    void PlayMagic()
    {
        //ボタンが押された瞬間
        if (Input.GetKeyDown(KeyCode.P)||Input.GetButtonDown("B"))
        {
            //現在の魔法を取得
            activeParticl = GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetNowMagicObject();

            //回転の初期化
            Quaternion quat = new Quaternion();
            quat.Normalize();

            //オブジェクトの生成
            GameObject par = Instantiate(activeParticl, GameObject.Find("ParticleManager").transform.position, quat);
            //パーティクルにLvを設定
            par.GetComponent<s_ParticleControl>().SetLv(GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetLv());
            Debug.Log(GetComponent<s_PlayerHaveMagic>().GetMagic(GetComponent<s_PlayerHaveMagic>().GetMagicNames()[nowMagicNumber]).GetComponent<s_MagicObjectControl>().GetLv());
            //オブジェクトに情報を渡す
            s_ParticleControl pa=  par.GetComponent<s_ParticleControl>();
            //ボタンが押された瞬間をオブジェクトに知らせる
            pa.SetState("Down");
            //プレイヤーが向いている方向に
            pa.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
            //カメラとの向きと同じ方向に向かせるため親オブジェクトにメインカメラを設定
            par.transform.parent = GameObject.Find("Main Camera").transform;

            //オブジェクトが保存されていた場合
            if (preParticl != null)
            {
                //保存されていたおbジェクトに新しいオブジェクトを保存したことを知らせる
                preParticl.GetComponent<s_ParticleControl>().SetState("Next");
            }

            //キーが押し続けられた場合や離された瞬間を知らせるため一時的にオブジェクトを保存
            preParticl = par;

        }
        //ボタンが押されている間
        if (Input.GetKey(KeyCode.P)||Input.GetButton("B"))
        {
            //保存されたオブジェクトがなければ何もしない
            if (preParticl != null)
            {
                //ボタンが押され続けている事を知らせる
                preParticl.GetComponent<s_ParticleControl>().SetState("Keep");
            }

        }
        //ボタンが離されたことを知らせる
        if (Input.GetKeyUp(KeyCode.P)||Input.GetButtonUp("B"))
        {
            if (preParticl != null)
            {
                preParticl.GetComponent<s_ParticleControl>().SetState("Up");
            }

        }
    }
}
