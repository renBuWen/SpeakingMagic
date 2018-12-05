using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    public NPC npc1;
    public DialogBox dialogBox;
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void HandleInput(string str)
    {
        if ((npc1.transform.position - player.transform.position).sqrMagnitude <= 60.0f * 60.0f)
        {
            if (npc1.HandleVoiceInput(str) == true)
                npc1.UpdateDialogBox(dialogBox);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
