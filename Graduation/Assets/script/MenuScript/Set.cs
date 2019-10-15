using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Set : MonoBehaviour
{
    [SerializeField]
    GameObject[] Obj;

    int Save;
    private int magicnumber;
    int magicSave;

    [SerializeField]
    Select select;

    //ボタン画像変更
    [SerializeField]
    Sprite fire_sprite;
    [SerializeField]
    Sprite water_sprite;
    [SerializeField]
    Sprite sunder_sprite;
    [SerializeField]
    Sprite wind_sprite;

    private void Awake()
    {
        magicnumber = 0;
    }

    private void Update()
    {
        //magic = select.GetComponent<Select>().GETSELECT();
        //magicHOZON = magic;

        MAGICNUM();
    }

    //保存用
    public void OnClick(int num)
    {
        magicnumber = select.GetComponent<Select>().GETSELECT();
        magicSave = magicnumber;

        Save = num;
    }

    public void IDOU()
    {
        //移動したら消す
        magicnumber = 0;
    }

    void MAGICNUM()
    {
        switch (magicSave)
        {
            case 0://初期値:選択無し
                Obj[Save].GetComponent<Image>().color = Color.white;
                break;
            case 1:
                // Obj[HOZON].GetComponent<Image>().color = Color.red;
                Obj[Save].GetComponent<Image>().sprite = fire_sprite;//Fire画像
                break;
            case 2:
                //Obj[HOZON].GetComponent<Image>().color = Color.blue;
                Obj[Save].GetComponent<Image>().sprite = water_sprite;//water画像
                break;
            case 3:
                // Obj[HOZON].GetComponent<Image>().color = Color.green;
                Obj[Save].GetComponent<Image>().sprite = sunder_sprite;//sunder画像
                Debug.Log("3です");
                break;
            case 4:
                Obj[Save].GetComponent<Image>().sprite = wind_sprite;//wind画像
                Debug.Log("4です");
                break;
        }
    }

    public void Move()//動かしたら
    {
        Debug.Log("magicnumberを初期化");
        magicnumber = 0;
    }

    void CHANGE()
    {
        magicSave = magicnumber;
        magicnumber = 0;
    }

    public int RETUEN()
    {
        return magicSave;
    }

    public int HoZoN()
    {
        return Save;
    }

}

