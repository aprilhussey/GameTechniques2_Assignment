using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillyButchersonGrave : Interactable
{
	[SerializeField] private GameObject severedHand;

	void Start()
    {
        if (severedHand != null)
        {
            severedHand.SetActive(false);
        }
    }
    
    public override void Interact()
    {
        base.Interact();

        if (severedHand != null )
        {
            if (!severedHand.activeInHierarchy)
            {
                severedHand.SetActive(true);
                // animator thing
            }
        }
    }
}
