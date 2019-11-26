using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
///<summary>プレイヤーが所持している魔法</summary>
public class s_PlayerHaveMagic : MonoBehaviour
{
    ///<summary>プレイヤーが覚えている魔法</summary>
    public Dictionary<string, GameObject> magices;
    ///<summary>魔法の名前</summary>
    private List<string> names;

    private void Awake()
    {
        SetDataMagic();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    ///<summary>SaveDataから魔法を読み込み</summary>
    private void SetDataMagic()
    {
        magices = new Dictionary<string, GameObject>();
        names = new List<string>();
        if (Directory.Exists(s_GameData.GetLoodFileName()))
        {
            string[] deta = File.ReadAllLines(s_GameData.GetLoodFileName()  + "/playerMagicData.txt");
            for (int i = 0; i < deta.Length; i++)
            {
                string[] strs = deta[i].Split('^');
                GameObject obj = (GameObject)Resources.Load("o_" + strs[0]);
                obj.GetComponent<s_MagicObjectControl>().SetLv(int.Parse(strs[1]));
                obj.GetComponent<s_MagicObjectControl>().SetExp(int.Parse(strs[2]));
                magices.Add(strs[0], obj);
                names.Add(strs[0]);
            }

        }
        else
        {
            GameObject obj = (GameObject)Resources.Load("o_Thunder");
            obj.GetComponent<s_MagicObjectControl>().SetLv(1);
            obj.GetComponent<s_MagicObjectControl>().SetExp(0);
            magices.Add("o_Thunder",obj);
            names.Add("o_Thunder");

            obj = (GameObject)Resources.Load("o_EffectBall");
            obj.GetComponent<s_MagicObjectControl>().SetLv(1);
            obj.GetComponent<s_MagicObjectControl>().SetExp(0);
            magices.Add("o_EffectBall",obj);
            names.Add("o_EffectBall");

            obj = (GameObject)Resources.Load("o_Bubble");
            obj.GetComponent<s_MagicObjectControl>().SetLv(1);
            obj.GetComponent<s_MagicObjectControl>().SetExp(0);
            magices.Add("o_Bubble",obj);
            names.Add("o_Bubble");
        }
    }
    ///<summary>リストから指定の魔法を取得</summary>
    public GameObject GetMagic(string name)
    {
        return magices[name];
    }
    ///<summary>現在所持している魔法の名前をすべて取得</summary>
    public List<string>GetMagicNames()
    {
        return names;
    }
    ///<summary>所持している魔法の数を取得</summary>
    public int GetHaveMagicCount()
    {
        return magices.Count;
    }

}
