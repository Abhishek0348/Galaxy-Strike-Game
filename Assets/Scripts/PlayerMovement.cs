using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float XclampedVal = 5f;
    [SerializeField] float YclampedVal = 3f;

    [SerializeField] float controlRollFactor = -5f;
    [SerializeField] float controlPitchFactor = -18f;
    [SerializeField] float rotationSpeed = 10f;
    private Vector2 Movement;

    void Update()
    {
        PlayerTranslation();
        PlayerRotation();
    }



    public void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    private void PlayerTranslation()
    {
        float xOffset = Movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -XclampedVal, XclampedVal);

        float yOffset = Movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -YclampedVal, YclampedVal);
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void PlayerRotation()
    {
        float roll = controlRollFactor * Movement.x;
        float pitch = controlPitchFactor * Movement.y;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
