using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>魔法の管理</summary>
public class s_ParticleControl : MonoBehaviour
{
    ///<summary>入力状態</summary>
    private string butttonState;
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
}
