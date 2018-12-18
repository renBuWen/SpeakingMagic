using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1_AI : NPC {
    // Use this for initialization
    string speakingContent;
    string[] choiceContents = new string[3];

    void Start() {
        NPCname = "Freedom Adventurer：";
    }

    void Dialog1()
    {
        speakingContent = "Hey you! I got some banana for brave warriors.And it seems you are one of them.";
        choiceContents[0] = "as you wish";
        choiceContents[1] = "go fuck yourself";
        choiceContents[2] = "good bye";
    }

    void Dialog2()
    {
        speakingContent = "Come on!Get your ass up.";
        choiceContents[0] = "alright";
        choiceContents[1] = "good bye";
        choiceContents[2] = "......";
    }
    void Dialog3()
    {
        speakingContent = "you should regret what you have done";
        choiceContents[0] = "I'm just kidding";
        choiceContents[1] = "good bye";
        choiceContents[2] = "......";
    }

    public override bool HandleVoiceInput(string voice)
    {
        //还没开始对话
        if (speaking == false)
        {
            //通过hellow启动对话
            if (voice == "hello")
            {
                Dialog1();
                speaking = true;
                return true;
            }
            return false;
        }
        //正在对话中
        else
        {
            //离开对话
            if (voice == "good bye")
            {
                speaking = false;
                return true;
            }
            //对话选项
            else if (voice == "as you wish")
            {
                Dialog2();
                return true;
            }
            else if (voice == "go fuck yourself")
            {
                Dialog3();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public override void UpdateDialogBox(DialogBox dialogBox){
        if (!speaking)
        {
            dialogBox.HideDialogBox();
            return;
        }

        dialogBox.SetDialogName(NPCname);
        dialogBox.SetDialogContent(speakingContent);
        for (int i = 0; i < 3; ++i) dialogBox.SetButtons(choiceContents[i], i);
        dialogBox.ShowDialogBox();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
