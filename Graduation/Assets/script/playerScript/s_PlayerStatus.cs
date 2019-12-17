using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>体力や状態</summary>
public class s_PlayerStatus : MonoBehaviour
{
    ///<summary>HPの最大値</summary>
    public int maxHp;
    ///<summary>現在のHP</summary>
    private int hp;
    ///<summary>死んでいるか</summary>
    private bool isDaed;
    ///<summary>プレイ時間（秒）</summary>
    private float playSecond;
    ///<summary>プレイ時間（分）</summary>
    private float playMinute;
    ///<summary>プレイ時間（時）</summary>
    private float playHour;

    void Awake()
    {
        //hpを初期化
        Recovery(maxHp);
        //テキストに表示
        GameObject.Find("HpText").GetComponent<s_PlayerHpUI>().SetText(hp.ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayTimerUpdate();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(playHour+":"+playMinute+":"+playSecond);
        }
    }
    ///<summary>現在のHPを取得</summary>
    public int GetHp()
    {
        return hp;
    }
    ///<summary>HPを回復</summary>
    public void Recovery(int num)
    {
        //回復後の体力が最大値以上なら最大値に
        if(hp+num>=maxHp)
        {
            hp = maxHp;
            GameObject.Find("HpText").GetComponent<s_PlayerHpUI>().SetText(hp.ToString());
            return;
        }
        hp += num;
        GameObject.Find("HpText").GetComponent<s_PlayerHpUI>().SetText(hp.ToString());
    }
    ///<summary>最大Hpを増加</summary>
    public void MaxHpUp(int num)
    {
        maxHp += num;
    }
    ///<summary>ダメージを受ける</summary>
    public void Damage(int num)
    {
GameObject.Find("DameImage").GetComponent<s_damageCamera>().On();
        hp -= num;
        GameObject.Find("HpText").GetComponent<s_PlayerHpUI>().SetText(hp.ToString());
    }
    ///<summary>死亡状態の変更</summary>
    public void SetIsDead(bool b)
    {
        isDaed = b;
    }
    ///<summary>死亡状態の取得</summary>
    public bool GetIsDead()
    {
        return isDaed;
    }

    ///<summary>プレイヤーが死んでいるか確認、死んでいたらシーンをタイトルへ（引数は自分のTransformで呼び出す）</summary>
    public void DeadChack(Transform tran)
    {
        //プレイヤー以外から呼び出さないよう
        if (tran.name != "o_player")
            return;

        if(hp<=0)
        {
            SetIsDead(true);
            GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("TitleH");
        }
    }

    private void PlayTimerUpdate()
    {
        playSecond += Time.deltaTime;

        if(playSecond>=60)
        {
            playSecond -= 60;
            playMinute += 1;
        }
        if (playMinute>= 60)
        {
            playMinute -= 60;
            playHour += 1;
        }
    }
    ///<summary>プレイタイムをセット</summary>
    public void PlayTimerSet(float h,float m ,float s)
    {
        playHour = h;
        playMinute = m;
        playSecond = s;
    }
    ///<summary>プレイ時間（時）を取得</summary>
    public float GetPlayHour()
    {
        return playHour;
    }
    ///<summary>プレイ時間（分）を取得</summary>
    public float GetPlayMinute()
    {
        return playMinute;
    }
    ///<summary>プレイ時間（秒）を取得</summary>
    public float GetPlaySecond()
    {
        return playSecond;
    }
}
