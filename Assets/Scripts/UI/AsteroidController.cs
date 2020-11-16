using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private float delaySpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float maxXSpawn;
    private Coroutine spawnAsteroid;


    private void OnEnable()
    {
        if (spawnAsteroid != null) StopCoroutine(spawnAsteroid);
        spawnAsteroid = StartCoroutine(TimerAsteroid());
    }

    private IEnumerator TimerAsteroid()
    {
        yield return new WaitForSeconds(delaySpawn);
        var asteroid = AsteroidPool.GetObject(GetPointAsteroid(), Vector3.down);
        
        StartCoroutine(TimerAsteroid());
    }

    private Vector3 GetPointAsteroid()
    {
        var point = Vector3.right * Random.Range(-maxXSpawn, maxXSpawn) + Vector3.up * spawnPoint.position.y;
        return point;
    }
}
