using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>雷の魔法</summary>
public class s_ThunderControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }
    ///<summary>オブジェクトを消す</summary>
   void Dead()
    {
        //入力状態が"Up"もしくは"Next"の場合オブジェクトを削除
        if (GetComponent<s_ParticleControl>().GetState() == "Up"|| GetComponent<s_ParticleControl>().GetState() == "Next")
            Destroy(this.gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
        //敵に当たった場合ダメージを与える
        if (other.tag == "Enemy")
            other.GetComponent<s_EnemyState>().Damage(10,GetComponent<s_Property>().GetProperty());

    }
}
