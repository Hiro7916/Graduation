using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveUI_Obj : MonoBehaviour
{
    //　画面UI
    [SerializeField] private GameObject statusWindow;

    //　ボタンのインタラクティブに関する処理が書かれているスクリプト
    [SerializeField] private ActiveButton select1;//select
    [SerializeField] private ActiveButton select2;//set
    [SerializeField] private GameObject firstSelect;//基本選択（コントローラー設定用）

    [SerializeField] GameObject map;
    [SerializeField] GameObject setselect;

    bool timeStop = false;//(時間止める用)


    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            timeStop = !timeStop;
            statusWindow.SetActive(timeStop);
            Time.timeScale = 0f;

            if (statusWindow.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(firstSelect);

                select1.ActivateOrNotActivate(false);
                select2.ActivateOrNotActivate(false);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(null);

                //mapやselect画面が選択されていたら表示を解除
                map.SetActive(false);
                setselect.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    //Exitを押したときの処理
    public void pushButton()
    {
        timeStop = false;
    }

    public void resetActive()
    {
        select1.ActivateOrNotActivate(true);
        select2.ActivateOrNotActivate(false);
    }
}
