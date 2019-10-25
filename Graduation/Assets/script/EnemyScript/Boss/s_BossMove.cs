using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>ボスの挙動</summary>
public class s_BossMove : MonoBehaviour
{
    ///<summary>行動をするかどうか</summary>
    private bool actionOn;
    ///<summary>プレイヤーを取得する</summary>
    private GameObject player;
    ///<summary>攻撃状態か</summary>
    private bool attackOn;
    ///<summary>攻撃するか考える時間</summary>
    private int attackThinkTimer;
    ///<summary>攻撃の番号</summary>
    private int attackNumber;

    public GameObject attackObj;
    private void Start()
    {
        attackNumber = 0;
        actionOn = false;
        attackOn = false;
        attackThinkTimer = Random.Range(60*3,60*6);
        if (GameObject.Find("player") != null)
            player = GameObject.Find("player");
    }

    private void Update()
    {
        if (s_PoseControl.GetLoadPose())
            return;

        if (player == null)
            return;

        if (!actionOn)
        {
            if (DistanceCheck(player.transform.position) < 40)
                actionOn = true;            
        }

        if (!actionOn)
            return;
        Move_isPlayer();
        if (!attackOn)
        {
            Fly();
            attackThinkTimer--;
            if (attackThinkTimer <= 0)
            {
                AttackThink();

            }
        }
        else
        {
            switch (attackNumber)
            {
                case 0:Rush();
                    break;
                case 1:MagicAttack();
                    break;
            }
                
        }

    }
    ///<summary>距離を計算</summary>
    private float DistanceCheck(Vector3 vec)
    {
        if (player == null)
            return 0;

        Vector2 my = new Vector2(transform.position.x, transform.position.z);
        Vector2 other = new Vector2(vec.x, vec.z);
        float dis = Vector2.Distance(my,other);

        return dis;
    }

    ///<summary>プレイヤーに近づく</summary>
    private void Move_isPlayer()
    {
        //距離が20以下になるまで近づく
        if (DistanceCheck(player.transform.position) > 20)
        {
            Vector2 my = new Vector2(transform.position.x, transform.position.z);
            Vector2 other = new Vector2(player.transform.position.x, player.transform.position.z);
            Vector2 dis= Vector2.Lerp(my,other,0.02f);
            
            transform.position= new Vector3(dis.x,transform.position.y,dis.y);
        }
    }
    ///<summary>攻撃するか考える</summary>
    private void AttackThink()
    {
        //距離が30以内で
        if(DistanceCheck(player.transform.position) < 30)
        {
            //攻撃状態でないとき
            if(!attackOn)
            {
                
                float rnd = Random.Range(0, 100);
                //rndが20以内の場合攻撃
                if((int)rnd<35)
                {
                    attackOn = true;
                    SetAttackNumber();
                }
            }
        }
    }
    ///<summary>なんの攻撃をするか決める</summary>
    private void SetAttackNumber()
    {
        float rad = Random.Range(0, 0.2f);
        attackNumber = (int)(rad*10);
    }
    ///<summary>プレイヤーに向かって突進</summary>
    private void Rush()
    {
        Vector3 dis = player.transform.position - transform.position;
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.08f);
    }
    ///<summary>プレイヤーに向けて魔法を使う</summary>
    private void MagicAttack()
    {
        GameObject obj = Instantiate(attackObj);
        obj.transform.position = transform.position;
        Vector3 playerPosi;
        if (!GameObject.Find("player"))
            return;
        player = GameObject.Find("player");
        playerPosi = player.transform.position;

        Vector3 dis = new Vector3(playerPosi.x - transform.position.x,
            playerPosi.y - transform.position.y,
            playerPosi.z - transform.position.z);

        dis.Normalize();

        obj.GetComponent<s_AttackEnemyControl>().SetVelocity(dis);

        attackOn = false;
        attackThinkTimer = Random.Range(60 * 3, 60 * 6);

    }
    ///<summary>攻撃していなければ空中に</summary>
    private void Fly()
    {
        if (transform.position.y < 10)
            transform.position += new Vector3(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (attackOn)
        {
            switch (attackNumber)
            {
                case 0:
                    if (other.gameObject.name == "o_player" || other.gameObject.name == "stage")
                    {
                        attackOn = false;
                        attackThinkTimer = Random.Range(60 * 3, 60 * 6);
                    }
                    break;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (attackOn)
        {
            switch (attackNumber)
            {
                case 0:
                    if (collision.gameObject.name == "o_player" || collision.gameObject.name == "stage")
                    {
                        attackOn = false;
                        attackThinkTimer = Random.Range(60 * 3, 60 * 6);
                    }
                    break;
            }
        }
    }
}
