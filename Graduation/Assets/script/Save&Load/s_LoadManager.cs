using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
///<summary>データロード</summary>
public class s_LoadManager : MonoBehaviour
{
    ///<summary>セーブデータのオブジェクト</summary>
    public GameObject savedData;
    ///<summary>セーブデータのリスト</summary>
    private List<GameObject> saveDataList;
    private List<string> fileName;
    ///<summary>選択しているデータ番号</summary>
    private int target;
    // Start is called before the first frame update
    void Start()
    {
        string s = SceneManager.GetActiveScene().name;
        //ロードシーン以外シーン開始時に読み込ませない
        if (s != "LoadSceneH")
            return;

        LoadSceneStart();

    }
    // Update is called once per frame
    void Update()
    {
        ListPos();

    }
    private void OnEnable()
    {
        //activeになったらリストを初期化
        saveDataList = new List<GameObject>();
        fileName = new List<string>();
    }
    ///<summary>ロードシーン開始時に読み込み</summary>
    private void LoadSceneStart()
    {
        //データリストの生成
        saveDataList = new List<GameObject>();
        fileName = new List<string>();
        //データを読み込む
        Create();
    }
    public void ListCreate()
    {
        //データリストの生成
        saveDataList = new List<GameObject>();
        fileName = new List<string>();
        //データを読み込み
        SaveWindCreate();
        NewGame();
    }

    ///<summary>全てのデータを作成</summary>
    private void Create()
    {
        //フォルダがあるか確認
        if (Directory.Exists(Application.dataPath + "/StreamingAssets/SaveData"))
        {
            //全てのファイルの名前を取得
            string[] subFolyder = Directory.GetDirectories(Application.dataPath + "/StreamingAssets/SaveData", "*", SearchOption.AllDirectories);

            //全てのデータを生成
            for (int i = 0; i < subFolyder.Length; i++)
            {
                int subNum = subFolyder[i].Length;
                DataCreate(Application.dataPath + "/StreamingAssets/SaveData/" + subFolyder[i][subNum - 1]);

            }
        }
        //ターゲットを初期化
        target = 0;
        saveDataList[target].GetComponent<Image>().color = new Color(255f / 255f, 245f / 255f, 182f / 255f, 143f / 255);

    }

    ///<summary>選択したファイルの名前を取得</summary>
    public string GetFileName()
    {
        return fileName[target];
    }
    ///<summary>ファイルを読み込みデータを生成</summary>
    private void DataCreate(string str)
    {
        //引数の名前のセーブデータのtxtを取得
        string[] s = File.ReadAllLines(str + "/playData.txt");
        //セーブデータのオブジェクトを生成
        GameObject obj = Instantiate(savedData);
        //リストに追加
        saveDataList.Add(obj);
        fileName.Add(str);

        //上からデータ番号を設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetNumber(saveDataList.IndexOf(obj) + 1);
        //一行目を取得
        string[] data = s[0].Split('^');
        //セーブした日時を設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetSaveDay(data[1]);
        //二行目を取得
        data = s[1].Split('^');
        //プレイ時間などを設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetPlayTime(data[1]);
        //取得したデータをテキストに描画
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetText();


        //セーブデータに親オブジェクトを設定(親オブジェクトの外に出た場合、非表示にするため)
        obj.transform.SetParent(GameObject.Find("Panel").transform);
        //初期の表示位置を設定
        obj.GetComponent<RectTransform>().position = new Vector3(550, 600 - (saveDataList.IndexOf(obj) * 220), 0);
        obj.GetComponent<RectTransform>().localScale = new Vector3(1f, 0.25f, 0);
    }


    ///<summary>セーブデータの選択</summary>
    private void ListPos()
    {
        //下キーが押された場合
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //リストの範囲外に出る場合は何もしない
            if (target + 1 >= saveDataList.Count)
            {
                return;
            }
            //ターゲットを次のデータへ
            target++;
            //ターゲットになったオブジェクトを一番上に表示
            saveDataList[target].transform.position = new Vector3(550, 600, 0);
            saveDataList[target].GetComponent<Image>().color = new Color(255f / 255f, 245f / 255f, 182f / 255f, 143f / 255);
            //他のオブジェクトの位置をターゲットの位置を基準に再設定
            for (int i = 0; i < saveDataList.Count; i++)
            {
                if (saveDataList[target] != saveDataList[i])
                {
                    int y = i - target;
                    saveDataList[i].transform.position = new Vector3(550, 600 - (y * 220), 0);
                    saveDataList[i].GetComponent<Image>().color = new Color(182f / 255f, 255f / 255f, 223f / 255f, 143f / 255f);
                }
            }
        }

