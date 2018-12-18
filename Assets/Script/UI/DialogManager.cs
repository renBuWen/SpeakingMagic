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
        RegsiterVoiceEvent();
    }

    //添加语音事件
    private void RegsiterVoiceEvent()
    {
        var voiceInputManager = GameObject.FindGameObjectWithTag("VoiceInputManager").GetComponent<VoiceInputManager>();
        //keywords.Add("hello", () => { dialogManager.HandleInput("hello"); });
        //keywords.Add("good bye", () => { dialogManager.HandleInput("good bye"); });
        //keywords.Add("as you wish", () => { dialogManager.HandleInput("as you wish"); });
        //keywords.Add("go fuck yourself", () => { dialogManager.HandleInput("go fuck yourself"); });
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
