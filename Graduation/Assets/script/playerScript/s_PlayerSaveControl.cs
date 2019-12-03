using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
///<summary>プレイヤーからのセーブ設定</summary>
public class s_PlayerSaveControl : MonoBehaviour
{
    ///<summary>セーブポイントに当たっているかの判定</summary>
  　private bool hit;
    ///<summary>オブジェクトの一時保存</summary>
    private GameObject hitObj;
    public GameObject looder;

    bool loadOn;
    List<KeyCode> numberKey;
    // Start is called before the first frame update
    void Start()
    {
        //セーブポイントとヒット判定の初期化
        hit = false;



        loadOn = false;
        numberKey = new List<KeyCode>();
        for (int i = 0; i < 10; i++)
        {
            numberKey.Add((KeyCode)48 + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OpenWind();



        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    s_PoseControl.ChangeWindPose(false);
        //}

        //Save();
        //Load();
        //Warp();
    }
    private void OnTriggerEnter(Collider other)
    {
        //オブジェクトがセーブポイントならhit状態にしてオブジェクトも一時保存
        if (other.tag == "SavePoint")
        {
            hit = true;
            hitObj = other.gameObject;
            Debug.Log(other.name);
            WarpSave();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //オブジェクトがセーブポイントならhit状態,オブジェクトの一時保存を解除する
        if (other.tag == "SavePoint")
        {
            hit = false;
            hitObj = null;
GetComponent<s_PlayerStatus>().Recovery(GetComponent<s_PlayerStatus>().maxHp);



            loadOn = false;          
        }
    }
    ///<summary>ウィンドを開く</summary>
    private void OpenWind()
    {
        //セーブポイントにhitしていて0キーを押されている場合
        if (hit &&( Input.GetKeyDown(KeyCode.Alpha0)||Input.GetButtonDown("X")))
        {
            loadOn = true;
            GameObject.Find("o_SaveLoad_Wind").GetComponent<s_SelectWindManager>().Open();
            s_PoseControl.ChangeWindPose(true);

        }
    }

    ///<summary>ワープを使えるオブジェクトの名前を保存</summary>
    private void WarpSave()
    {
        GetComponent<s_PlayerSavePointMemory>().AddSavePoint(hitObj.name);
    }






    void Save()
    {

        if (hit && Input.GetKeyDown(KeyCode.Alpha7))
        {
            string[] playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playerData.txt", Encoding.GetEncoding("Shift_JIS"));
            playdeta[0] = "position^" + transform.position.x + "^" + transform.position.y + "^" + transform.position.z;
            File.WriteAllLines(s_GameData.GetLoodFileName() + "/playerData.txt",playdeta);
            playdeta = File.ReadAllLines(s_GameData.GetLoodFileName() + "/playData.txt", Encoding.GetEncoding("Shift_JIS"));
            playdeta[0] = "saveday^" + DateTime.Now.Year+"/"+ DateTime.Now.Month + "/" + DateTime.Now.Day + "/"+DateTime.Now.Hour + "/"+ DateTime.Now.Minute + "/"+DateTime.Now.Second;
            playdeta[1] = "playTime^01:02:03";
            File.WriteAllLines(s_GameData.GetLoodFileName() + "/playData.txt", playdeta);
            Debug.Log("save");
        }

        if (loadOn)
            return;
    }
    void Load()
    {


        if (hit && Input.GetKeyDown(KeyCode.Alpha9))
        {
            loadOn = true;
            looder.SetActive(true);

        }
    }
    public bool GetHit()
    {
        return hit;
    }

}
