using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform player; // le joueur à suivre
    public Vector3 offset;   // position relative à garder (ex: nouvelle Vector3(0,1.6f,0))

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        // Mettre la caméra sur le joueur avec un décalage
        transform.position = player.position + offset;
    }
}
