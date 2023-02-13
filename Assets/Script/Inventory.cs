using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool key1;
    // Start is called before the first frame update
    void Start()
    {
        key1 = false;

    }

    // Update is called once per frame
    public void PickupKey()
    {
        key1 = true;
    }
}