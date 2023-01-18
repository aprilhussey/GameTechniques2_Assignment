using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
	public string interactText;
	
	[TextArea(1, 3)]
	public string interactedText;

	public float displayTime = 5f;

	public virtual void Interact()
	{
		// This is meant to be overwritten
		Debug.Log("Interacting with " + gameObject.name);
	}
}