using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>セレクト画面で表示・選択</summary>
public class s_SelectWind : MonoBehaviour
{
    ///<summary>表示するテキスト</summary>
    public Text selectT;
    ///<summary>選択している番号</summary>
    private int selectNumber;
    ///<summary>セレクト画面</summary>
    public GameObject wind;
    ///<summary>セーブウィンド</summary>
    public GameObject saveWind;
    ///<summary>ロードウィンド</summary>
    public GameObject loadWind;
    ///<summary>ワープ選択画面</summary>
    public GameObject warpWind;
    ///<summary>自分のオブジェクト</summary>
    public GameObject myObj;
    // Start is called before the first frame update
    void Start()
    {
        selectNumber= 0;
        ChangeText(selectNumber);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSelect();
        Select();
    }
    ///<summary>選択決定</summary>
    private void Select()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            switch (selectNumber)
            {
                case 0:
                    saveWind.SetActive(true);
                    saveWind.transform.Find("t_SaveText").GetComponent<s_LoadManager>().ListCreate("Save");
                    gameObject.SetActive(false);
                    break;
                case 1:
                    loadWind.SetActive(true);
                    loadWind.transform.Find("o_Loader").GetComponent<s_LoadManager>().ListCreate("Main");
                    gameObject.SetActive(false);
                    break;
                case 2:
                    warpWind.SetActive(true);
                    warpWind.transform.Find("t_WarpText").GetComponent<s_WarpWind>().SetList();
                    gameObject.SetActive(false);
                    break;
                case 3:
                    wind.SetActive(false);
                    s_PoseControl.ChangeWindPose(false);
                    break;
            }
        }
    }
    ///<summary>キーで選択移動</summary>
    private void ChangeSelect()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectNumber+1 >3)
                return;
            Debug.Log(selectNumber);
            selectNumber++;
            ChangeText(selectNumber);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (selectNumber-1<0)
                return;
            Debug.Log(selectNumber);
            selectNumber--;
            ChangeText(selectNumber);
        }
    }
    ///<summary>テキストの変更</summary>
    private void ChangeText(int num)
    {
        switch (num)
        {
            case 0:
                selectT.text= "Save←\nLoad\nWarp\nExit";
                break;
            case 1:
                selectT.text = "Save\nLoad←\nWarp\nExit";
                break;
            case 2:
                selectT.text = "Save\nLoad\nWarp←\nExit";
                break;
            case 3:
                selectT.text = "Save\nLoad\nWarp\nExit←";
                break;
        }
    }

}
