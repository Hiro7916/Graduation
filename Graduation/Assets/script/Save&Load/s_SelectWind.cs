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
    public GameObject saveText;
    ///<summary>ロードウィンド</summary>
    public GameObject loadWind;
    ///<summary>ワープ選択画面</summary>
    public GameObject warpWind;

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
        if(Input.GetKeyDown(KeyCode.Return)||Input.GetButtonDown("A"))
        {
            Debug.Log(selectNumber);
            switch (selectNumber)
            {
                case 0:
                    saveWind.SetActive(true);
                    saveText.GetComponent<s_LoadManager>().ListCreate();
                    wind.SetActive(false);
                    break;
                case 1:
                    wind.SetActive(false);
                    loadWind.SetActive(true);
                    GameObject.Find("t_LoadText").GetComponent<s_LoadManager>().ListCreate();
                    break;
                case 2:
                    wind.SetActive(false);
                    warpWind.SetActive(true);
                    GameObject.Find("t_WarpText").GetComponent<s_WarpWind>().SetList();
                    break;
                case 3:
                    GameObject.Find("o_SaveLoad_Wind").GetComponent<s_SelectWindManager>().End();
                    s_PoseControl.ChangeWindPose(false);
s_PoseControl.ChangeWindsavePose(false);
                    break;
            }
        }
    }
    ///<summary>キーで選択移動</summary>
    private void ChangeSelect()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)||s_Input.getdownArroUp(-1))
        {
            if (selectNumber+1 >3)
                return;
           // Debug.Log(selectNumber);
            selectNumber++;
            ChangeText(selectNumber);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)||s_Input.getdownArroUp(1))
        {
            if (selectNumber-1<0)
                return;
           // Debug.Log(selectNumber);
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
