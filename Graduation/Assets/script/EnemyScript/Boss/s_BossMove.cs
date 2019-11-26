using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>ボスの挙動</summary>
public class s_BossMove : MonoBehaviour
{
    ///<summary>フラグがたつまで行動しないよう</summary>
    private bool moveOnCheck;
    ///<summary>プレイヤーが近づいたか</summary>
    private bool playerNear;
    ///<summary>行動関数</summary>
    private delegate void Action();
    ///<summary>関数リスト</summary>
    private List<Action> startActions;
    private List<Action> actions;
    ///<summary>実行する関数リスト</summary>
    private int actionNum;
    private int preActionNum;
    ///<summary>プレイヤーを取得する</summary>
    private GameObject player;
    ///<summary>プレイヤーの位置を記憶</summary>
    private Vector3 playerPosition;
    #region 待機
    ///<summary>待機時間</summary>
    private int waitTime;
    #endregion

    #region 魔法攻撃
    ///<summary>攻撃を始めているか</summary>
    private bool attackStart;
    ///<summary>攻撃時間</summary>
    private int attackTime;
    ///<summary>パーティクル炎</summary>
    public GameObject flameObj;
    private GameObject memoFlameObj;
    #endregion
    #region 突進攻撃
    ///<summary>攻撃を終わらすか</summary>
    private bool rushEnd;
    ///<summary>攻撃時間</summary>
    private int rushTimer;
    #endregion

    private void Start()
    {
        //Listを生成
        startActions = new List<Action>();
        actions = new List<Action>();
        //関数セット
        SetAction();
        //Actionnumを初期化
        actionNum = 0;   
        preActionNum = actions.Count + 1;
        Think();
        //プレイヤーを取得
        if (GameObject.Find("player") != null)
            player = GameObject.Find("player");

        playerNear = false;
        moveOnCheck = false;
    }

    private void Update()
    {
        if (!playerNear)
        {

            if (Vector3.Distance(transform.position, player.transform.position) < 30)
            {
                playerNear = true;
            }
            return;
        }
     
        //フラグがたったら行動
        if (!moveOnCheck )
        {
            return;
        } 
        //ポーズ画面などが開かれていたら何もしない
        if (s_PoseControl.GetLoadPose())
            return;
        //プレイヤーがいなければ何もしない
        if (player == null)
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
    ///<summary>関数をセット</summary>
    private void SetAction()
    {
        //待機
        startActions.Add(WaitStart);
        actions.Add(Wait);
        //炎攻撃
        startActions.Add(AttackStart);
        actions.Add(Attack);
        //突進
        startActions.Add(RushStart);
        actions.Add(Rush);

    }
    ///<summary>次の行動を考える</summary>
    private void Think()
    {
        Random rnd = new Random();
        actionNum = Random.Range(0, 3);
        preActionNum = actions.Count + 1;
       // Debug.Log("Think");
    }
    ///<summary>その場で待機(Action関数)</summary>
    private void WaitStart()
    {
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
            Think();
        }
    }
    ///<summary>炎攻撃(Action関数)</summary>
    private void AttackStart()
    {
        Debug.Log("attackStart");
        attackStart = false;
        attackTime =  60 * 5;
    }
    ///<summary>炎攻撃(Action関数)</summary>
    private void Attack()
    {
        if (!attackStart)
        {
            playerPosition = player.transform.position;
            playerPosition.y = transform.position.y;
            transform.LookAt(playerPosition);

            Transform add = transform.Find("AddParticle");
            memoFlameObj = Instantiate(flameObj,add.position,add.rotation);
            memoFlameObj.transform.parent= transform.Find("AddParticle");
            attackStart = true;
        }
        else
        {
            Vector3 velo = Vector3.Lerp(transform.position,playerPosition,0.02f);
            transform.position = velo;

            attackTime--;
            if (attackTime <= 0||transform.position==playerPosition)
            {
                Destroy(memoFlameObj);
                Think();
                Debug.Log("attackEnd");
            }
        }
    }
    ///<summary>突進攻撃(Action関数)</summary>
    private void RushStart()
    {
        Debug.Log("RushStart");
        rushEnd = false;
        rushTimer = 60 * 3;
        playerPosition = player.transform.position;
        transform.LookAt(playerPosition);
    }
    ///<summary>突進攻撃(Action関数)</summary>
    private void Rush()
    {    
        if (rushTimer <= 0 || rushEnd)
        {
            if (transform.position.y < 7)
            {
                Vector3 posi = transform.position;
                posi.y += 0.5f;
                transform.position = posi;
            }
            else
            {
                Think();
            }
        }
        else
        {
            Vector3 velo = Vector3.Lerp(transform.position, playerPosition, 0.08f);
            if (Vector3.Distance(velo, transform.position) < 0.2f)
                rushEnd = true;

            transform.position = velo;

            rushTimer--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "stage")
        {
            rushEnd = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       Debug.Log( collision.gameObject.name);
        if (collision.gameObject.tag == "stage")
        {
            rushEnd = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<s_PlayerGuard>().GuardCheck(transform.position, false))
                collision.gameObject.GetComponent<s_PlayerStatus>().Damage(10);
        }
    }
    ///<summary>ボスが行動できるかの設定</summary>
    public void SetMoveOnCheck(bool bo)
    {
        moveOnCheck = bo;
    }
    private void OnParticleCollision(GameObject other)
    {

    }
    private void OnParticleTrigger()
    {
        Debug.Log("pT");
    }
}
