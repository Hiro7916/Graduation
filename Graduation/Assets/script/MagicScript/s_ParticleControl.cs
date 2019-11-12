using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>魔法の管理</summary>
public class s_ParticleControl : MonoBehaviour
{
    ///<summary>入力状態</summary>
    private string butttonState;
    ///<summary>現在のレベル</summary>
    private int lv;
    // Start is called before the first frame update
    void Start()
    {
        butttonState = "Down";     
    }

    // Update is called once per frame
    void Update()
    {


    }

    ///<summary>状態を変更</summary>
    public void SetState(string state)
    {
        butttonState = state;
    }
    ///<summary>状態を返す</summary>
    public string GetState()
    {
        return butttonState;
    }
    ///<summary>lvのセット</summary>
    public void SetLv(int num)
    {
        lv = num;
    }
    ///<summary>lvの取得</summary>
    public int GetLv()
    {
        return lv;
    }

}
