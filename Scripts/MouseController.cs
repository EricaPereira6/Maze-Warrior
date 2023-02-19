using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    private Transform gameCamera;
    private Transform self;

    private float verticalRotation;
    private readonly float viewRange = 14;

    void Start()
    {
        gameCamera = Camera.main.transform;
        self = transform;

        verticalRotation = 0.0f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!Game.IsGameOver())
        {
            self.Rotate(Vector3.up * Input.GetAxis("Mouse X"));

            verticalRotation -= Input.GetAxis("Mouse Y");
            verticalRotation = Mathf.Clamp(verticalRotation, -viewRange, viewRange);

            Vector3 eulerAngles = gameCamera.eulerAngles;
            eulerAngles.x = verticalRotation;
            gameCamera.eulerAngles = eulerAngles;

            //gameCamera.Rotate(Vector3.right * - Input.GetAxis("Mouse Y"));
        }
        else
        {
            Vector3 eulerAngles = gameCamera.eulerAngles;
            eulerAngles.x = 6;
            gameCamera.eulerAngles = eulerAngles;
        }
    }
}
