using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    private Asteroid thisAsteroid;

    private void Start()
    {
        thisAsteroid = GetComponent<Asteroid>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConstant.BulletTag))
        {
            EventManager.OnAsteroidDestroy?.Invoke();
            DestroyAsteroid();
            other.gameObject.SetActive(false);
        }
    }

    public void DestroyAsteroid()
    {
        AsteroidPool.ReturnObject(thisAsteroid);
    }
}
