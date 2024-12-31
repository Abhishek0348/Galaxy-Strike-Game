using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] GameObject DestroyedShipVFX;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(DestroyedShipVFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
