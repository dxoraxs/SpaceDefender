using System;
using UniRx;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private SomeModel<int> health;

    public void SubscribeChangesHealth(Action<int> action)
    {
        health.count
            .ObserveEveryValueChanged (x => x.Value)
            .Subscribe (action.Invoke).AddTo (this);
    }

    private void Awake()
    {
        health = new SomeModel<int>(0);
        StartHealth();
        
        health.count
            .ObserveEveryValueChanged (x => x.Value).Where(x => x <= 0)
            .Subscribe (xs => {
                Death();
            }).AddTo (this);
    }

    public void StartHealth() => health.count.Value = GameManager.GetSettings.GetPlayerSettings.Health;
    private void TakeDamage() => health.count.Value--;

    private void Death()
    {
        gameObject.SetActive(false);
        GameManager.PlayerDied();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AsteroidDestroy asteroid))
        {
            asteroid.DestroyAsteroid();
            TakeDamage();
        }
    }
}
