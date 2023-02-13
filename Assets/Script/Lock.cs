using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lock : MonoBehaviour, IInteraction
{
    [SerializeField] Inventory inventory;
    private bool locked;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
    }

    public void Activate()
    {
        if (inventory.key1 == true && locked == true)
        {
            Debug.Log("Unlocked");
        locked = false
        }
        else if (inventory.key1 == true && locked == false)
        {
            Debug.Log("Door is already open");
        }
        else
        {
            Debug.Log("You need a key");
        }
    }


  
    // Update is called once per frame
    void Update()
    {
        
    }
}
