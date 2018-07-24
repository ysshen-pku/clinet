﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    public Transform shootPoint;
    public float MaxUpdownAngle = 10f;

    public float MoveSpeed = 3f;
    public float RotateSpeed = 3f;
    public Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_Move;
    private float updownAngle=0f;
        private Animator anim;                      // Reference to the animator component.
        private Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
#if !MOBILE_INPUT
        private int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        private float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif

        void Awake()
        {
            // Set up references.
            anim = GetComponent<Animator>();
            playerRigidbody = GetComponent<Rigidbody>();
        m_Cam = GetComponentInChildren<Camera>().transform;
        }

        void Start()
        {
            //mCamera = Camera.main;
            //Debug.Log("mouselookInit");
           // mouseLook.Init(transform, mCamera.transform);
         //   Debug.Log("mouselookFIn");
        }


    void FixedUpdate()
        {
            // Store the input axes.
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");


            // we use world-relative directions in the case of no main camera
            m_Move = v * transform.forward + h * transform.right;

        m_Move *= MoveSpeed*Time.deltaTime;

        transform.position += m_Move;
        //playerRigidbody.MovePosition(transform.position + m_Move);
        Rotate();
        // Animate the player.
        Animating(h, v);
        }


        void Rotate()
    {
        //相机旋转
        
        float x = RotateSpeed * Input.GetAxis("Mouse X");

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles +
            Quaternion.AngleAxis(x, Vector3.up).eulerAngles
        );

        updownAngle += RotateSpeed* 0.2f * Input.GetAxis("Mouse Y");
        float currentAngle = -Clamp(updownAngle, MaxUpdownAngle);
        //Debug.Log(-Clamp(updownAngle, MaxUpdownAngle));
        shootPoint.localEulerAngles = new Vector3(currentAngle, 0,0);
        m_Cam.localEulerAngles = new Vector3(currentAngle, m_Cam.localEulerAngles.y, m_Cam.localEulerAngles.z);

    }

    public float Clamp(float value, float max)
    {
        if (value > max) return max;
        if (value < -max) return -max;
        return value;
    }

        void Animating(float h, float v)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = h != 0f || v != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool("IsWalking", walking);
        }
}
