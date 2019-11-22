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
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        rig = GetComponent<Rigidbody>();
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


        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");

        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
            velocity.x = -1;
        if (Input.GetKey(KeyCode.D))
            velocity.x = 1;
        if (Input.GetKey(KeyCode.W))
            velocity.y = 1;
        if (Input.GetKey(KeyCode.S))
            velocity.y = -1;



        Vector3 cameraForward = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * velocity.y + playerCamera.transform.right * velocity.x;
        moveForward *= 0.3f;
        transform.position+=moveForward;


    }
    ///<summary>プレイヤーの回転処理（引数は必ず自分のTransformで呼び出す事！）</summary>
    public void Rotation(Transform tran)
    {

        //プレイヤー以外からの呼び出しを受け付けない
        if (tran.tag != "Player")
            return;

        Vector2 rot =Vector2.zero;

        rot.x = Input.GetAxis("Horizontal2");
        rot.y = Input.GetAxis("Vertical2");

        rot = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
            rot.x = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            rot.x = 1;
        if (Input.GetKey(KeyCode.UpArrow))
            rot.y = -1;
        if (Input.GetKey(KeyCode.DownArrow))
            rot.y = 1;



        if (playerCamera.transform.localEulerAngles.x >60&&playerCamera.transform.localEulerAngles.x<180)
        {
            if (rot.y > 0)
                rot.y = 0;
        }
        if (playerCamera.transform.localEulerAngles.x <360- 60 && playerCamera.transform.localEulerAngles.x > 180)
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 vel = Vector3.zero;
            vel.y = 5;
            rig.velocity += vel;
        }
    }
}
