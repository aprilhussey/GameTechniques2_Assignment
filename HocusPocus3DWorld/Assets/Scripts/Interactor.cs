//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactor : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private GameObject popup;
    private TMP_Text popupText;

    Interactable interactable;

    bool hasInteracted = false;

    float displayTime;
    
    void Start()
    {
        popup = GameObject.Find("InteractablePopup");
        popupText = GameObject.Find("PopupText").GetComponent<TMP_Text>();

        popup.SetActive(false);

        hasInteracted = false;
	}

    void Update()
    {
		ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f));

		if (Physics.Raycast(ray, out hit))
        {
            // Draw ray in scene view
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

            interactable = hit.transform.gameObject.GetComponent<Interactable>();
            
            if (interactable != null)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                {
                    // The ray hit an object on the Interactable layer, do something
                    if (!hasInteracted)
                    {
						popupText.text = interactable.interactText;
					}

                    popup.SetActive(true);
                    Debug.Log("RAYCAST HIT");

					if (Input.GetMouseButtonDown(0))
					{
                        hasInteracted = true;
                        displayTime = interactable.displayTime;

						popupText.text = interactable.interactedText;
						StartCoroutine(ShowInteractedText());
                        interactable.Interact();
					}
				}
            }
			else if (interactable == null && !hasInteracted)
			{
				popup.SetActive(false);
				Debug.Log("RAYCAST NOT HIT");
			}
		}
    }

    IEnumerator<object> ShowInteractedText()
    {
		yield return new WaitForSeconds(displayTime);
        hasInteracted = false;
	}
}
