using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectsNotifier : MonoBehaviour
{
    public delegate void message();
    public event message NotifyA;
    public event message NotifyB;

    void Start() {}

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            NotifyA();
            NotifyB();
        }
    }
}
