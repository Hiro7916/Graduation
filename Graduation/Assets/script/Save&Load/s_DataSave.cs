﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
///<summary>セーブ画面でのセーブ</summary>
public class s_DataSave : MonoBehaviour
{
    ///<summary>選択ウィンド</summary>
    public GameObject selectWind;
    ///<summary>セーブウィンド</summary>
    public GameObject myWind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DataSave();
    }
    ///<summary>セーブウィンドでの操作</summary>
    private void DataSave()
    {
        //Enterキーが押された場合データをセーブ
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //既存のデータがある場合上書き
            if (GetComponent<s_LoadManager>().GetFileName() != "NewGame")
            {
                Debug.Log(GetComponent<s_LoadManager>().GetFileName());
                Save();
            }
            else
            {
                CreateNewGame();
                Debug.Log(GetComponent<s_LoadManager>().GetFileName());
                Save();
            }
        }
        //BackSpaceが押された場合セーブウィンドを閉じる
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            selectWind.SetActive(true);
            myWind.SetActive(false);
            foreach (Transform transform in selectWind.transform.Find("o_ScrollView").transform)
            {
                var go = transform.gameObject;
                Destroy(go);
            }
            selectWind.gameObject.transform.Find("t_SelectText").gameObject.SetActive(true);         
        }


    }
    private void Save()
    {
        GameObject player = GameObject.Find("o_player");

        string[] playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playerData.txt", Encoding.GetEncoding("Shift_JIS"));
        Debug.Log("on");
        playdeta[0] = "position^" + player.transform.position.x + "^" + player.transform.position.y+10 + "^" + player.transform.position.z;
        File.WriteAllLines(s_GameData.GetLoodFileName() + "/playerData.txt", playdeta);
        playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playData.txt", Encoding.GetEncoding("Shift_JIS"));
        playdeta[0] = "saveday^" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Hour + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second;
        playdeta[1] = "playTime^"+player.GetComponent<s_PlayerStatus>().GetPlayHour()+':' + player.GetComponent<s_PlayerStatus>().GetPlayMinute() + ':' + player.GetComponent<s_PlayerStatus>().GetPlaySecond();
        File.WriteAllLines(s_GameData.GetLoodFileName() + "/playData.txt", playdeta);

    }
    ///<summary>NewGame時にデータフォルダを生成</summary>
    private void CreateNewGame()
    {
        int directoryNum = 1;

        //フォルダがあるか確認
        if (Directory.Exists("Assets/SaveData"))
        {

            //全てのファイルの名前を取得
            string[] subFolyder = Directory.GetDirectories("Assets/SaveData", "*", SearchOption.AllDirectories);

            for (int i = 0; i < 100; i++)
            {
                if (!(0 <= Array.IndexOf(subFolyder, "Assets/SaveData\\" + directoryNum)))
                {
                    Directory.CreateDirectory("Assets/SaveData/" + directoryNum.ToString());
                    s_GameData.SetFileName("Assets/SaveData\\" + directoryNum.ToString());
                    CreatePlayData(directoryNum);
                    CreatePlayerData(directoryNum);

                    //選択したデータを記憶する
                    s_GameData.SetFileName("Assets/SaveData\\" + directoryNum);

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