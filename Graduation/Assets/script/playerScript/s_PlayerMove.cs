using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//end
///<summary>移動制御</summary>
public class s_PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    ///<summary>移動量</summary>
    private Vector2 velocity;
    ///<summary>カメラ</summary>
    public GameObject playerCamera;
    ///<summary>playerのRigidbody</summary>
    private Rigidbody rig;
    ///<summary>ダッシュ受付時間</summary>
    private int dashTimer;
    ///<summary>ダッシュしているか</summary>
    private bool dashOn, dashOn2;
    ///<summary>前回の移動量</summary>
    private Vector2 prevec;

    private int a, s, d, w,j;
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        rig = GetComponent<Rigidbody>();
        dashOn = false;
        dashOn2 = false;
        a = 0; s = 0; d = 0; w = 0;j=0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    ///<summary>移動処理（引数は必ず自分のTransfoemで呼び出す事！）</summary>
    public void Move(Transform tran)
    {
        //プレイヤー以外からの呼び出しを受け付けない
        if (tran.tag != "Player")
            return;

        velocity = Vector2.zero;


        velocity.x = Input.GetAxis("HorizontalJ");
        velocity.y = Input.GetAxis("VerticalJ");

        if (velocity != Vector2.zero && prevec == Vector2.zero)
        {
            if (j > 0)
            {

                dashOn2 = true;
            }
            j = 20;
        }
        else
        {
            if (dashOn2)
                if (velocity == Vector2.zero)
                    dashOn2 = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (a > 0)
                dashOn = true;
            a = 10;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (d > 0)
                dashOn = true;
            d = 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (w > 0)
                dashOn = true;
            w = 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (s > 0)
                dashOn = true;
            s = 10;
        }

        if (Input.GetKey(KeyCode.A))
            velocity.x = -1;
        if (Input.GetKey(KeyCode.D))
            velocity.x = 1;
        if (Input.GetKey(KeyCode.W))
            velocity.y = 1;
        if (Input.GetKey(KeyCode.S))
            velocity.y = -1;



a--;
w--;
s--;
d--;
j--;

if(dashOn)
{
  if (!Input.GetKey(KeyCode.A)&!Input.GetKey(KeyCode.S)&&
!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.W))
dashOn=false;


}



        Vector3 cameraForward = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * velocity.y + playerCamera.transform.right * velocity.x;

        if (dashOn||dashOn2)
            moveForward *= 0.35f;
        else
            moveForward *= 0.2f;



        transform.position += moveForward;
        prevec = velocity;


  Debug.Log(dashOn2);
      

    }
    ///<summary>プレイヤーの回転処理（引数は必ず自分のTransformで呼び出す事！）</summary>
    public void Rotation(Transform tran)
    {

        //プレイヤー以外からの呼び出しを受け付けない
        if (tran.tag != "Player")
            return;

        Vector2 rot = Vector2.zero;

        rot.x = Input.GetAxis("Horizontal2");
        rot.y = Input.GetAxis("Vertical2");

        if (Input.GetKey(KeyCode.LeftArrow))
            rot.x = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            rot.x = 1;
        if (Input.GetKey(KeyCode.UpArrow))
            rot.y = -1;
        if (Input.GetKey(KeyCode.DownArrow))
            rot.y = 1;



        if (playerCamera.transform.localEulerAngles.x > 60 && playerCamera.transform.localEulerAngles.x < 180)
        {
            if (rot.y > 0)
                rot.y = 0;
        }
        if (playerCamera.transform.localEulerAngles.x < 360 - 60 && playerCamera.transform.localEulerAngles.x > 180)
        {
            if (rot.y < 0)
                rot.y = 0;
        }
        rot *= 3;

        transform.Rotate(transform.up, rot.x);
        playerCamera.transform.Rotate(Vector3.right, rot.y);

    }
    ///<summary>ジャンプ</summary>
    public void Jump(Transform tran)
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("A"))
        {
            Vector3 vel = Vector3.zero;
            vel.y = 5;
            rig.velocity += vel;
        }


    }
}
