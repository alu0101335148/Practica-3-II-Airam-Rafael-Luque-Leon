# Practica-3-II-Airam-Rafael-Luque-Leon

## Descripción

En esta segunda practica vamos a profundizar en los conocimientos que tenemos acerca de los eventos en C# y el patrón Observer.

## Toma de contacto con el patrón Observer

En este punto vamos a tomar los scripts de las diapositivas de la teoría y vamos a instanciar dos objetos, a los que les enlazamos los scripts para ver su funcionamiento

NotifierScript.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifierScript : MonoBehaviour {
    public delegate void action();
    public event action OnMyEvent;
    public int counter;

    void Start() {
        counter = 0;
    }

    void Update() {
        counter++;
        if (counter % 1000 == 0) {
            OnMyEvent();
        }
    }
}
```

SubscriberScript.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriberScript : MonoBehaviour {
    public NotifierScript notifier;
    
    void Start() {
        notifier.OnMyEvent += myResponse;
    }
    
    void Update() { }
    
    void myResponse(){
        Debug.Log("Soy el cubo morado y he cambiado al cubo amarillo de color");
        Debug.Log(notifier.counter);
        // Change the color of the notifier to a random color
        notifier.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}
```

### Demostración

![Demostracion_1](/img/1.gif)

## Creación de un sistema de eventos

Vamos a crear una escena en Unity, con objetos de tipo A, B y un único objeto C con los siguientes comportamientos:

- Cuando el jugador colisiona con un objeto de tipo B, los objetos A se acercan al objeto C. 

- Cuando el jugador toca algún objeto A se incrementa el tamaño de cualquier objeto B

- Cuando el jugador se aproxima al objeto de tipo C: 

  - Los objetos de tipo A cambian su color y saltan.

  - Los objetos de tipo B se orientan hacia un objetivo ubicado en la escena con ese propósito.

Para esta implementación hemos creado dos scripts a modo de notificadores de los eventos, enlazado al jugador y al objeto de tipo C. Por otro lado hemos creado dos scripts a modo de suscriptores, uno para los objetos de tipo A y otro para los objetos de tipo B.

### Notificadores

PlayerNotifier.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotifier : MonoBehaviour {
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
```

CObjectNotifier.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectsNotifier : MonoBehaviour {
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
```

### Suscriptores

AObjectSubscriber.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AObjectsSubscriber : MonoBehaviour {
    public PlayerNotifier notifier;
    public CObjectsNotifier notifierC;
    
    void Start() {
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
```

BObjectSubscriber.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BObjectsSubscriber : MonoBehaviour {
    public PlayerNotifier notifier;
    public CObjectsNotifier notifierC;

    void Start() {
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
        transform.LookAt(targetPosition, Vector3.up);

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
```

### Demostración

![Demostracion_2](/img/2.gif)

## Referencias

- [Unity Manual](https://docs.unity3d.com/Manual/index.html)

- [Unity Scripting API](https://docs.unity3d.com/ScriptReference/index.html)

- [DrawRay](https://docs.unity3d.com/ScriptReference/Debug.DrawRay.html)

- [LookAt](https://docs.unity3d.com/ScriptReference/Transform.LookAt.html)

- [RotateTowards](https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html)
