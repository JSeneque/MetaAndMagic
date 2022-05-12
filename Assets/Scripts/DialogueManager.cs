using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject dialogueBox;
    public GameObject nameBox;

    public string[] dialogueLines;
    public int currentSentence = 0;

    public static DialogueManager instance;

    //private bool started = false;

    void Start()
    {
        instance = this;
    }

    //// Update is called once per frame
    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
    //        //if (Input.GetKeyUp(KeyCode.Space))
            if (Input.GetButtonUp("Fire1"))
            {
    //            if (!started)
    //            {
                    currentSentence++;

                                if (currentSentence >= dialogueLines.Length)
                                {
                                    dialogueBox.SetActive(false);
                //                    PlayerController.instance.canMove = true;
                                }
                else
                {
                //                    CheckIfNameChange();
                dialogueText.text = dialogueLines[currentSentence];
                                }
                //            }
                //            else
                //            {
                //                started = false;
                //            }
            }
        }
    }

    public void ShowDialogue(string[] lines)//, bool isPerson)
    {
        dialogueLines = lines;
        currentSentence = 0;

        //    CheckIfNameChange();

        dialogueText.text = dialogueLines[currentSentence];
        dialogueBox.SetActive(true);

        //    started = true;

        //    nameBox.SetActive(isPerson);

        //    PlayerController.instance.canMove = false;
        //}

        //private void CheckIfNameChange()
        //{
        //    if(dialogueLines[currentSentence].StartsWith("n-"))
        //    {
        //        nameText.text = dialogueLines[currentSentence].Replace("n-", "");
        //        currentSentence++;
        //    }
        }
    }
