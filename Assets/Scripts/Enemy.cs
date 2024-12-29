using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DestroyedShipVFX;
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(DestroyedShipVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
