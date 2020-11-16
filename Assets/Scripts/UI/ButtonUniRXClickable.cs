using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonUniRXClickable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnClickBackButton;
    [SerializeField] private Button buttonBack;
    
    private void Start()
    {
        buttonBack.onClick.AsObservable().Subscribe(_ => OnClickBackButton.Invoke());
    }
}