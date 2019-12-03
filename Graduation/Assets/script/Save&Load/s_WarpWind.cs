using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>ワープ選択面管理</summary>
public class s_WarpWind : MonoBehaviour
{
    ///<summary>セレクトウィンド</summary>
    public GameObject selsectWind;
    ///<summary>自分のテキスト</summary>
    public Text myText;
    ///<summary>自分のウィンド</summary>
    public GameObject myWind;
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
        myText.text = "";
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
            myText.text += str[i]+'\n';
        }
     
    }
    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)||s_Input.getdownArroUp(-1))
        {
            names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
            if (target +1< names.Count)
            {
                string s = "";
          
                myText.text = "";

                for (int i = 0; i < names.Count; i++)
                {
                    s += names[i] + "\n";
                }
                target++;
                string[] str = s.Split('\n');
                str[target] += "←";
                for (int i = 0; i < str.Length; i++)
                {
                    myText.text += str[i] + '\n';
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)||s_Input.getdownArroUp(1))
        {
            names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
            if (target - 1 >= 0)
            {
                string s = "";
            
                myText.text = "";

                for (int i = 0; i < names.Count; i++)
                {
                    s += names[i] + "\n";
                }
                target--;
                string[] str = s.Split('\n');
                str[target] += "←";
                for (int i = 0; i < str.Length; i++)
                {
                    myText.text += str[i] + '\n';
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)||Input.GetButtonDown("A"))
        {
            names = GameObject.Find("o_player").GetComponent<s_PlayerSavePointMemory>().GetListNames();
            GameObject player = GameObject.Find("o_player");
            Vector3 posi = player.GetComponent<s_PlayerSavePointMemory>().GetPosition(names[target]);
            posi.y += 5;
            player.transform.position = posi;

            GameObject.Find("o_SaveLoad_Wind").GetComponent<s_SelectWindManager>().End();
            s_PoseControl.ChangeWindPose(false);
            myText.text = "";
        }
        //BackSpaceが押された場合セーブウィンドを閉じる
        if (Input.GetKeyDown(KeyCode.Backspace)||Input.GetButtonDown("B"))
        {
            selsectWind.SetActive(true);
            myWind.SetActive(false);
            foreach (Transform transform in GameObject.Find("Panel").transform)
            {
                var go = transform.gameObject;
                Destroy(go);
            }
        }
    }

}
