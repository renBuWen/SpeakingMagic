using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    BoardManager boardManager;
    public List<string> contents = new List<string>();
    List<string>[] phasedContents;
	// Use this for initialization
	void Start () {
        boardManager = GameObject.FindGameObjectWithTag("BoardManager").GetComponent<BoardManager>();
    }

    public void PhaseContents()
    {
        phasedContents = new List<string>[contents.Count];
        int index = 0;
        foreach(var sentence in contents)
        {
            phasedContents[index] = new List<string>();

            string[] split = sentence.Split(' ');
            foreach (string s in split)
            {
                if (s.Trim() != "")
                {
                    phasedContents[index].Add(s);
                }
            }
            index++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PhaseContents();
            boardManager.TriggerBoard(phasedContents);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
