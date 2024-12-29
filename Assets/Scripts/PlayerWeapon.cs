using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject Laser;
    bool isFiring = false;

    void Update()
    {
        ProcessFiring();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    public void ProcessFiring()
    {
        var emmisionModule = Laser.GetComponent<ParticleSystem>().emission;  // Var = ParticleSystem.EmissionModule
        emmisionModule.enabled = isFiring;
    }
}
