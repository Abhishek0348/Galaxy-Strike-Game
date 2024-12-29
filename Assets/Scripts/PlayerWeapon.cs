using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] Lasers;
    [SerializeField] RectTransform Crosshair;
    [SerializeField] Transform TargetPoint;
    [SerializeField] float TargetPointDist = 100f;
    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimAtCrosshair();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    public void ProcessFiring()
    {
        foreach (GameObject laser in Lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission; // Var = ParticleSystem.EmissionModule
            emmisionModule.enabled = isFiring;
        }
    }

    private void MoveCrosshair()
    {
        Crosshair.position = Input.mousePosition;
    }
    private void MoveTargetPoint()
    {
        Vector3 TargetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, TargetPointDist);
        TargetPoint.position = Camera.main.ScreenToWorldPoint(TargetPointPosition);
    }

    private void AimAtCrosshair()
    {
        foreach (GameObject laser in Lasers)
        {
            Vector3 FireDirection = TargetPoint.position - this.transform.position;
            Quaternion FireRotation = Quaternion.LookRotation(FireDirection);
            laser.transform.rotation = FireRotation;
        }
    }
}
