using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    private Transform interactionTransform;
    GameObject player;

    public virtual void Interact()
    {
		// This is meant to be overwritten
		Debug.Log("Interacting with " + gameObject.name);
    }

    void Awake()
    {
        player = GameObject.Find("Player");
    }

	void Update()
	{
		float distance = Vector3.Distance(interactionTransform.position, player.transform.position);
		if (distance <= radius)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Interact();
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
		{
			interactionTransform = transform;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
}
