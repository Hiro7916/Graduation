using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///<summary>ダメージを受けた時のUI</summary>
public class s_DamageUiControl : MonoBehaviour
{
    ///<summary>表示位置</summary>
    private　Vector3 velocity;
    ///<summary>表示テキスト</summary>
    public TextMesh text;
    ///<summary>表示時間</summary>
    private int deadTimer;
    // Start is called before the first frame update
    void Start()
    {
        //表示位置の登録
        velocity = Vector3.up*0.05f;
        //UIを消す時間の登録
        deadTimer = 2 * 60;
    }

    // Update is called once per frame
    void Update()
    {
        CameraLook();
        DeadTimerUpdate();
        Dead();
    }
    ///<summary>表示Textの変更</summary>
    public  void SetDamage(string s)
    {
        text.text = s;
    }
    ///<summary>常にカメラの方を向くように（ビルボード）</summary>
    void CameraLook()
    {
        Vector3 posi = transform.position;
        posi += velocity;
        transform.position = posi;
        if (GameObject.Find("Main Camera") != null)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - GameObject.Find("Main Camera").transform.position);
        }
    }
    ///<summary>消滅時間のカウント</summary>
    void DeadTimerUpdate()
    {
        if (deadTimer > 0)
            deadTimer--;
    }
    ///<summary>時間が来たら消す</summary>
    void Dead()
    {
        if (deadTimer <= 0)
            Destroy(this.gameObject);
    }
}
