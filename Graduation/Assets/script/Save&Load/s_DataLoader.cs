using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;
///<summary>タイトルでゲームシーンへ切り替える</summary>
public class s_DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンを押したらシーンを切り替える
        if(Input.GetButtonDown("A")||Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.Find("o_SceneManager") != null)
            {
                //選択したデータを記憶する
                s_GameData.SetFileName(GetComponent<s_LoadManager>().GetFileName());

                //if(s_GameData.GetLoodFileName()=="NewGame")
                //{
                //    CreateNewGame();
                //}

                GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("Main");
                s_PoseControl.ChangeWindPose(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (transform.parent.parent != null)
            {
                transform.parent.parent.transform.Find("o_SelectCanvas").gameObject.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                foreach (Transform transform in transform.parent.parent.transform.Find("o_SelectCanvas").transform.Find("o_ScrollView").transform)
                {
                    var go = transform.gameObject;
                    Destroy(go);
                }
                transform.parent.parent.transform.Find("o_SelectCanvas").gameObject.transform.Find("t_SelectText").gameObject.SetActive(true);
            }
        }
    }

    ///<summary>NewGame時にデータフォルダを生成</summary>
    private void CreateNewGame()
    {
        int directoryNum = 1;

        //フォルダがあるか確認
        if (Directory.Exists("Assets/StreamingAssets/SaveData"))
        {
          
            //全てのファイルの名前を取得
            string[] subFolyder = Directory.GetDirectories("Assets/SaveData", "*", SearchOption.AllDirectories);

            for(int i=0;i<100;i++)
            { 
                if (!(0 <= Array.IndexOf(subFolyder, "Assets/SaveData\\" + directoryNum)))
                {
                    Directory.CreateDirectory("Assets/SaveData/" + directoryNum.ToString());
                    CreatePlayData(directoryNum);
                    CreatePlayerData(directoryNum);

                    //選択したデータを記憶する
                    s_GameData.SetFileName("Assets/SaveData\\"+ directoryNum);

                    return; 
                }
                directoryNum++;
            }

        }
    }

    ///<summary>playDataを生成</summary>
    private void CreatePlayData(int num)
    {
        StreamWriter sw = File.CreateText("Assets/SaveData/" + num + "/playData.txt");
        sw.WriteLine("saveday^" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Hour + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second);
        sw.WriteLine("playTime^00:00:00");
        sw.Close();     
    }
    ///<summary>playerDataを生成</summary>
    private void CreatePlayerData(int num)
    {
        StreamWriter sw = File.CreateText("Assets/SaveData/" + num + "/playerData.txt");
        sw.WriteLine("position^" + 0 + "^" + 5 + "^" + 0);
        sw.Close();
    }
}
