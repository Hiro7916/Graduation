using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            s_GameData.SetFileName(GameObject.Find("Panel").GetComponent<s_LoadManager>().GetFileName());
            GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("Main");
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("TitleH");

        }
    }
}
