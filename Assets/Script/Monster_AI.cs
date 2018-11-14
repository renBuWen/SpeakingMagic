using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AI : MonoBehaviour {
    public float perceptionDistance = 10.0f;
    private bool changeable = true;
    private Vector3 direction;
    private GameObject player;
    private Rigidbody body;
    private Monster monster;
    private Animation animation;

    // Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        monster = GetComponent<Monster>();
        animation = GetComponent<Animation>();
    }

    bool PerceptPlayer(Vector3 relativePos)
    {
        return relativePos.sqrMagnitude < perceptionDistance* perceptionDistance;
    }

    bool nearByPlayer(Vector3 relativePos)
    {
        return relativePos.sqrMagnitude < monster.attackDistance * monster.attackDistance;
    }

    // Update is called once per frame
    void Update () {
        var r = transform.rotation;
        r.SetLookRotation(direction);
        transform.rotation = Quaternion.Lerp(r,transform.rotation,0.9f);
    }

    void ChangeDirection()
    {
        changeable = true;
    }

    private void FixedUpdate()
    {
        Vector3 relativePos = player.transform.position - transform.position;

        if (nearByPlayer(relativePos))
        {
            animation.Play("mummy_bite");
        }
        else
        { 
            if(!animation.isPlaying)
            animation.Play("mummy_walk");

            if (PerceptPlayer(relativePos))
            {
                direction = relativePos.normalized;
            }
            else
            {
                if (changeable)
                {
                    direction = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized;
                    changeable = false;
                    Invoke("ChangeDirection", 3.5f);
                }
            }

            body.velocity = new Vector3(direction.x * monster.speed, body.velocity.y, direction.z * monster.speed);
        }

    }
}
