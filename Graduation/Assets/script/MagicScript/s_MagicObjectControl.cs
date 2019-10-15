using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>魔法のレベル切り替えなどの管理</summary>
public class s_MagicObjectControl: MonoBehaviour
{
    ///<summary>魔法のリスト</summary>
    public List<GameObject> magicList;
    ///<summary>現在の魔法</summary>
    private GameObject nowMagic;
    ///<summary>現在のLv</summary>
    private int lv;
    ///<summary>現在の経験値</summary>
    private int exp;
    ///<summary>LvUpに必要な経験値を登録</summary>
    public List<int> nextExp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>現在の魔法を返す</summary>
    public GameObject GetNowMagicObject()
    {
        return magicList[lv-1];
    }
    ///<summary>Lvをセット</summary>
    public void SetLv(int num)
    {
        lv = num;
    }
    ///<summary>現在のLvを取得</summary>
    public int GetLv()
    {
        return lv;
    }
    ///<summary>経験値をセット</summary>
    public void SetExp(int num)
    {
        exp = num;
    }
    ///<summary>経験値を取得</summary>
    public void AddExp(int num)
    {
        exp += num;
        //指定した経験値を超えた場合Lvを変更する
        for(int i=0;i<nextExp.Count;i++)
        {
            if(exp>=nextExp[i])
            {
                lv = i + 2;
            }
        }
    }

}
