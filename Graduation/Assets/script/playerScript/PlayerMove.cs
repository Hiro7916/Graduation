using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;
    GameObject playerCamera;
    Rigidbody rig;
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        playerCamera = transform.Find("Main Camera").gameObject;
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
    }

    void Move()
    {
        velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            velocity.x = -1;
        if (Input.GetKey(KeyCode.D))
            velocity.x = 1;
        if (Input.GetKey(KeyCode.W))
            velocity.y = 1;
        if (Input.GetKey(KeyCode.S))
            velocity.y = -1;

        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");

        Vector3 cameraForward = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * velocity.y + playerCamera.transform.right * velocity.x;
        moveForward *= 50;
        rig.AddForce(moveForward);


    }
    void Rotation()
    {
        Vector2 rot=Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            rot.x = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            rot.x = 1;
        if (Input.GetKey(KeyCode.UpArrow))
            rot.y = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            rot.y = -1;


        rot.x = Input.GetAxis("Horizontal2");   
        rot.y = Input.GetAxis("Vertical2");

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

}
