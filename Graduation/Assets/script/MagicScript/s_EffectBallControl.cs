using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>魔法(エフェクトボールの管理)を発射管理</summary>
public class s_EffectBallControl : MonoBehaviour
{
    ///<summary>魔法の消える時間</summary>
    private int timer = 60 * 10;
    ///<summary>移動</summary>
    private Vector3 velocity;
    ///<summary>死亡フラグ</summary>
    private bool deadFlag;
    // Start is called before the first frame update
    void Start()
    {
        //カメラの正面に飛んでいくように
        if (GameObject.Find("Main Camera") != null)
            velocity = GameObject.Find("Main Camera").transform.forward;
        //カメラに追従しないよう親から外す
        transform.parent = null;
        //死亡フラグの初期化
        deadFlag = false;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(transform.position);
        Move();
        TimerUpdate();
        Dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        //エネミーに当たったらダメージ
        if (other.tag == "Enemy")
            other.GetComponent<s_EnemyState>().Damage(10, GetComponent<s_Property>().GetProperty());
        //プレイヤー以外に当たったら削除
        if (other.tag != "Player")
            deadFlag = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //プレイヤー以外に当たったら削除
        if (collision.gameObject.tag != "Player")
            deadFlag = true;
    }
    ///<summary>移動</summary>
    void Move()
    {
        //毎フレーム一定方向に移動
        Vector3 posi = transform.position;
        posi += velocity;
        transform.position = posi;
    }
    ///<summary>削除時間のカウント</summary>
    void TimerUpdate()
    {
        if (timer > 0)
            timer--;
    }
    ///<summary>削除</summary>
    void Dead()
    {
        //時間が来たら削除する
        if (timer <= 0||deadFlag)
            Destroy(this.gameObject);
    }

 
    
}
