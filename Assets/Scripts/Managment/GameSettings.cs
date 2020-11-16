using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="GameSettings", menuName = "Create GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private PlayerSettings Player;
    [SerializeField] private Level[] levels;
   
    public PlayerSettings GetPlayerSettings => Player;
    public Level[] GetAllLevel => levels;
    public Level GetLevel(int index) => levels[index];
    
}

[Serializable]
public class PlayerSettings
{
    public int Health;
    public float Speed;
    public float DelayShot;
}
