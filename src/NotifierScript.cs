using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifierScript : MonoBehaviour
{
    public delegate void action();
    public event action OnMyEvent;
    public int counter;

    void Start()
    {
        counter = 0;
    }

    void Update()
    {
        counter++;
        if (counter % 1000 == 0) {
            OnMyEvent();
        }
    }
}
