using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>プレイヤーの体力用UI</summary>
public class s_PlayerHpUI : MonoBehaviour
{
    ///<summary>体力表示用テキスト</summary>
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
    }
    ///<summary>体力表示用テキストのテキスト変更</summary>
    public void SetText(string str)
    {
        hpText.text = str;
    }
}
