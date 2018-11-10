using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractMirror : MonoBehaviour {
    float timer = 0.0f;
    public ParticleSystem particle;
    // Use this for initialization
    void Start () {
       
	}
    private void OnParticleTrigger()
    {
        timer = 0.3f;
        particle.Play();
    }
    private void OnParticleCollision()
    {
        timer = 0.3f;
        particle.Play();
    }

    // Update is called once per frame
    void Update () {
		if(timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
          particle.Stop();
        }

	}
}
