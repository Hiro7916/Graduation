using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>魔法表示UI</summary>
public class s_MagicUI_Control : MonoBehaviour
{
    ///<summary>表示用UI</summary>
    public Text text;

    public Image ime;

    private Dictionary<string, Color> texs;
    // Start is called before the first frame update
    private void Awake()
    {
        
        texs = new Dictionary<string, Color>();
        texs.Add("Thunder", Color.yellow);
        texs.Add("Bubble", Color.blue);
        texs.Add("EffectBall", Color.white);
    }

    // Update is called once per frame
    void Update()
    {

    }
    ///<summary>Textの変更</summary>
    public void UI_Change(string tex)
    {
        text.text = tex;
if(ime!=null)
        ime.color = texs[tex];

    }


}
