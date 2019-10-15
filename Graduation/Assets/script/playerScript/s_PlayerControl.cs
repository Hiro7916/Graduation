using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//end
///<summary>プレイヤーのコントロール(移動やガードなどキー入力を管理)</summary>
public class s_PlayerControl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ中なら何もしない
        if (s_PoseControl.GetLoadPose())
            return;
        //移動
        GetComponent<s_PlayerMove>().Move(transform);
        GetComponent<s_PlayerMove>().Rotation(transform);
        //カメラ
        GetComponent<s_PlayerCameraControl>().CameraTarget(transform);
        CameraTargetChange();
        //ガード
        GetComponent<s_PlayerGuard>().GuardUpdate(transform);
        Guard();

        //魔法
        GetComponent<s_MagicAction>().MagicUpdate(transform);

        //死亡しているか
        GetComponent<s_PlayerStatus>().DeadChack(transform);
    }
    ///<summary>ガードする</summary>
    private void Guard()
    {
        //Xボタンが押された時
        if (Input.GetButton("X")||Input.GetKeyDown(KeyCode.M))
        {
            //待機状態なら何もしない
            if (GetComponent<s_PlayerGuard>().GetGuardWiatOn())
                return;
            //ガード状態にする
            GetComponent<s_PlayerGuard>().SetGuerdOn(true);
        }
        //Xボタンが離された時
        if(Input.GetButtonUp("X")||Input.GetKeyUp(KeyCode.M))
        {  
            //ガード待機状態でなければ
            if(!GetComponent<s_PlayerGuard>().GetGuardWiatOn())
            {
                //ガード状態を解除
                GetComponent<s_PlayerGuard>().SetGuerdOn(false);
                //ガードタイマーを初期化
                GetComponent<s_PlayerGuard>().SetGuardTimer();
            }  
        }
    }
    ///<summary>カメラーターゲットの切り替え</summary>
    private void CameraTargetChange()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<s_PlayerCameraControl>().TargetChange(transform);
        }
    }
   
}
