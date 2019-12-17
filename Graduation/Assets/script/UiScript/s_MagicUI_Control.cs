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
public List<Sprite>ll;
    private Dictionary<string, Sprite> texs;
    // Start is called before the first frame update
    private void Awake()
    {
        
        texs = new Dictionary<string, Sprite>();
        texs.Add("Thunder",ll[0]);
        texs.Add("Bubble", ll[2]);
        texs.Add("EffectBall",ll[1]);
    }

    private void Start()
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
if(ime!=null)
        ime.sprite = texs[tex];

    }


}
