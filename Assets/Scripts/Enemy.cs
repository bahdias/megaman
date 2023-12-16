using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2.0f;

    private void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * moveSpeed, 1.0f);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, pingPong);
    }
}
