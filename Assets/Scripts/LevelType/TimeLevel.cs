using UniRx;
using UnityEngine;

public class TimeLevel : LevelConfig
{
    private SomeModel<float> timeLevel;
    
    public override void Update(float stepTime)
    {
        timeLevel.count.Value -= stepTime;
        EventManager.UpdateUILevel?.Invoke((int)timeLevel.count.Value);
    }

    public TimeLevel(Level level, MonoBehaviour behaviour) : base(level)
    {
        timeLevel = new SomeModel<float>(level.CountWin);
        
        timeLevel.count
            .ObserveEveryValueChanged (x => x.Value).Where(x => x <= 0)
            .Subscribe (xs => {
                LevelFinal();
            }).AddTo (behaviour);
    }
}
