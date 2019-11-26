using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>エネミーの状態管理</summary>
public class s_EnemyState : MonoBehaviour
{
    ///<summary>体力</summary>
    private int hp;
    ///<summary>死亡しているか</summary>
    private bool deadFlag;
    ///<summary>死亡時に落とすアイテム</summary>
    public GameObject dropItem;
    ///<summary>ダメージを受けたときに表示するUI</summary>
    public GameObject damageUi;
    // Start is called before the first frame update
    void Start()
    {
        //体力と死亡フラグを初期化
        hp = 100;
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
                GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene("ClearH");
            }
            else
            { 
            }


            Instantiate(dropItem,transform.position+new Vector3(0,1,0),Quaternion.identity);
        }
    }

}
