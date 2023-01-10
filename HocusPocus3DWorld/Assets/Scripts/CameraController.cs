using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float lookSensitivity;
	private float minX = -90f;
	private float maxX = 90f;

	private float xRotation = 0f;
	private float yRotation = 0f;

	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, minX, maxX);
		transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

		transform.Rotate(Vector3.up * mouseX);

		yRotation += mouseX;
	}
}
