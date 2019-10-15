using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>セーブデータを作る</summary>
public class s_DetaCreate : MonoBehaviour
{
    public Text text;
    ///<summary>セーブデータの番号</summary>
    private int number;
    ///<summary>セーブした日</summary>
    private string saveday;
    ///<summary>プレイした時間</summary>
    private string playTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>セーブデータ番号の登録</summary>
    public void SetNumber(int num)
    {
        number = num;
    }
    ///<summary>セーブした日時を取得</summary>
    public void SetSaveDay(string str)
    {
        saveday = str;  
    }
    ///<summary>プレイ時間の取得</summary>
    public void SetPlayTime(string str)
    {
        playTime = str;
    }
    //テキストを生成
    public void SetText()
    {
        text.text = "DataNumber:" + number +
            "\nSaveDay:" + saveday +
            "\nPlayTime:" + playTime;
    }
    ///<summary>新しいデータ</summary>
    public void SetNewGame()
    {
        text.text = "NewGame";
    }
    ///<summary>textの取得</summary>
    public Text GetText()
    {
        return text;
    }
}
