using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject nameBox;
    public Text dialogueText;
    public Text nameText;
    public string[] dialogue;
    public bool isPerson = true;

    private int currentLine;
    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && playerInRange)
        {
            if(dialogueBox.activeInHierarchy && currentLine >= dialogue.Length)
            {
                dialogueBox.SetActive(false);
                currentLine = 0;
            }
            else
            {
                dialogueBox.SetActive(true);

                if (!isPerson)
                    nameBox.SetActive(false);
                else
                    nameBox.SetActive(true);

                CheckIfNameChange();
                dialogueText.text = dialogue[currentLine];
                currentLine++;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
            currentLine = 0;
        }
    }

    private void CheckIfNameChange()
    {
        if (dialogue[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogue[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}
