﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public FirstPersonCamera view;

    [HideInInspector]
    public GameObject entityCatched = null;

    Player player;
    float entityCatchedDistance = 0.0f;
    bool grounded = false;
    Rigidbody playerRigidbody;
    Animator animator;

    int unableCount = 0;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }
    // Use this for initialization
    void Start() {
        RegsiterVoiceEvent();
    }

    //添加语音事件
    private void RegsiterVoiceEvent()
    {
        var voiceInputManager = GameObject.FindGameObjectWithTag("VoiceInputManager").GetComponent<VoiceInputManager>();
        voiceInputManager.AddEvent("fire ball", () => { UseMagic(1); });
        voiceInputManager.AddEvent("The sky set you aflame", () => { UseMagic(1); });
        voiceInputManager.AddEvent("Sun strike", () => { UseMagic(2); });
        voiceInputManager.AddEvent("follow my will", () => { UseMagic(4); });
        voiceInputManager.AddEvent("leave for my will", () => { UseMagic(5); });
    }

    public void UseMagic(int index)
    {
        switch (index)
        {
            case 1:
                animator.SetTrigger("FireBall");
                break;
            case 2:
                animator.SetTrigger("LightBeam");
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        if (entityCatched != null)
        {
            entityCatched.transform.position = transform.position + entityCatchedDistance * Camera.main.transform.forward;
            entityCatched.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (unableCount > 0) return;
        //WASD移动
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        PlayerMove(h, v);
        //跳跃
        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }
        //点击
        if (Input.GetButtonDown("Fire1")) {

        }
        //右键
        if (Input.GetButtonDown("Fire2"))
        {
            animator.Play("UseStick");

            var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            ray.origin = transform.position;

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;

                if (gameObj.layer == LayerMask.NameToLayer("Entity"))
                {
                    entityCatched = gameObj;
                    entityCatchedDistance = (entityCatched.transform.position - transform.position).magnitude;
                }
            }
        }
        //右键
        if (Input.GetButtonUp("Fire2"))
        {
            entityCatched = null;
        }

    }

    // 落地检测
    void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    void PlayerJump()
    {
        if (grounded == true)
        {
            playerRigidbody.velocity += new Vector3(0, player.JumpForce * 1.5f, 0);    //添加加速度
            grounded = false;
        }
    }

    void PlayerMove(float h, float v)
    {
        var body = GetComponent<Rigidbody>();

        var dir = (view.transform.forward * v + view.transform.right * h);
        dir.y = 0;
        dir.Normalize();

        body.velocity = player.Speed * dir + new Vector3(0, body.velocity.y, 0);

    }

   
    public void SetControllalbe(bool able)
    {
        if (able)
        {
            unableCount--;
            if(unableCount == 0)view.enabled = true;
        }
        //禁用时，角色停下来
        else
        {
            unableCount++;
            if(unableCount == 1)
            {
                var body = GetComponent<Rigidbody>();
                body.velocity = new Vector3(0, body.velocity.y, 0);
                view.enabled = false;
            }
        }
    }
}
