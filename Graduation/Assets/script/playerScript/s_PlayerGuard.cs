using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//end
///<summary>プレイヤーのガード</summary>
public class s_PlayerGuard : MonoBehaviour
{
    // Start is called before the first frame update
    ///<summary>ガードしているか(falseがしていない状態)</summary>
    private bool guardOn;
    ///<summary>ガードできない状態か(trueができない状態)</summary>
    private bool guardWaitOn;
    ///<summary>ガードできる範囲(正面からの角度)</summary>
    public float guardAngleRange;
    #region タイマー
    ///<summary>ガードできる時間を保存</summary>
    public float guardSaveTimer;
    ///<summary>実際にカウントするタイマー</summary>
    private int guardTimer;
    ///<summary>ガードでできない時間を保存</summary>
    public float guardWaitSaveTimer;
    ///<summary>実際にカウントするタイマー</summary>
    private int guardWaitTimer;
    #endregion
    void Start()
    {
        //ガード状態の初期化
        guardOn = false;
        guardWaitOn = false;
        //タイマーのセット
        SetGuardTimer(guardSaveTimer);
        SetGuardWaitTimer(guardWaitSaveTimer);
   
    }
    // Update is called once per frame
    void Update()
    {

    }

    #region タイマー
    ///<summary>ガードタイマーのセット(引数でセット)</summary>
    public void SetGuardTimer(float set)
    {
        float time = set * 60;
        guardTimer = (int)time;
    }
    ///<summary>ガードタイマーのセット(保存用タイマーでセット)</summary>
    public void SetGuardTimer()
    {
        float time = guardSaveTimer * 60;
        guardTimer = (int)time;
    }

    ///<summary>保存用タイマーのセット</summary>
    public void SetGuardSetTimer(float set)
    {
        guardSaveTimer = set;
    }
    ///<summary>ガード待機タイマーのセット(引数でセット)</summary>
    public void SetGuardWaitTimer(float set)
    {
        float time = set * 60;
        guardWaitTimer = (int)time;
    }
    ///<summary>ガード待機タイマーのセット(保存用タイマーでセット)</summary>
    public void SetGuardWaitTimer()
    {
        float time = guardWaitSaveTimer * 60;
        guardWaitTimer = (int)time;
    }
    ///<summary>保存用タイマーのセット</summary>
    public void SetGuardWaitSetTimer(float set)
    {
        guardWaitSaveTimer = set;
    }  
    ///<summary>ガード状態ならタイマーを減らしていく</summary>
    private void TimerCountDown()
    {
        //ガードしていなければ何もしない
        if (!GetGuardOn())
            return;
        //タイマーが0より大きければカウントを減らす
        if (guardTimer >= 0)
            guardTimer--;
    }
    ///<summary>ガード待機状態ならタイマーを減らしていく</summary>
    private void WaitTimerCountDown()
    {
        //ガード待機状態でなければ何もしない
        if (!GetGuardWiatOn())
            return;
        //タイマーが0より大きければカウントを減らす
        if (guardWaitTimer >= 0)
            guardWaitTimer--;

       
    }
    #endregion

    ///<summary>s_PlayerControlのUpdateで呼び出し</summary>
    public void GuardUpdate(Transform tran)
    {
        if (tran.name != "o_player")
            return;

        TimerCountDown();
        GuardBreakTimer();
        WaitTimerCountDown();
        GuardWaiteBreakTimer();
        GameObject.Find("GuardText").GetComponent<s_PlayerHpUI>().SetText("1::" + guardOn + ",2::" + guardWaitOn);
    }
    ///<summary>ガード状態の取得</summary>
    public bool GetGuardOn()
    {
        return guardOn;
    }
    ///<summary>ガード状態の変更</summary>
    public void SetGuerdOn(bool set)
    {
        guardOn = set;
    }
    ///<summary>ガード待機状態の取得</summary>
    public bool GetGuardWiatOn()
    {
        return guardWaitOn;
    }
    ///<summary>ガード待機状態の変更</summary>
    public void SetGuardWaitOn(bool set)
    {
        guardWaitOn = set;
    }
    ///<summary>時間が過ぎたらガード状態を解除</summary>
    private void GuardBreakTimer()
    {
        //ガード時間が過ぎたら
        if (guardTimer<=0)
        {
            //ガード状態を解除して待機状態に
            SetGuerdOn(false);
            SetGuardWaitOn(true);
            SetGuardTimer();
        }
    }
    ///<summary>時間が過ぎたらガード待機状態を解除</summary>
    private void GuardWaiteBreakTimer()
    {
        //待機時間が過ぎたら
        if(guardWaitTimer<=0)
        {
            Debug.Log("on");
            SetGuardWaitTimer();
            SetGuardTimer();
            SetGuerdOn(false);
            SetGuardWaitOn(false);
            
        }
    }
    ///<summary>ガード出来ているか(魔法攻撃ならtrue)</summary>
    public bool GuardCheck(Vector3 vec,bool magic)
    {
        //ガードしていなければ
        if (!guardOn)
            return false;
        //相手の攻撃が魔法ならガード不可
        if (magic)
            return false;
        Vector3 targetDir = vec - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        
        if (angle <= guardAngleRange)
            return true;

        return false;
    }

}
