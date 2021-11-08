using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform mTarget;

    private Vector3 move;
    public float speed = 1f;
    public float epsilon = 0.1f;

    public static bool huntPlayer = false;
    public static Transform player;

    private Quaternion lastAngle;
    private CharacterController ctrl;
    private void Start()
    {
        ctrl = gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
        if(huntPlayer)
        {
            mTarget.transform.position = player.transform.position;
            Movement();
        }
        else if(!huntPlayer)
        {
            transform.rotation = lastAngle;
        }

    }

    private void Movement()
    {
        //move = (mTarget.position - transform.position).normalized;
        //transform.Translate(move * Time.deltaTime * speed);

        float x = mTarget.position.x;
        float z = mTarget.position.z;
        move = new Vector3(x, 0, z);
        ctrl.Move(move * Time.deltaTime * speed);

        Quaternion q = Quaternion.LookRotation(move);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime*speed);
    }


}
