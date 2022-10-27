using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AObjectsSubscriber : MonoBehaviour
{
    public PlayerNotifier notifier;
    public CObjectsNotifier notifierC;
    
    void Start()
    {
        notifier.NotifyA += GetCloseToC;
        notifierC.NotifyA += ChangeColor;
        notifierC.NotifyA += Jump;
    }

    void Update() {}

    void GetCloseToC() {
        Vector3 vectorAC = GameObject.FindWithTag("ObjectC").transform.position - transform.position;
        GetComponent<Rigidbody>().AddForce(vectorAC.normalized * 5.0f, ForceMode.Impulse);
    }

    void ChangeColor() {
        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

    void Jump() {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
    }
}
