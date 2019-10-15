using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>エネミーの攻撃オブジェクトのコントロール</summary>
public class s_AttackEnemyControl : MonoBehaviour
{
    ///<summary>移動</summary>
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    ///<summary>毎フレーム一定方向に移動</summary>
    private void Move()
    {
       transform.position += velocity;
    }
    ///<summary>飛ぶ方向をセット</summary>
    public void SetVelocity(Vector3 vel)
    {
        velocity = vel;
    }

    public void OnTriggerStay(Collider other)
    {
        //プレイヤーに当たったら削除してダメージを与える
        if (other.name == "o_player")
        {
           Destroy(gameObject);
           if (!other.gameObject.GetComponent<s_PlayerGuard>().GuardCheck(transform.position,true))
           {
                other.gameObject.GetComponent<s_PlayerStatus>().Damage(10);
           }
        }
        if(other.tag=="Magic")
        {
            if(GetComponent<s_Property>().GetProperty()==other.GetComponent<s_Property>().GetProperty())
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Magic")
        {
            Destroy(gameObject);
        }
    }
}
