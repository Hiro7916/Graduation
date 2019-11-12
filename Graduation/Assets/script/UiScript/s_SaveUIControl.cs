using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>セーブウィンド表示UI</summary>
public class s_SaveUIControl : MonoBehaviour
{
    ///<summary>表示用UI</summary>
    public Text text;
    ///<summary>プレイヤーの取得用</summary>
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを取得
        if (GameObject.Find("o_player") != null)
            player = GameObject.Find("o_player");
        
    }

    // Update is called once per frame
    void Update()
    {
        ChengeText(); 
    }
    ///<summary>Textの変更</summary>
    void ChengeText()
    {
     
        if (player.GetComponent<s_PlayerSaveControl>().GetHit())
            text.text = "0 /ウィンドを開く";
        else
            text.text = "";
    }
}
