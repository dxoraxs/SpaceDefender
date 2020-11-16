using System;
using UnityEngine;

public class MotorObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    private float speedMax;
    private float speed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        speedMax = GameManager.GetSettings.GetPlayerSettings.Speed;
    }

    public void Move(Vector3 direction)
    {
        var inputValue = direction.magnitude == 0;
        speed = Mathf.Clamp(speed + (inputValue ? -2 : 1), 0, speedMax);

        Vector3 stepPosition = direction * speed;

        rigidbody.velocity = stepPosition;
    }
}