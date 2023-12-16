using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    private Vector2 velocity;
    public float delayX;
    public float delayY;

    public Transform playerTransform;

    // Update is called once per frame
    void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, playerTransform.transform.position.x, ref velocity.x, delayX);
        float posY = Mathf.SmoothDamp(transform.position.y + 0.2f, playerTransform.transform.position.y, ref velocity.y, delayY);

		transform.position = new Vector3(posX, transform.position.y, transform.position.z);
		//transform.position = new Vector3(posX, posY, transform.position.z);


    }
}
