using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>ロードしたファイル</summary>
public class s_GameData : MonoBehaviour
{
    ///<summary>ロードしたファイルの名前</summary>
    private static string loodFilleName;
    // Start is called before the first frame update

    ///<summary>現在ロードしたファイル名を登録</summary>
    public static void SetFileName(string str)
    {
        loodFilleName = str;
    }
    ///<summary>現在ロードしているファイルの取得</summary>
    public static string GetLoodFileName()
    {
        return loodFilleName;
    }
}
