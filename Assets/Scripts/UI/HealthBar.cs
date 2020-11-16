using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Text healthPlayer;

    private void Start()
    {
        GameManager.GetShip.SubscribeChangesHealth(UpdateBar);
    }

    private void UpdateBar(int count)
    {
        healthPlayer.text = count.ToString();
    }
}