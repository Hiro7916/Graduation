using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>セーブポイントの記憶</summary>
public class s_PlayerSavePointMemory : MonoBehaviour
{
    // Start is called before the first frame update
    ///<summary>セーブポイントの名前のリスト</summary>
    List<string> savePointNames;
    ///<summary>セーブポイントの位置配列</summary>
    Dictionary<string, Vector3> savePointPosition;
    void Start()
    {
        //配列の生成
        savePointNames = new List<string>();
        savePointPosition = new Dictionary<string, Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>セーブポイントの登録</summary>
    public void AddSavePoint(string s)
    {
        //すでに登録されていれば何もしない
        if (savePointNames.Contains(s))
            return;
        //名前を登録
        savePointNames.Add(s);
        //名前からオブジェクトを探して位置を登録
        savePointPosition.Add(s, GameObject.Find(s).transform.position);
    }
    ///<summary>セーブポイントの名前リストを取得</summary>
    public List<string>GetListNames()
    {
        return savePointNames;
    }
    ///<summary>セーブポイントの位置を取得</summary>
    public Vector3 GetPosition(string s)
    {
        return savePointPosition[s];
    }
}
