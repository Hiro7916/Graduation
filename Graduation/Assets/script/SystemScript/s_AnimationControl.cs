using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>アニメーション</summary>
public class s_AnimationControl : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    anim.Play("RUN00_F");
        //}
        //if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    anim.Play("WAIT00");
        //}
        //if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    anim.Play("HANDUP00_R");
           
        //}
    }

    public void ChangeAnime(string name)
    {
        anim.Play(name);
    }
}
