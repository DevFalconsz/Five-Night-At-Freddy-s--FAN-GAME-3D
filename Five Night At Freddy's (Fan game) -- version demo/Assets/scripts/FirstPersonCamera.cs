using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public Transform characterBody;
    public Transform characterHead;

    float sensitivityX = 70.0f;
    float sensitivityY = 70.0f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -80;
    float angleYmax = 80;

    float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.85f;
    float smoothCoefy = 0.85f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    public Texture2D mira;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - mira.width / 2, Screen.height / 2 - mira.height / 2, mira.width, mira.height), mira);
    }

    void Update()
    {

        Cursor.visible = false;

        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += smoothRotx * Time.deltaTime;
        rotationY += smoothRoty * Time.deltaTime;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}