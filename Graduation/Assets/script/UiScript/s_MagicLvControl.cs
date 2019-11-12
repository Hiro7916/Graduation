using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>魔法のレベルUI</summary>
public class s_MagicLvControl : MonoBehaviour
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
    ///<summary>表示レベルを変更</summary>
    public void ChengeText(string s)
    {
        text.text = "Lv::" + s;
    }
}
