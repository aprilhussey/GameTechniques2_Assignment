using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardGate : Interactable
{
	[SerializeField] private GameObject graveyardGate;
	[SerializeField] private Animator animator;

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

		if (graveyardGate != null)
		{
			graveyardGate.SetActive(true);
		}
	}

	public override void Interact()
	{
		base.Interact();

		if (graveyardGate != null)
		{
			if (!animator.GetBool("open"))
			{
				// Open gate
				animator.SetBool("open", true);
				interactText = interactTextActive;
				interactedText = interactedTextActive;
			}
			else if (animator.GetBool("open"))
			{
				// Close gate
				animator.SetBool("open", false);
				interactText = interactTextNotActive;
				interactedText = interactedTextNotActive;
			}
		}
	}
}