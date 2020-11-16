using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private MotorObject motor;

    private void Awake()
    {
        motor = GetComponent<MotorObject>();
    }
    
    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontalAxis, verticalAxis);
        motor.Move(direction.normalized);
    }
}