using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>魔法表示UI</summary>
public class s_MagicUI_Control : MonoBehaviour
{
    ///<summary>表示用UI</summary>
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>Textの変更</summary>
    public void UI_Change(string tex)
    {
        text.text = tex;
    }
}
