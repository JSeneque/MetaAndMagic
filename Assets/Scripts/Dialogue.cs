using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string[] dialogue;
    public bool isPerson = true;

    private GameObject _dialogueSystem;
    private GameObject dialogueBox;
    private GameObject nameBox;
    private Text dialogueText;
    private Text nameText;

    private int currentLine;
    [SerializeField] bool playerInRange;
    // Start is called before the first frame update

    void Start()
    {
        _dialogueSystem = GameObject.Find("DialogueSystem");
        if (_dialogueSystem == null)
        {
            Debug.LogError("Dialogue System can not be found!");
        }
        else
        {
            dialogueBox = _dialogueSystem.transform.Find("DialogueBox").gameObject;
            nameBox = dialogueBox.transform.Find("NameBox").gameObject;
            dialogueText = dialogueBox.transform.Find("DialogueText").gameObject.GetComponent<Text>();
            nameText = nameBox.transform.Find("NameText").gameObject.GetComponent<Text>();
        }
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
