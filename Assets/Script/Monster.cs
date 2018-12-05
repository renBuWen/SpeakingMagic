using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public float attackDistance = 2.0f;
    public float speed = 1.0f;
    public float health = 100.0f;
    public bool isDead = false;
    private new Animation animation;
    // Use this for initialization
    void Start() {
        animation = GetComponent<Animation>();
    }

    public void ReceiveDamaged(int damage){
        health -= damage;
        if (!isDead && health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
        animation.Stop();
        animation.PlayQueued("mummy_die");
        GetComponent<Monster_AI>().enabled = false;
        this.enabled = false;
       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
