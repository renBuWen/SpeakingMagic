using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballParticleEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnParticleTrigger(GameObject go)
    {
        if(go.tag == "Biology")
        {
            go.GetComponent<Monster>().ReceiveDamaged(5);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
