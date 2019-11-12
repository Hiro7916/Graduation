using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>魔法（パーティクルボール）の管理</summary>
public class s_ParticleBall : MonoBehaviour
{
    // Start is called before the first frame update
    //サイズ
    private float size;
    void Start()
    {
        //サイズの初期化
        size = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        //サイズが指定のサイズになるまでサイズを増やす
        if (size < 3)
        {
            size+=0.02f;
            Vector3 sc = new Vector3(1, 1, 1);
            sc *= size;
            transform.localScale = sc;
        
        }
    }
}
