using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sens = 2f;

    private float curX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        curX -= mouseY * sens;
        curX = Mathf.Clamp(curX, -80f, 80f);

        transform.rotation = Quaternion.Euler(curX, transform.eulerAngles.y + mouseX * sens, 0f);
        Vector3 direction = new Vector3(0f, 0f, -distance);
        Quaternion rotation = Quaternion.Euler(curX, transform.eulerAngles.y, 0f);
        transform.position = target.position + rotation * direction;
        target.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
