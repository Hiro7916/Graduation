using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>セレクト画面全体の管理</summary>
public class s_SelectWindManager : MonoBehaviour
{
    ///<summary>セレクトウィンド</summary>
    public GameObject selectWind;
    ///<summary>セーブウィンド</summary>
    public GameObject saveWind;
    ///<summary>ロードウィンド</summary>
    public GameObject loadWind;
    ///<summary>ワープウィンド</summary>
    public GameObject warpWind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    ///<summary>ウィンドを開く</summary>
    public void Open()
    {
        selectWind.SetActive(true);
        saveWind.SetActive(false);
        loadWind.SetActive(false);
        warpWind.SetActive(false);
    }
    public void End()
    {
        selectWind.SetActive(false);
        saveWind.SetActive(false);
        loadWind.SetActive(false);
        warpWind.SetActive(false);
    }
}
