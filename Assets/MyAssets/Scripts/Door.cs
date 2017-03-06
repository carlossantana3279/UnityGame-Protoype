using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    Transform player;
    private float distance = 6;

    public bool goToNextLevel;
    public int level;

    public string[] dialogue;
    

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Interact()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= distance)
        {

            DialogueManager.Instance.AddNewDialogue(dialogue, level);

            Debug.Log("Player is " + dist + " far away from the door");
            //Debug.Log("interact with door!");
        }
        
    }
}
