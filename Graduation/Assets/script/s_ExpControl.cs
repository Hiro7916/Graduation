using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>Expオブジェクト</summary>
public class s_ExpControl : MonoBehaviour
{
    ///<summary>経験値</summary>
    public int exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>経験値を取得</summary>
    public int GetExp()
    {
        return exp;
    }
    ///<summary>オブジェクトを消す</summary>
    public void Dead()
    {
        Destroy(this.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
 
        //プレイヤーと当たった場合
        if (other.tag == "Player")
        {
            other.GetComponent<s_MagicAction>().AddExp(10);
            Destroy(this.gameObject);
        }
    }



}
