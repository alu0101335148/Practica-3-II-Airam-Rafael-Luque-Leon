using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriberScript : MonoBehaviour
{
    public NotifierScript notifier;
    
    // Start is called before the first frame update
    void Start()
    {
        notifier.OnMyEvent += myResponse;
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
    
    void myResponse(){
        Debug.Log("Soy el cubo morado y he cambiado al cubo amarillo de color");
        Debug.Log(notifier.counter);
        // Change the color of the notifier to a random color
        notifier.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }

}
