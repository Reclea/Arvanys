using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       
    public Vector3 offset = new Vector3(0, 3, -6);
    public float smoothSpeed = 0.1f;    
    public float rotationSpeed = 5f;  
    public float minYAngle = -30f;     
    public float maxYAngle = 60f;        // Limite rotation verticale haut
    private float currentYaw = 0f;
    private float currentPitch = 20f;

    void LateUpdate()
    {
        // Lire la souris
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        currentYaw += mouseX;
        currentPitch -= mouseY;
        currentPitch = Mathf.Clamp(currentPitch, minYAngle, maxYAngle);

        // Rotation horizontale pour position caméra
        Quaternion yawRotation = Quaternion.Euler(0, currentYaw, 0);
        Vector3 desiredPosition = player.position + yawRotation * offset;

        // Lissage position caméra
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Regarder le joueur avec pitch vertical
        Vector3 lookTarget = player.position + Vector3.up * 1.5f;
        transform.LookAt(lookTarget);
    }
}
