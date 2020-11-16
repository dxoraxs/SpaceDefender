using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevel : MonoBehaviour
{
    [SerializeField] private GameObject lockImage;
    [SerializeField] private Text textNumber;
    [SerializeField] private Button button;
    private int index;

    public void InitItemLevel(int number, bool open, bool complete, Action<int> onClick)
    {
        if (open)
        {
            if (complete)
                button.image.color = Color.green;
            lockImage.SetActive(false);
            index = number;
            textNumber.text = (index + 1).ToString();
            button.onClick.AsObservable().Subscribe(_ => onClick.Invoke(index));
        }
        else
        {
            textNumber.gameObject.SetActive(false);
        }
    }
}