        //上キーが押された場合
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //リストの範囲外に出る場合は何もしない
            if (target <= 0)
            {
                return;
            }
            //ターゲットを前のデータへ
            target--;
            //ターゲットになったオブジェクトを一番上に表示
            saveDataList[target].transform.position = new Vector3(550, 600, 0);
            saveDataList[target].GetComponent<Image>().color = new Color(255f / 255f, 245f / 255f, 182f / 255f, 143f / 255);

            //他のオブジェクトの位置をターゲットの位置を基準に再設定
            for (int i = 0; i < saveDataList.Count; i++)
            {
                if (saveDataList[target] != saveDataList[i])
                {
                    int y = i - target;
                    saveDataList[i].transform.position = new Vector3(550, 600 - (y * 220), 0);
                    saveDataList[i].GetComponent<Image>().color = new Color(182f / 255f, 255f / 255f, 223f / 255f, 143f / 255f);

                }
            }
        }
    }
    private void SaveWindCreate()
    {
        //フォルダがあるか確認
        if (Directory.Exists(Application.dataPath + "/StreamingAssets/SaveData"))
        {
            //全てのファイルの名前を取得
            string[] subFolyder = Directory.GetDirectories(Application.dataPath + "/StreamingAssets/SaveData", "*", SearchOption.AllDirectories);

            //全てのデータを生成
            for (int i = 0; i < subFolyder.Length; i++)
            {
                int subNum = subFolyder[i].Length;
                SaveWindDataCreate(Application.dataPath + "/StreamingAssets/SaveData/" + subFolyder[i][subNum - 1]);

            }
        }
        //ターゲットを初期化
        target = 0;
        saveDataList[target].GetComponent<Image>().color = new Color(255f / 255f, 245f / 255f, 182f / 255f, 143f / 255);

    }
    ///<summary>ファイルを読み込みデータを生成</summary>
    private void SaveWindDataCreate(string str)
    {
        //引数の名前のセーブデータのtxtを取得
        string[] s = File.ReadAllLines(str + "/playData.txt");
        //セーブデータのオブジェクトを生成
        GameObject obj = Instantiate(savedData);
        //リストに追加
        saveDataList.Add(obj);
        fileName.Add(str);

        //上からデータ番号を設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetNumber(saveDataList.IndexOf(obj) + 1);
        //一行目を取得
        string[] data = s[0].Split('^');
        //セーブした日時を設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetSaveDay(data[1]);
        //二行目を取得
        data = s[1].Split('^');
        //プレイ時間などを設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetPlayTime(data[1]);
        //取得したデータをテキストに描画
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetText();


        //セーブデータに親オブジェクトを設定(親オブジェクトの外に出た場合、非表示にするため)
        obj.transform.SetParent(GameObject.Find("Panel").transform);
        //初期の表示位置を設定
        obj.GetComponent<RectTransform>().position = new Vector3(550, 600 - (saveDataList.IndexOf(obj) * 220), -1);
        obj.GetComponent<RectTransform>().localScale = new Vector3(4f, 1f, 0);
    }
    ///<summary>空データ作成</summary>
    private void NewGame()
    {
        GameObject obj = Instantiate(savedData);
        saveDataList.Add(obj);
        fileName.Add("NewGame");

        //上からデータ番号を設定
        obj.transform.Find("DataText").GetComponent<s_DetaCreate>().SetNewGame();
        //セーブデータに親オブジェクトを設定(親オブジェクトの外に出た場合、非表示にするため)
        obj.transform.SetParent(GameObject.Find("Panel").transform);
        //初期の表示位置を設定
        obj.GetComponent<RectTransform>().position = new Vector3(550, 600 - (saveDataList.IndexOf(obj) * 220), 0);
        obj.GetComponent<RectTransform>().localScale = new Vector3(1f, 0.25f, 0);

    }
}
