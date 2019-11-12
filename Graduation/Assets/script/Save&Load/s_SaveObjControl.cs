using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>セーブオブジェクト</summary>
public class s_SaveObjControl : MonoBehaviour
{
    ///<summary>セーブオブジェクトのパーティクル</summary>
    public GameObject particle;
    ///<summary>何秒ごとにオブジェクトを追加するか</summary>
   　private int addObjTimer;
    ///<summary>秒数を記憶</summary>
    private int memoryAddObjTimer;
    ///<summary>パーティクル管理用リスト</summary>
    List<GameObject> particles;
    // Start is called before the first frame update
    void Start()
    {
        addObjTimer =  20;
        memoryAddObjTimer = addObjTimer;
        particles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
        AddParticle();
        ParticleUpdate();
    }
    void TimerUpdate()
    {
        ///<summary>毎フレームタイマーを減らす</summary>
        if (addObjTimer > 0)
            addObjTimer--;

    }
    ///<summary>パーティクルを追加</summary>
    void AddParticle()
    {
        //時間がきたら
        if(addObjTimer<=0)
        {
            //オブジェクトを生成
            GameObject par = Instantiate(particle, transform.position, Quaternion.identity);
            //transfromを初期化
            par.transform.Rotate(Vector3.right,90);
            par.transform.localScale=new Vector3(2,2,2);
            //タイマーを再セット
            addObjTimer = memoryAddObjTimer;
            //オブジェクトを追加
            particles.Add(par);
        }
    }

    ///<summary>パーティクルの管理</summary>
    void ParticleUpdate()
    {
        //リストに何も登録されていなければ何もしない
        if (particles.Count == 0)
            return;

        for(int i=0;i<particles.Count;i++)
        {
            //パーティクルの位置を変更
            Vector3 posi = particles[i].transform.position;
            posi.y += 0.02f;
            particles[i].transform.position = posi;

            //一定の位置を超えたらパーティクルを削除
            if (Mathf.Abs(transform.position.y - particles[i].transform.position.y)> 6)
            {
                Destroy(particles[i]);
                particles.Remove(particles[i]);
            }

        }
    }
   
}
