using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie2 : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                myDoor.Play("door_open", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                myDoor.Play("Door-close", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
