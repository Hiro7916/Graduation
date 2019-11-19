using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
//end
///<summary>ゲーム開始時にプレイヤーを生成</summary>
public class s_PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Spone();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>選択したデータからプレイヤーの位置を設定</summary>
    private void Spone()
    {
        if (Directory.Exists(s_GameData.GetLoodFileName()))
        {
            string[] playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playerData.txt");
            string[] data = playdeta[0].Split('^');
            Vector3 posi = new Vector3(float.Parse(data[1]), float.Parse(data[2]), float.Parse(data[3]));
            transform.position = posi;
            playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playData.txt");
            data = playdeta[1].Split('^');
            string[] time = data[1].Split(':');
            GetComponent<s_PlayerStatus>().PlayTimerSet(float.Parse(time[0]), float.Parse(time[1]), float.Parse(time[2]));

        }
        else
        {
            GetComponent<s_PlayerStatus>().PlayTimerSet(0, 0, 0);
        }

    }
}
