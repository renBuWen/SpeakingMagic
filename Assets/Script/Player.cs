using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Animator animator;
    public ParticleSystem fireBallParticle;
    public ParticleSystem lightParticle;
 //   int count = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        fireBallParticle.Stop();
        lightParticle.Stop();
    }

    public void handleInput(string str)
    {

    }

    public void UseMagic(int index) {
        StopMagic();
        switch (index)
        {
            case 1:
                animator.Play("UseStick");
                fireBallParticle.Play();
                break;
            case 2:
                animator.Play("UseStick");
                lightParticle.Play();
                break;
        }
        Invoke("StopMagic", 1.0f);
    }

    public void StopMagic()
    {
        fireBallParticle.Stop();
        lightParticle.Stop();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
