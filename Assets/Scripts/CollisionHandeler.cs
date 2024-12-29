using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] GameObject DestroyedShipVFX;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(DestroyedShipVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
