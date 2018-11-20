using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public float attackDistance = 2.0f;
    public float speed = 1.0f;
    public float health = 100.0f;
    // Use this for initialization
    void Start() {

    }

    public void ReceiveDamaged(int damage){
        health -= damage;
        if (health <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        GetComponent<Monster_AI>().enabled = false;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
