using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteraction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            GetInteraction();
        }
	}

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactableObject = interactionInfo.collider.gameObject;
            if (interactableObject.tag == "Interactable Object")
            {
                //Debug.Log("Interactable interacted.");
                interactableObject.GetComponent<Interactable>().Interact();
                
            }else
            {
                //Debug.Log("Else Ray cast.... ");
            }
        }

    }
}
