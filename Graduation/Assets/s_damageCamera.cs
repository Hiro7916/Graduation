using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_damageCamera : MonoBehaviour
{
Image im;
    // Start is called before the first frame update
    void Start()
    {
        im=GetComponent<Image>();
im.color=Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        this.im.color=
Color.Lerp(this.im.color,Color.clear,Time.deltaTime);
    }

    public void On()
    {
        this.im.color=new Color(0.5f,0,0,0.5f);

    }
}
