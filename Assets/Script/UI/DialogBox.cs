using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public delegate void Func();

public class DialogBox : MonoBehaviour {
    public Image image;
    public Text nameText;
    public Text contentText;
    public Text[] buttons = new Text[3];
    public GameObject box;
	// Use this for initialization
	void Start () {
        HideDialogBox();
	}
    public void ShowDialogBox()
    {
        box.SetActive(true);
    }
    public void HideDialogBox()
    {
        box.SetActive(false);
    }

    public void SetDialogName(string name)
    {
        nameText.text = name;
    }
    public void SetDialogContent(string content)
    {
        contentText.text = content;
    }
    public void SetButtons(string content,int index)
    {
        if(index >= 3 || index < 0)
        {
            Debug.Log("Button Index overcross!");
            return;
        }

        buttons[index].text = content;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
