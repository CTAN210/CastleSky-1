using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        InputRotation();
    }
    void InputRotation()
    {
        if (Input.GetKey(KeyCode.A)) {
            currentRotation += rotationSensitivity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            currentRotation -= rotationSensitivity * Time.deltaTime;
        }
    }
    public float speed = 3.5f;
    public float currentRotation;
    public static float rotationSensitivity = 100f;
    void FixedUpdate() {
        MoveForward();    
        Rotation();
    }
    void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    void Rotation()
    {
        transform.rotation = Quaternion.Euler(
            new Vector3(transform.rotation.x, transform.rotation.y, currentRotation)
        );
    }

}
