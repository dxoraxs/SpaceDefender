using UniRx;
using UnityEngine;

public class BulletPool : PoolObject<MovingObject>
{
    protected override void ProcessingObject(MovingObject movingObject, Vector3 direction)
    {
        movingObject.InitObject(direction);

        Observable.Timer(System.TimeSpan.FromSeconds(5))
        .Subscribe(_ =>
        {
            ReturnObject(movingObject);
        });
    }
}
