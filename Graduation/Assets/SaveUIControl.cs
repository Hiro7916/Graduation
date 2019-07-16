using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveUIControl : MonoBehaviour
{
    public Text text;
    bool checkBool;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("player") != null)
            player = GameObject.Find("player");

        checkBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        HitCheck();
      
    }
    void HitCheck()
    {
        if (checkBool != player.GetComponent<SaveControl>().GetHit())
            ChengeText();

        checkBool = player.GetComponent<SaveControl>().GetHit();
    }
    void ChengeText()
    {
     
        if (!checkBool)
            text.text = "0 ・Save / 9 ・ Load";
        else
            text.text = "";
    }
}
