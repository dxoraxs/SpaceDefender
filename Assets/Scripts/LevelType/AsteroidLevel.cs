using UniRx;
using UnityEngine;

public class AsteroidLevel : LevelConfig
{
    private SomeModel<int> countDestroy;
    
    public AsteroidLevel(Level level, MonoBehaviour behaviour) : base(level)
    {
        EventManager.OnAsteroidDestroy += IncrementCount;
        countDestroy = new SomeModel<int>(0);
        
        countDestroy.count
            .ObserveEveryValueChanged (x => x.Value).Where(x => x == level.CountWin)
            .Subscribe (xs => {
                LevelFinal();
            }).AddTo (behaviour);
        
        countDestroy.count
            .ObserveEveryValueChanged (x => x.Value)
            .Subscribe (xs => {
                EventManager.UpdateUILevel?.Invoke(xs);
            }).AddTo (behaviour);
    }
    
    private void IncrementCount() => countDestroy.count.Value++;

    public override void Update(float stepTime){}

    protected override void LevelFinal()
    {
        base.LevelFinal();
        EventManager.OnAsteroidDestroy -= IncrementCount;
    }
}
