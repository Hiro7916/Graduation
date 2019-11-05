using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>enemy01の行動</summary>
public class s_Enemy01 : MonoBehaviour
{
    ///<summary>行動関数</summary>
    private delegate void Action();
    private Rigidbody rig;
    ///<summary>関数リスト</summary>
    private List<Action> startActions;
    private List<Action> actions;
    ///<summary>実行する関数リスト</summary>
    private int actionNum;
    private int preActionNum;

    #region 移動
    private int moveTimer;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        //Listを生成
        startActions = new List<Action>();
        actions = new List<Action>();
        //関数セット
        SetAction();

        //Actionnumを初期化
        actionNum = 0;
        preActionNum = actions.Count + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面などが開かれていたら何もしない
        if (s_PoseControl.GetLoadPose())
            return;


        //実行するActionが切り替えられた場合
        if (preActionNum != actionNum)
        {
            startActions[actionNum]();
            //1フレーム前の番号を記憶
            preActionNum = actionNum;
        }

        //Action関数を実行
        actions[actionNum]();
    }
    ///<summary>関数セット</summary>
    private void SetAction()
    {
        //移動
        startActions.Add(MoveStart);
        actions.Add(Move);
    }

    ///<summary>移動</summary>
    private void MoveStart()
    {
        moveTimer = 60*Random.Range(3,10);
        transform.rotation = Quaternion.AngleAxis(Random.Range(0,360),new Vector3(0,1,0));
    }
    ///<summary>移動</summary>
    private void Move()
    {
        rig.AddForce(transform.forward*40);

        moveTimer--;

        if (moveTimer <= 0)
        {
            MoveLoop();
        }
    }
    private void MoveLoop()
    {
        preActionNum = actions.Count + 1;
    }
}
