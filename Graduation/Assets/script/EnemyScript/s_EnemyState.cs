using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>エネミーの状態管理</summary>
public class s_EnemyState : MonoBehaviour
{
    ///<summary>体力</summary>
    public int hp;
public int maxHp;
    ///<summary>死亡しているか</summary>
    private bool deadFlag;
    ///<summary>死亡時に落とすアイテム</summary>
    public GameObject dropItem,drop2;
    ///<summary>ダメージを受けたときに表示するUI</summary>
    public GameObject damageUi;
    // Start is called before the first frame update

    public GameObject next;
    void Start()
    {
        //体力と死亡フラグを初期化
        if (hp == 0)
            hp = 100;

maxHp=hp;
        deadFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        DeadCheck();
        Dead();
    }
    ///<summary>ダメージを受ける</summary>
    public void Damage(int dame,string propety)
    {
        //if (GetComponent<s_Property>() != null)
        //{
        //    if(GetComponent<s_Property>().PropertyCheck(propety)==1)
        //    {
        //        dame *= 2;
        //    }
        //    if (GetComponent<s_Property>().PropertyCheck(propety) == 2)
        //    {
        //        dame /=2 ;
        //    }
        //}
        if (transform.name == "Boss(Clone)")
        {
            Debug.Log(propety);
            if (propety == "水")
            {
                dame *= 2;
            }
            else
            {
                dame = 0;
            }
        }
        if (transform.name == "Enemy01(Clone)")
        {
            if (propety == "火")
            {
                dame *= 2;
            }

        }

if(GetComponent<eneDame>()!=null)
{
GetComponent<eneDame>().Dame();
}

        //hpを減らす
        hp -= dame;
        //ダメージUIを生成
        GameObject obj= Instantiate(damageUi, transform.Find("DamageUiPosition").transform.position, Quaternion.identity);
        obj.GetComponent<s_DamageUiControl>().SetDamage(dame.ToString());
    }
    ///<summary>死亡しているか確認</summary>
    void DeadCheck()
    {
        //hpが0以下なら死亡フラグをtrueに
        if (hp <= 0)
            deadFlag = true;
    }
    ///<summary>ゲームオブジェクトを削除</summary>
    void Dead()
    {
        //死亡フラグがtrueなら自身を削除
        if(deadFlag)
        {
            Destroy(this.gameObject);

            if(this.name=="Boss")
            {
                 GameObject obj=  Instantiate(next);
                 obj.transform.position = transform.position;
            }
            else
            { 
            }


            Instantiate(dropItem,transform.position+new Vector3(0,1,0),Quaternion.identity);
int r=Random.Range(0,2);
Debug.Log(r);

if(r>=1)
            Instantiate(drop2,transform.position+new Vector3(0,1,0),Quaternion.identity);

        }
    }

    public bool HitstageChack()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 1.5f, 0), transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2.5f))
            if (hit.transform.tag == "stage")
            {

                return true;
            }


        return false;

    }

}
