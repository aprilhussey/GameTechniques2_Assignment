using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Interactable
{
    [SerializeField] private GameObject flame;

    [SerializeField] private string interactTextNotActive;
	[TextArea(1, 3)]
	[SerializeField] private string interactedTextNotActive;

	[SerializeField] private string interactTextActive;
	[TextArea(1, 3)]
	[SerializeField] private string interactedTextActive;

    void Start()
    {
        interactText = interactTextNotActive;
        interactedText = interactedTextNotActive;

        if (flame != null)
        {
            flame.SetActive(false);
        }
	}

	public override void Interact()
    {
        base.Interact();

        if (flame != null)
        {
            if (!flame.activeInHierarchy)
            {
                flame.SetActive(true);
                interactText = interactTextActive;
                interactedText = interactedTextActive;
            }
            else if (flame.activeInHierarchy)
            {
                flame.SetActive(false);
                interactText = interactTextNotActive;
                interactedText = interactedTextNotActive;
            }
        }
    }
}
