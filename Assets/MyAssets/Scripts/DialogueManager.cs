using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance{get; set;}
    public List<string> dialogueLines = new List<string>();

    public GameObject dialoguePanel;

    Button continueButton;
    Text dialogueText;
    int dialogueIndex;

    int goToLevel;
    public bool openingScene;
    public bool finalScene;

    void Awake()
    {

        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        //continueButton.onClick.AddListener(delegate { continueDialogue();  });

        if (!openingScene)
        {
            dialoguePanel.SetActive(false);
        }
        

        

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, int level)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        dialogueLines.AddRange(lines);
        goToLevel = level;
        createDialogue();
    }

    public void createDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        dialoguePanel.SetActive(true);
    }

    public void continueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {

            dialoguePanel.SetActive(false);
            
            if (goToLevel !=0)
            {
                Debug.Log("Go to level " + goToLevel);
                SceneManager.LoadScene(goToLevel);
            }else if (finalScene)
            {
                Debug.Log("Close the GAME!!!!!!!!!");
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            continueDialogue();
        }
    }

}
