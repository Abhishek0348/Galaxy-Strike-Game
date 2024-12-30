using Unity.VisualScripting;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DestroyedShipVFX;
    [SerializeField] int HitPoints = 4;
    [SerializeField] int EnemyValue = 10;
    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
    }

    private void ProcessHits()
    {
        HitPoints--;
        if (HitPoints <= 0)
        {
            Instantiate(DestroyedShipVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            scoreboard.UpdateScore(EnemyValue);
        }
    }
}
