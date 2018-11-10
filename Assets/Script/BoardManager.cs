using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {
    public Text boardText;
    public GameObject boardUI;
    PlayerController playerController;
    List<string>[] contents;
    bool usingBoard = false;
    int contentIndex = 0;
    int wordIndex = 0;
    float timer = 0.0f;

    // Use this for initialization
    void Start() {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void TriggerBoard(List<string>[] listArray)
    {
        contents = listArray;
        usingBoard = true;
        boardUI.SetActive(true);

        playerController.SetControllalbe(false);

        //StringBuilder val = new StringBuilder(512);
        //for (int i = 0; i < contents.Count; ++i)
        //{
        //    val.Append(contents[i]);
        //    val.Append(' ');
        //}

        //boardText.text = val.ToString();
    }

    public void LeaveBoard(){
        playerController.SetControllalbe(true);
        contentIndex = 0;
        wordIndex = 0;
        usingBoard = false;
        boardUI.SetActive(false);
    }

    private void ResetIndex()
    {
        wordIndex = 0;
        timer = 0.0f;
    }

    public void HandleInput(string str)
    {
        if (usingBoard == false) return;
        if(str == contents[contentIndex][wordIndex] && wordIndex < contents[contentIndex].Count)
        {
            wordIndex++;
            timer = 0.0f;
            Debug.Log("Succes!");
        }
        else
        {
            Debug.Log("Wrong!");
            Debug.Log("RESET!");
            ResetIndex();
        }
    }

    // Update is called once per frame
    void Update () {
        if (!usingBoard) return;

        timer += Time.deltaTime;

        if(timer >= 3.0f)
        {
            if (wordIndex >= contents[contentIndex].Count)
            {
                Debug.Log("Succes One Setence!");
                contentIndex++;
                ResetIndex();
                if (contentIndex >= contents.Length)
                {
                    Debug.Log("Done!");
                    LeaveBoard();
                }
            }
            else
            {

                Debug.Log("RESET!");
                ResetIndex();
            }
        }

	}
}
