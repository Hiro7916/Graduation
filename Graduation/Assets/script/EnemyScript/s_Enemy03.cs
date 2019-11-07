using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>enemy03の行動</summary>
public class s_Enemy03 : MonoBehaviour
{
    ///<summary>モーションの名前</summary>
    private List<string> motionName;
    ///<summary>戦闘状態</summary>
    private bool battleState;
    ///<summary>プレイヤー</summary>
    private GameObject player;
    ///<summary>行動関数</summary>
    private delegate void Action();
    private Rigidbody rig;
    ///<summary>関数リスト</summary>
    private List<Action> startMoveActions;
    private List<Action> MoveActions;
    private List<Action> startbattleActions;
    private List<Action> battleActions;
    ///<summary>実行する関数リスト</summary>
    private int actionNum;
    private int preActionNum;
    private int moveActionNum;
    private int preMoveActionNum;
    #region 移動
    private int moveTimer;
    #endregion
    #region 待機
    ///<summary>待機時間</summary>
    private int waitTime;
    #endregion
    #region 攻撃
    ///<summary>攻撃オブジェ</summary>
    public GameObject obj;
    private List<GameObject> attackobj;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("o_player") != null)
            player = GameObject.Find("o_player");

        battleState = false;

        motionName = new List<string>() { "WAIT00", "RUN00_F", "HANDUP00_R" };
        rig = GetComponent<Rigidbody>();
        //Listを生成
        startMoveActions = new List<Action>();
        MoveActions = new List<Action>();
        startbattleActions = new List<Action>();
        battleActions = new List<Action>();
        //関数セット
        SetMoveAction();
        SetBattleAction();
        //Actionnumを初期化
        actionNum = 0;
        preActionNum = MoveActions.Count + 1;
        moveActionNum = 0;
        preMoveActionNum = MoveActions.Count + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面などが開かれていたら何もしない
        if (s_PoseControl.GetLoadPose())
            return;

        if (!battleState)
        {
            PlayerDisCheck();
            //実行するActionが切り替えられた場合
            if (preMoveActionNum != moveActionNum)
            {
                startMoveActions[moveActionNum]();
                //1フレーム前の番号を記憶
                preMoveActionNum = moveActionNum;
            }
            //Action関数を実行
            MoveActions[moveActionNum]();
        }
        else
        {
            //実行するActionが切り替えられた場合
            if (preActionNum != actionNum)
            {
                startbattleActions[actionNum]();
                //1フレーム前の番号を記憶
                preActionNum = actionNum;
            }
            //Action関数を実行
            battleActions[actionNum]();
        }
    }
    ///<summary>関数セット</summary>
    private void SetMoveAction()
    {
        //移動
        startMoveActions.Add(MoveStart);
        MoveActions.Add(Move);
        //待機
        startMoveActions.Add(WaitStart);
        MoveActions.Add(Wait);
    }
    ///<summary>関数セット</summary>
    private void SetBattleAction()
    {

        startbattleActions.Add(AttackStart);
        battleActions.Add(Attack);
    }

    ///<summary>移動</summary>
    private void MoveStart()
    {
        GetComponent<s_AnimationControl>().ChangeAnime(motionName[1]);
        moveTimer = 60 * Random.Range(3, 10);
        transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), new Vector3(0, 1, 0));
    }
    ///<summary>移動</summary>
    private void Move()
    {
        rig.AddForce(transform.forward * 40);

        moveTimer--;
        if (moveTimer <= 0)
        {
            MoveThink();
        }
    }
    private void MoveLoop()
    {
        preMoveActionNum = MoveActions.Count + 1;
    }
    ///<summary>その場で待機(Action関数)</summary>
    private void WaitStart()
    {
        GetComponent<s_AnimationControl>().ChangeAnime(motionName[0]);
        waitTime = 60 * 3;
        Debug.Log("waitStart");
    }
    ///<summary>その場で待機(Action関数)</summary>
    private void Wait()
    {
        waitTime--;

        if (waitTime <= 0)
        {
            Debug.Log("waitEnd");
            MoveThink();
        }
    }
    ///<summary>移動か待機か考える</summary>
    private void MoveThink()
    {
        Random rnd = new Random();
        moveActionNum = Random.Range(0, 2);
        preMoveActionNum = MoveActions.Count + 1;
        Debug.Log("Think");
    }

    private void PlayerDisCheck()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 50)
        {
            Random rnd = new Random();
            actionNum = Random.Range(0, 1);
            preActionNum = MoveActions.Count + 1;
            Debug.Log(actionNum);
            battleState = true;
        }
    }
    ///<summary>攻撃(Action関数)</summary>
    private void AttackStart()
    {
        GetComponent<s_AnimationControl>().ChangeAnime(motionName[2]);
        Debug.Log("ATstart");

        GameObject ob = Instantiate(obj);

        ob.transform.position = transform.Find("AddPosition").transform.position;
        ob.transform.parent = transform;
        ob.transform.forward = transform.forward;
        ob.transform.localScale = new Vector3(1, 0.5f, 0.5f);
    }
    ///<summary>攻撃(Action関数)</summary>
    private void Attack()
    {
        transform.LookAt(player.transform);
        if (Vector3.Distance(player.transform.position, transform.position) >= 5)
            rig.AddForce(transform.forward * 200);
    }
}