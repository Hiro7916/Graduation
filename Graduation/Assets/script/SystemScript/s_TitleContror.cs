using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>タイトル画面の管理</summary>
public class s_TitleContror : MonoBehaviour
{
    ///<summary>newGameテキスト</summary>
    public GameObject newGameT;
    ///<summary>Loadテキスト</summary>
    public GameObject LoadT;
    ///<summary>選択表示画像</summary>
    public GameObject selectImage;
    ///<summary>選択番号</summary>
    private int selectNum;
    ///<summary>テキストオブジェ格納用リスト</summary>
    private List<GameObject> objs;
    // Start is called before the first frame update
    void Start()
    {
        objs = new List<GameObject>();
        selectNum = 0;
        objs.Add(newGameT);
        objs.Add(LoadT);
        ImageChange();
    }

    // Update is called once per frame
    void Update()
    {
        SelectChange();
        SceneChange();
    }

    ///<summary>選択番号を変える</summary>
    private void SelectChange()
    {
        //上キーを押した場合
        if (Input.GetKeyDown(KeyCode.UpArrow)||s_Input.getdownArroUp(1))
        {
            if (selectNum - 1 >= 0)
            {
                selectNum--;
                ImageChange();
            }
        }
        //下キーを押した場合
        if (Input.GetKeyDown(KeyCode.DownArrow)||s_Input.getdownArroUp(-1))
        {
            if (selectNum + 1 <= objs.Count-1)
            {
                selectNum++;
                ImageChange();
            }
        }
    }
    ///<summary>テキスト、画像の表示の変更</summary>
    private void ImageChange()
    {
        Vector3 posi = selectImage.GetComponent<RectTransform>().position;
        posi.y=   objs[selectNum].GetComponent<RectTransform>().position.y;
        selectImage.GetComponent<RectTransform>().position = posi;

        for (int i = 0; i < objs.Count; i++)
        {
            if (i == selectNum)
            {
                objs[i].GetComponent<Text>().fontSize = 50;
            }
            else
            {
                objs[i].GetComponent<Text>().fontSize = 40;

            }
        }
    }
    ///<summary>シーンを変更</summary>
    private void SceneChange()
    {
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetButton("A"))
        {
            switch (selectNum)
            {
                case 0:
                    GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("Htuto");
                    break;
                case 1:
                    GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("LoadSceneH");
                    break;
            }
        }
    }
}
