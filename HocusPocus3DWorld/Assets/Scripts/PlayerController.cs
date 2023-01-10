using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintModifier = 1.5f;
    public float crouchModifier = 0.5f;
    private float moveSpeedModifier;

    public Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedModifier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        moveDirection = camera.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        
        transform.position += moveDirection * moveSpeed * moveSpeedModifier * Time.deltaTime;

		if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeedModifier = sprintModifier;
        }
        else
        {
            moveSpeedModifier = 1f;
        }

        if (Input.GetKey(KeyCode.C))
        {
            moveSpeedModifier = crouchModifier;
        }
    }
}
