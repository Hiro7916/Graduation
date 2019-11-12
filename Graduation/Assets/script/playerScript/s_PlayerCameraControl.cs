using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//end
///<summary>playerの持つカメラをコントロール</summary>
public class s_PlayerCameraControl : MonoBehaviour
{

    ///<summary>mainカメラ</summary>
    public new Camera camera;
    ///<summary>カメラがターゲットにするオブジェクト</summary>
    private GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        //開始時はターゲットなし
        targetObject = null;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>ターゲットをカメラの中心に(引数は自分のTransformで呼び出す)</summary>
    public void CameraTarget(Transform tran)
    {
        //player以外からの呼び出しを拒否
        if (tran.name != "o_player")
            return;

        //ターゲットがあった場合はプレイヤーをターゲットに向かせる
        if (targetObject != null)
        {
            Transform forw = targetObject.transform;
            Quaternion lockRotation = Quaternion.LookRotation(targetObject.transform.position - transform.position, Vector3.up);
            lockRotation.z = 0;
            lockRotation.x = 0;
            transform.rotation = lockRotation;
            camera.transform.LookAt(targetObject.transform, Vector3.up);
        }
    }
    ///<summary>ターゲットのon,offの切り替え(引数は自分のTransformで呼び出す)</summary>
    public void TargetChange(Transform tran)
    {

        //player以外からの呼び出しを拒否
        if (tran.name != "o_player")
            return;

        if (targetObject == null)
        {
            //ターゲットが登録されていなければ探す
            CheckTarget();
        }
        else
        {
            //ターゲットが登録されていれば解除する
            targetObject = null;
        }

    }
    ///<summary>カメラの中心に近いオブジェクトを探す</summary>
    private void CheckTarget()
    {
        if (camera == null)
            return;

        int num = 0;
        GameObject[] tagobjs = GameObject.FindGameObjectsWithTag("Enemy");
        float dis = 0;
        bool on = false;
        if (tagobjs[0] == null)
            return;
        Vector3 vec = Vector3.zero;
        for (int i = 0; i < tagobjs.Length; i++)
        {
            vec = camera.WorldToViewportPoint(tagobjs[i].transform.position);
            if (vec.x < 0 ||
                vec.x > 1 ||
                vec.y < 0 ||
                vec.y > 1)
            {
                continue;
            }
            else
            {
                if (vec.z < 0)
                    continue;
            }

            if (!on)
            {
                dis = Vector2.Distance(new Vector2(vec.x, vec.y), new Vector2(0.5f, 0.5f));
                num = i;
                on = true;
            }
            else
            {
                if (dis >= Vector2.Distance(new Vector2(vec.x, vec.y), new Vector2(0.5f, 0.5f)))
                {
                    dis = Vector2.Distance(new Vector2(vec.x, vec.y), new Vector2(0.5f, 0.5f));
                    num = i;
                }
            }
        }
        if (on)
            targetObject = tagobjs[num];
    }
}
