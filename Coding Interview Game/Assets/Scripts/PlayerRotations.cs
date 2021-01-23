using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotations : MonoBehaviour
{
    Transform cameraTransform;
    public static PlayerRotations Instance { get; private set; }

    public Quaternion RoundedRotation { get; private set; } = new Quaternion();
    public Quaternion CameraRotationAlongY { get; private set; } = new Quaternion();
    public Quaternion PlayerRotationAlongY { get; private set; } = new Quaternion();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        float cameraRotationY = cameraTransform.rotation.eulerAngles.y;
        CameraRotationAlongY = Quaternion.Euler(0, cameraRotationY, 0);

        float playerRotationY = this.transform.rotation.eulerAngles.y;
        Quaternion playerRotationAlongY = Quaternion.Euler(0, playerRotationY, 0);

        RoundedRotation = Quaternion.Euler(0, Mathf.Round(cameraRotationY / 90) * 90, 0) * Quaternion.Euler(0, ((playerRotationY + 45) % 90) - 45, 0);
    }
    
}
