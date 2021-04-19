using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    CharacterController playerController;
    public Transform body; 
    public float sensitivity;
    float rotX = 0f;
    float deg = 9f;
    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float xRot = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float yRot = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        rotX -= yRot;
        rotX = Mathf.Clamp(rotX,-10f,deg);
        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
        body.Rotate(Vector3.up * xRot);

        if(Input.GetMouseButtonDown(1))
        {
            gameObject.transform.localPosition = new Vector3(0.14f, 2.67f, 0.01f);
            deg = 25f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            gameObject.transform.localPosition = new Vector3(0.14f, 3.07f, -3.39f);
            deg = 9f;
        }

        if(gameObject.GetComponentInParent<player>().health < 1)
        {
            gameObject.transform.localPosition = new Vector3(0.14f, 3.07f, -10f);
            //transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
        }
    }
}
