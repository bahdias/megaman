using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target; // O transform do jogador que a câmera deve seguir.
    public float smoothSpeed = 0.125f; // A velocidade de suavização do movimento da câmera.

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
