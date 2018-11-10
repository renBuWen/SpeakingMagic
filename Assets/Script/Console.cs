using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {
    [HideInInspector]
    public bool usingConsole = false;

    public InputField inputField;
    public PlayerController playerController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            usingConsole = !usingConsole;
            playerController.SetControllalbe(!usingConsole);
        }

        inputField.gameObject.SetActive(usingConsole);

        if (usingConsole)
        {
            inputField.ActivateInputField();
        }
    }
}
