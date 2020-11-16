using UnityEngine;
using UnityEngine.UI;

public class GamePanel : Panel
{
    [SerializeField] private Text count;

    public override void InitializablePanel()
    {
        EventManager.UpdateUILevel += SetText;
    }

    private void SetText(int value)
    {
        count.text = value.ToString();
    }

    private void OnDestroy()
    {
        EventManager.UpdateUILevel -= SetText;
    }
}
