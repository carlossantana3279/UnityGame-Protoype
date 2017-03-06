using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour {

    Transform player;

    //private bool hasInteracted = false;

    private float distance = 5;

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }

    public virtual void MoveToInteraction()
    {
        
        //Debug.Log("Move to Interaction");
    } 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if (player != null)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= distance)
            {
                Debug.Log("Player is " + dist + " far away from the door");
                Interact();
            }else
            {
                
            }
            
        }
        */
	}
}
