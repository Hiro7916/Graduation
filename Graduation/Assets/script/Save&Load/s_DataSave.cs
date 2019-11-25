using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;

///<summary>セーブ画面でのセーブ</summary>
public class s_DataSave : MonoBehaviour
{
    ///<summary>選択ウィンド</summary>
    public GameObject selectWind;
    ///<summary>セーブウィンド</summary>
    public GameObject myWind;

    public Text tx;
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
                s_GameData.SetFileName(GetComponent<s_LoadManager>().GetFileName());
                Save();
            }
            else
            {
                CreateNewGame();
                Debug.Log(GetComponent<s_LoadManager>().GetFileName());
                //Save();
                Debug.Log("save");
            }
        }
        //BackSpaceが押された場合セーブウィンドを閉じる
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            selectWind.SetActive(true);
            myWind.SetActive(false);
            foreach (Transform transform in GameObject.Find("Panel").transform)
            {
                var go = transform.gameObject;
                Destroy(go);
            }     
        }


    }
    private void Save()
    {
        GameObject player = GameObject.Find("o_player");
        //  tx.text = GetComponent<s_LoadManager>().GetFileName();
        Debug.Log(GetComponent<s_LoadManager>().GetFileName());
        string[] playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playerData.txt");
        
        playdeta[0] = "position^" + player.transform.position.x + "^" + player.transform.position.y+10 + "^" + player.transform.position.z;
        File.WriteAllLines(s_GameData.GetLoodFileName() + "/playerData.txt", playdeta);
        playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playData.txt");
        playdeta[0] = "saveday^" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Hour + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second;
        playdeta[1] = "playTime^"+player.GetComponent<s_PlayerStatus>().GetPlayHour()+':' + player.GetComponent<s_PlayerStatus>().GetPlayMinute() + ':' + player.GetComponent<s_PlayerStatus>().GetPlaySecond();
        File.WriteAllLines(s_GameData.GetLoodFileName() + "/playData.txt", playdeta);


        playdeta = new string[player.GetComponent<s_PlayerHaveMagic>().GetHaveMagicCount()];
        for (int i = 0; i < player.GetComponent<s_PlayerHaveMagic>().GetHaveMagicCount(); i++)
        {

            string str = player.GetComponent<s_PlayerHaveMagic>().GetMagic(player.GetComponent<s_PlayerHaveMagic>().GetMagicNames()[i]).name;
            str = str.Remove(0, 2);
            playdeta[i]=(str+"^"+player.GetComponent<s_PlayerHaveMagic>().GetMagic(player.GetComponent<s_PlayerHaveMagic>().GetMagicNames()[i]).GetComponent<s_MagicObjectControl>().GetLv().ToString()+"^"+
                        player.GetComponent<s_PlayerHaveMagic>().GetMagic(player.GetComponent<s_PlayerHaveMagic>().GetMagicNames()[i]).GetComponent<s_MagicObjectControl>().GetExp().ToString());
        }
        File.WriteAllLines(s_GameData.GetLoodFileName() + "/playerMagicData.txt", playdeta);
        //エネミーデータをセーブ
        EnemySave();

    }
    ///<summary>NewGame時にデータフォルダを生成</summary>
    private void CreateNewGame()
    {
        int directoryNum = 1;
        Debug.Log("pre");
        //フォルダがあるか確認
        if (Directory.Exists(Application.dataPath + "/StreamingAssets/SaveData"))
        {
            //全てのファイルの名前を取得
            string[] subFolyder = Directory.GetDirectories(Application.dataPath + "/StreamingAssets/SaveData", "*", SearchOption.AllDirectories);

            for (int g = 0; g < subFolyder.Length; g++)
            {
                Debug.Log(subFolyder[g]);
            }
            for (int i = 0; i < 100; i++)
            {
                if (!(0 <= Array.IndexOf(subFolyder, Application.dataPath + "/StreamingAssets/SaveData\\" + directoryNum)))
                {
                    Debug.Log(directoryNum);
                    Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/SaveData/" + directoryNum.ToString());
                    s_GameData.SetFileName(Application.dataPath + "/StreamingAssets/SaveData/" + directoryNum.ToString());
                    CreatePlayData(directoryNum);
                    CreatePlayerData(directoryNum);
                    CreateEnemy(directoryNum);
                    CreateMagicData(directoryNum);
                    //選択したデータを記憶する
                   // s_GameData.SetFileName(Application.dataPath + "/StreamingAssets/SaveData/" + directoryNum);

                    return;
                }
                directoryNum++;
            }

        }
    }

    private void CreateMagicData(int num)   
    {
        GameObject player = GameObject.Find("o_player");
        StreamWriter sw = File.CreateText(Application.dataPath + "/StreamingAssets/SaveData/" + num + "/playerMagicData.txt");
        for (int i = 0; i < player.GetComponent<s_PlayerHaveMagic>().GetHaveMagicCount(); i++)
        {

            string str = player.GetComponent<s_PlayerHaveMagic>().GetMagic(player.GetComponent<s_PlayerHaveMagic>().GetMagicNames()[i]).name;
            str = str.Remove(0, 2);
            sw.WriteLine(str+"^"+player.GetComponent<s_PlayerHaveMagic>().GetMagic(player.GetComponent<s_PlayerHaveMagic>().GetMagicNames()[i]).GetComponent<s_MagicObjectControl>().GetLv().ToString()+"^"+
                        player.GetComponent<s_PlayerHaveMagic>().GetMagic(player.GetComponent<s_PlayerHaveMagic>().GetMagicNames()[i]).GetComponent<s_MagicObjectControl>().GetExp().ToString());
        }
        sw.Close();
    }
    

        
    ///<summary>playDataを生成</summary>
    private void CreatePlayData(int num)
    {
        GameObject player = GameObject.Find("o_player");
        StreamWriter sw = File.CreateText(Application.dataPath + "/StreamingAssets/SaveData/" + num + "/playData.txt");
        sw.WriteLine("saveday^" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Hour + "/" + DateTime.Now.Minute + "/" + DateTime.Now.Second);
        sw.WriteLine("playTime^"+player.GetComponent<s_PlayerStatus>().GetPlayHour()+':' + player.GetComponent<s_PlayerStatus>().GetPlayMinute() + ':' + player.GetComponent<s_PlayerStatus>().GetPlaySecond());
        sw.Close();
    }
    ///<summary>playerDataを生成</summary>
    private void CreatePlayerData(int num)
    {       
        GameObject player = GameObject.Find("o_player");
        StreamWriter sw = File.CreateText(Application.dataPath + "/StreamingAssets/SaveData/" + num + "/playerData.txt");
        sw.WriteLine("position^" + player.transform.position.x + "^" + player.transform.position.y+10 + "^" + player.transform.position.z);
        sw.Close();
    }
    private void CreateEnemy(int num)
    {
        StreamWriter sw = File.CreateText(Application.dataPath + "/StreamingAssets/SaveData/" + num + "/EnemyList.txt");
        foreach (Transform tra in GameObject.Find("EnemyList").transform)
        {
           sw.WriteLine( tra.name + "^" + tra.position.x + "^" + tra.position.y + "^" + tra.position.z);
           num++;
        }
        sw.Close();
    }
    public void EnemySave()
    {
        string filiName = s_GameData.GetLoodFileName();
        int num = 0;
        File.Delete(filiName + "/EnemyList.txt");
        StreamWriter sw = File.CreateText(filiName+ "/EnemyList.txt");
        foreach (Transform tra in GameObject.Find("EnemyList").transform)
        {
           sw.WriteLine( tra.name + "^" + tra.position.x + "^" + tra.position.y + "^" + tra.position.z);
           num++;
        }
        sw.Close();

    }

}
