using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Dictionary<Type, Panel> panels = new Dictionary<Type, Panel>();
    private Panel currentPanel;

    private void Start()
    {
        var findPanels = GetComponentsInChildren<Panel>(true);
        foreach (var panel in findPanels)
        {
            var type = panel.GetType();
            panels.Add(type, panel);
        }

        currentPanel = panels[typeof(StartPanel)];
        foreach (var valuePair in panels)
        {
            var panel = valuePair.Value;
            panel.InitializablePanel();
            if (panel != currentPanel)
                panel.Hide();
            else panel.Show();
        }
    }

    public void HideStartPanel() => panels[typeof(StartPanel)].Hide();
    public void HideGamePanel() => panels[typeof(GamePanel)].Hide();
    public void ShowGamePanel() => panels[typeof(GamePanel)].Show();
    public void HideEndPanel() => panels[typeof(EndPanel)].Hide();

    public EndPanel ShowEndPanel()
    {
        var endPanel = panels[typeof(EndPanel)] as EndPanel;
        endPanel.Show();
        return endPanel;
    }
}