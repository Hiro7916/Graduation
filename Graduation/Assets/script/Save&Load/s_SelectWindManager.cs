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
        selectWind.SetActive(true);
        saveWind.SetActive(false);
        loadWind.SetActive(false);
    }
    private void OnDisable()
    {
        selectWind.SetActive(true);
        selectWind.transform.Find("t_SelectText").gameObject.SetActive(true);
        saveWind.SetActive(false);
        loadWind.SetActive(false);
    }
}
