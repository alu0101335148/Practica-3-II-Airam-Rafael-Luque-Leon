using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BObjectsSubscriber : MonoBehaviour
{
    public PlayerNotifier notifier;
    public CObjectsNotifier notifierC;

    void Start()
    {
        notifier.NotifyB += Grow;
        notifierC.NotifyB += Orientate;
    }

    void Update() {}

    void Grow() {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    void Orientate() {
        Transform targetPosition = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();

        Vector3 vectorATarget = targetPosition.position - transform.position;
        Debug.DrawRay(
            transform.position, 
            vectorATarget,
            Color.red,
            60
        );

        // Using lookAt
        //transform.LookAt(targetPosition, Vector3.up);

        // Using RotateTowards
        // Vector3 newDirection = Vector3.RotateTowards(
        //     transform.forward, 
        //     vectorATarget, 
        //     2.0f,
        //     0.0f
        // );
        // transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
