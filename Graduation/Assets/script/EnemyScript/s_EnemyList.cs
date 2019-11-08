using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class s_EnemyList : MonoBehaviour
{
    ///<summary>オブジェリスト</summary>
    public List<GameObject> objs;
    ///<summary>オブジェの名前リスト</summary>
    public List<string> objNames;
    // Start is called before the first frame update
    void Start()
    {
        Spone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>選択したデータからエネミーの位置を設定</summary>
    private void Spone()
    {
        if (Directory.Exists(s_GameData.GetLoodFileName()))
        {
            string[] playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/EnemyList.txt");
            int num = 0;
            for (int i = 0; i < playdeta.Length; i++)
            {
                string[] data = playdeta[i].Split('^');
                for (int f = 0; f < objNames.Count; f++)
                {
                    if (data[0] == objNames[f])
                    {
                        GameObject obj = Instantiate(objs[f]);
                        obj.transform.position = new Vector3(float.Parse(data[1]), float.Parse(data[2])+3, float.Parse(data[3]));
                    }
                }
                num++;
            }
     
        }
        else
        {
            string[] playdeta = File.ReadAllLines("C:/ss/Graduation/Assets/StreamingAssets/SaveData/1" + "/EnemyList.txt");
            int num = 0;
            for (int i = 0; i < playdeta.Length; i++)
            {
                string[] data = playdeta[i].Split('^');
                for (int f = 0; f < objNames.Count; f++)
                {
                    if (data[0] == objNames[f])
                    {
                        GameObject obj = Instantiate(objs[f]);
                        obj.transform.position = new Vector3(float.Parse(data[1]), float.Parse(data[2]) + 3, float.Parse(data[3]));
                        obj.transform.parent=GameObject.Find("EnemyList").transform;
                        string name = obj.name.Replace("(Clone)", "") ;
                        obj.name = name;
                        
                    }
                }
                num++;
            }
        }

    }

}
