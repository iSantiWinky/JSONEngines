using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int state = 0; //0 = idle, 1 = walk, 2 = dash ...
    private CharacterController ctrl;
    public float moveSpeed = 2f;
    public float resetTime = .2f;
    public float dashTime = 1f;
    public float dashSpeed = 6f;
    public float gravity = -9.81f;
    public bool grounded;
    private Vector3 playerVelocity;
    public GameObject showMovePositon;
    public float angle;
    private Vector3 move;
    private Vector3 dashV = Vector3.forward;


    // Start is called before the first frame update
    void Start()
    {
        ctrl = gameObject.AddComponent<CharacterController>();
    }
    void LateUpdate()
    {
        showMovePositon.transform.position = transform.position + move * 2f;
    }
    // Update is called once per frame
    void Update()
    {
        grounded = ctrl.isGrounded;

        if (grounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        move = new Vector3(xAxis,0,zAxis);

        playerVelocity.y += gravity * Time.deltaTime;

        if (state == 0)//Idle
        {
            ctrl.Move(playerVelocity * Time.deltaTime);
            if (move != Vector3.zero)
            {
                state = 1;
            }
        }
        else
        if (state == 1)//Walk
        {
            ctrl.Move(move * Time.deltaTime * moveSpeed);
            ctrl.Move(playerVelocity * Time.deltaTime);

            Vector3 targetDir = showMovePositon.transform.position - transform.position;
            dashV = targetDir;

            angle = Vector3.Angle(targetDir, transform.forward);

            transform.Rotate(0,angle,0);

            if (move == Vector3.zero)
            {
                state = 0;
            }
        }
        else
        if (state == 2)//Dash
        {
            myFirstDash();
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            if (state != 2)
            {
                state = 2;
            }
                
        }


    }
    private void myFirstDash()
    {
        ctrl.Move(dashV * dashSpeed * Time.deltaTime);

        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
        }
        else
        {
            state = 0;
            dashTime = resetTime;
        }
    }
}
