using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // display a message when player looks at an interactable object.
    public String promptMessage;
    public bool useEvents;

    public void BaseInteract()
    {
       if(useEvents)
        GetComponent<InteractionEvent>().onInteract.Invoke();
        Interact(); 
    }
    //template function to be overridden.
    protected virtual void Interact()
    {
    
    }
}
