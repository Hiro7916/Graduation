using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///><summary>エネミーの攻撃（遠距離）</summary>
public class s_EnemyAttack : MonoBehaviour
{
    ///<summary>プレイヤー保存用</summary>
    private GameObject player;
    ///<summary>攻撃時に飛ばすオブジェクト</summary>
    public GameObject attackObj;
    ///<summary>飛ばす時間</summary>
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 60 * 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (s_PoseControl.GetLoadPose())
            return;
        CountDown();
    }
    ///<summary>一定時間が来たら攻撃</summary>
    private void CountDown()
    {
        //カウントを減らす
        count--;
        //カウントが０以下になった場合
        if(count<=0)
        {
            //カウントを初期化
            count = 60 * 3;

            //攻撃オブジェクトを追加
            GameObject obj = Instantiate(attackObj);
            obj.transform.position = transform.position;
            //プレイヤーの方向へ飛ばす
            Vector3 playerPosi;
            if (!GameObject.Find("o_player"))
                return;
            player = GameObject.Find("o_player");
            playerPosi = player.transform.position;

            Vector3 dis = new Vector3(playerPosi.x - transform.position.x,
                playerPosi.y - transform.position.y,
                playerPosi.z - transform.position.z);

            dis.Normalize();

            obj.GetComponent<s_AttackEnemyControl>().SetVelocity(dis);


        }
    }
}
