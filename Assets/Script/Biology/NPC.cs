using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour {
    protected string NPCname = "default";
    protected bool speaking = false;
    // Use this for initialization
    void Start() {}
    public abstract bool HandleVoiceInput(string voice);
    public abstract void UpdateDialogBox(DialogBox dialogBox);
    // Update is called once per frame
    void Update () {
		
	}
}