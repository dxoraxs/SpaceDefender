using System.Collections.Generic;
using UnityEngine;

public class SpawnItemLevel : MonoBehaviour
{
    [SerializeField] private ItemLevel prefabItem;

    private void Start()
    {
        var levels = new List<Level>(GameManager.GetSettings.GetAllLevel);
        var openLevel = new List<int>(GameManager.GetOpenLevel);
        var completeLevel = new List<int>(GameManager.GetCompleteLevel);
        for (var index = 0; index < levels.Count; index++)
        {
            var item = Instantiate(prefabItem, transform);
            item.InitItemLevel(index, openLevel.Contains(index), completeLevel.Contains(index), OnClick);
        }
    }

    private void OnClick(int index)
    {
        GameManager.StartGame(index);
    }
}
