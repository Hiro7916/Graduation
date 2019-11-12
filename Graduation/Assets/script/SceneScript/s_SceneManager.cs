using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>シーンの切り替え（基本的に外部から呼び出してシーンを切り替える）</summary>
public class s_SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    ///<summary>シーンを変える</summary>
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
