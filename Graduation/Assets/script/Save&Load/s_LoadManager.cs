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


    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        string s = SceneManager.GetActiveScene().name;
        if (s != "TitleH")
            return;
        //データリストの生成
        saveDataList = new List<GameObject>();
        fileName = new List<string>();
 
      

        int sceneNumber = 0;
        switch(s)
        {
            case "TitleH":
                sceneNumber = 0;
                break;      
        }
        Create(sceneNumber);
        //リストの最初に格納されているデータをターゲットに
        target = 0;     
    }
    public void ListCreate(string str)
    {
        //データリストの生成
        saveDataList = new List<GameObject>();
        fileName = new List<string>();
        int sceneNumber = 0;
        switch (str)
        {
            case "TitleH":
                sceneNumber = 0;
                break;
            case "Main":
                sceneNumber = 1;
                break;
            case "Save":
                sceneNumber = 0;
                break;
        }
        Create(sceneNumber);
        //リストの最初に格納されているデータをターゲットに
        target = 0;
    }

    ///<summary>全てのデータを作成</summary>
    private void Create(int num)
    {

        //フォルダがあるか確認
        if (Directory.Exists(Application.dataPath + "/StreamingAssets/SaveData"))
        {


            //全てのファイルの名前を取得
            //  string[] subFolyder = Directory.GetDirectories(Application.streamingAssetsPath + "/SaveData", "*", SearchOption.AllDirectories);
            string[] subFolyder = Directory.GetDirectories(Application.dataPath + "/StreamingAssets/SaveData", "*", SearchOption.AllDirectories);
     
            //全てのデータを生成
            for (int i = 0; i < subFolyder.Length; i++)
            {
                int subNum = subFolyder[i].Length;
                DataCreate(Application.dataPath + "/StreamingAssets/SaveData/" + subFolyder[i][subNum-1]);
            
            }
            //シーンがタイトルならNewGameを生成
            if (num == 0)
                NewGame();
        }
        target = 0;
    }
    // Update is called once per frame
    void Update()
    {
        ListPos();

    }
    private void OnEnable()
    {
        saveDataList = new List<GameObject>();
        fileName = new List<string>();
    }
    ///<summary>選択したファイルの名前を取得</summary>
    public string GetFileName()
    {
        return fileName[target];
    }
    public List<string>GetList()
    {
        return fileName;
    }
    ///<summary>ファイルを読み込みデータを生成</summary>
    private void DataCreate(string str)
    {
        // text.text += failPa; ;
        //引数の名前のセーブデータのtxtを取得
        string[] s = File.ReadAllLines(str+"/playData.txt");
        //string[] s = File.ReadAllLines(str + "/playData.txt", Encoding.GetEncoding("Shift_JIS"));
        //セーブデータのオブジェクトを生成
        GameObject obj = Instantiate(savedData);
       // text.text += s[0];
        //リストに追加
        saveDataList.Add(obj);
        Debug.Log("aaaaaaaa"+str);
        fileName.Add(str);

        //上からデータ番号を設定
        obj.GetComponent<s_DetaCreate>().SetNumber(saveDataList.IndexOf(obj)+1);
        //一行目を取得
        string[] data = s[0].Split('^');
        //セーブした日時を設定
        obj.GetComponent<s_DetaCreate>().SetSaveDay(data[1]);
        //二行目を取得
        data = s[1].Split('^');
        //プレイ時間などを設定
        obj.GetComponent<s_DetaCreate>().SetPlayTime(data[1]);
        //取得したデータをテキストに描画
        obj.GetComponent<s_DetaCreate>().SetText();


        //セーブデータに親オブジェクトを設定(親オブジェクトの外に出た場合、非表示にするため)
        obj.transform.SetParent(GameObject.Find("o_ScrollView").transform);
        //初期の表示位置を設定
        obj.GetComponent<RectTransform>().position = obj.transform.parent.position + new Vector3(-20, 80 - (saveDataList.IndexOf(obj) * 55), 0);
    }
    ///<summary>NewGameを生成</summary>
    public void NewGame()
    {
        //セーブデータの実体を生成
        GameObject obj = Instantiate(savedData);
        //リストに追加
        saveDataList.Add(obj);
        fileName.Add("NewGame");
        //テキストに"NewGame"と表示
        obj.GetComponent<s_DetaCreate>().SetSaveDay("New Game");
        obj.GetComponent<s_DetaCreate>().SetNewGame();
        //セーブデータに親オブジェクトを設定(親オブジェクトの外に出た場合、非表示にするため)
        obj.transform.SetParent(GameObject.Find("o_ScrollView").transform);
        //初期の表示位置を設定
        obj.transform.position = obj.transform.parent.position + new Vector3(-20, 80 - (saveDataList.IndexOf(obj) * 55),0);
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
            saveDataList[target].transform.position = saveDataList[target].transform.parent.position + new Vector3(-20, 80 - (0 * 55), 0);
            //他のオブジェクトの位置をターゲットの位置を基準に再設定
            for (int i=0;i<saveDataList.Count;i++)
            {
                if (saveDataList[target]!=saveDataList[i])
                {
                    int y =i- target ;
                    saveDataList[i].transform.position = saveDataList[target].transform.parent.position + new Vector3(-20, 80 - (y*55), 0);
                }
            }
        }

        //上キーが押された場合
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {           
            //リストの範囲外に出る場合は何もしない
            if (target  <= 0)
            {
                return;
            }
            //ターゲットを前のデータへ
            target--;
            //ターゲットになったオブジェクトを一番上に表示
            saveDataList[target].transform.position = saveDataList[target].transform.parent.position + new Vector3(-20, 80 - (0 * 55), 0);

            //他のオブジェクトの位置をターゲットの位置を基準に再設定
            for (int i = 0; i < saveDataList.Count; i++)
            {
                if (saveDataList[target] != saveDataList[i])
                {
                    int y = i - target;
                    saveDataList[i].transform.position = saveDataList[target].transform.parent.position + new Vector3(-20, 80 - (y * 55), 0);
                }
            }
        }
    }

}
