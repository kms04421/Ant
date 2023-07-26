using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
   
    private float xRotation = 0f;

    void Start()
    {
    
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ���� ����� �߾ӿ� ����
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            gameObject.SetActive(false);
          
        }
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -130f, 130f); // ī�޶� �������� 90�� �̻� ȸ������ �ʵ��� ����

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
