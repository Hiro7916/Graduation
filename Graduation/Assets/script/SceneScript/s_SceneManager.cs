using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>シーンの切り替え（基本的に外部から呼び出してシーンを切り替える）</summary>
public class s_SceneManager : MonoBehaviour
{
    ///<summary>ステージの名前</summary>
    public List<string> stageNames;
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

    ///<summary>次のシーンへ</summary>
   public void ScenNext()
   {
        for(int i=0;i<stageNames.Count;i++)
        {
             if(stageNames[i] == SceneManager.GetActiveScene().name)
             {
                  if(i+1<stageNames.Count)
                      SceneManager.LoadScene(stageNames[i+1]);
                   else 
                      SceneManager.LoadScene("ClearH");
             
             }
        }
   }
}
