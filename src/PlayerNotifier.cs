using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotifier : MonoBehaviour
{
    public delegate void action();
    public event action NotifyA;
    public event action NotifyB;

    void Start() {}

    void Update() {}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "ObjectA") {
            NotifyB();
        }
        if (collision.gameObject.tag == "ObjectB") {
            NotifyA();
        }
    }
}
