using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforMation : MonoBehaviour
{
    Text infotext;

    [SerializeField]
    string informationText;

    void Start()
    {
        infotext = GameObject.Find("Information").GetComponent<Text>();
    }

    void Update()
    {

    }

    public void Select()
    {
        if (infotext != null)
            infotext.text = informationText;
    }
}
