using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    [SerializeField] GameObject map;//Map
    [SerializeField] GameObject menu_Prefab;//Mainmenu
    [SerializeField] GameObject setselect;//setselect画面


    void Start()
    {
        map.SetActive(false);
        setselect.SetActive(false);
    }

    void Update()
    {
        
    }

    public void MapPos()
    {
        map.SetActive(true);
        setselect.SetActive(false);
    }

    public void Menu_Magic()
    {
        map.SetActive(false);
        setselect.SetActive(true);
    }

    //ボタン「Exit」を押したときにメニュー画面非表示
    public void Exit()
    {
        //非表示に
        menu_Prefab.SetActive(false);
        map.SetActive(false);
        setselect.SetActive(false);

        Time.timeScale = 1f;
    }
}
