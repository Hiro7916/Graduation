using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>ワープ選択面管理</summary>
public class s_WarpWind : MonoBehaviour
{
    ///<summary>セレクトウィンド</summary>
    public GameObject selsectWind;
    ///<summary>自分のウィンド</summary>
    public Text warpWind;
    ///<summary>表示するワープポイントの名前</summary>
    private List<string> names;
    ///<summary>選択番号</summary>
    private int target;
    // Start is called before the first frame update
    void Start()
    {
        names = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }
    ///<summary>データを入手してテキストをセット</summary>
    public void SetList()
    {
        names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
        target = 0;
        string s = "";
        for(int i=0;i<names.Count;i++)
        {
            Debug.Log(names[i]);
            s += names[i] + "\n";
        }
        string[] str = s.Split('\n');
        str[target]+="←";
        for(int i=0;i<str.Length;i++)
        {
            warpWind.text += str[i]+'\n';
        }
     
    }
    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
            if (target +1< names.Count)
            {
                string s = "";
          
                warpWind.text = "";


                Debug.Log("aa");
                for (int i = 0; i < names.Count; i++)
                {
                    s += names[i] + "\n";
                }
                target++;
                string[] str = s.Split('\n');
                str[target] += "←";
                for (int i = 0; i < str.Length; i++)
                {
                    warpWind.text += str[i] + '\n';
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
            if (target - 1 >= 0)
            {
                string s = "";
            
                warpWind.text = "";

                for (int i = 0; i < names.Count; i++)
                {
                    s += names[i] + "\n";
                }
                target--;
                string[] str = s.Split('\n');
                str[target] += "←";
                for (int i = 0; i < str.Length; i++)
                {
                    warpWind.text += str[i] + '\n';
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
            GameObject player = GameObject.Find("o_player");
            Vector3 posi = player.GetComponent<s_PlayerSavePointMemory>().GetPosition(names[target]);
            posi.y += 5;
            player.transform.position = posi;
           
            selsectWind.SetActive(false);
            transform.parent.gameObject.SetActive(false);
            s_PoseControl.ChangeWindPose(false);
            warpWind.text = "";
        }
        
    }

}
