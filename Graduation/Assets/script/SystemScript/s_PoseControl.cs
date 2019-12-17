using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>ゲーム一時停止用</summary>
public class s_PoseControl : MonoBehaviour
{
    ///<summary>ロード画面表示中か(表示中ならtrue)</summary>
    static  bool  windPose = false;
static bool save=false;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>windを開いているかを変更</summary>
    public static void ChangeWindPose(bool bo)
    {
        windPose = bo;
    }
    public static void ChangeWindsavePose(bool bo)
    {
        save= bo;
    }
    ///<summary>windを開いているかを取得</summary>
    public static bool GetLoadPose()
    {
        return windPose;
    }
    public static bool GetLoadsavePose()
    {
        return save;
    }
}
