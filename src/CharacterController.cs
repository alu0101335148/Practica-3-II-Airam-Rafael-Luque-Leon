using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        // Use the keys awsd to move the player (transform.Translate(X, Y, Z))
        float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(xMovement, 0, zMovement);

        // Rotate the player around the y-axis using the keys q and e
        if (Input.GetKey(KeyCode.Q)) { transform.Rotate(0, -speed / 50, 0); }
        if (Input.GetKey(KeyCode.E)) { transform.Rotate(0,  speed / 50, 0); }
    }
}
