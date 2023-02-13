using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //few variables: mouse sensitivity
    [SerializeField] private float sens;
    //vertical clamp 90 degrees
    [SerializeField] private float clamp;
    //reference to the camera
    [SerializeField] private GameObject cam;
    //reference to the player object.
    [SerializeField] private GameObject player;

    //flaot for the y rotation
    private float rotY;
    //float for the x rotation
    private float rotX;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //asign the x and y rotation of the camera to a vector 3
        Vector3 rot = transform.localRotation.eulerAngles;

        // set rotx and roty to be equal to the camera rotation.
        rotX = rot.x;
        rotY = rot.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Interact();
        }
        // get the mouse x and y movement and assign to float.
        float mouseX = Input.GetAxis("Mouse X"); 
        float mouseY = Input.GetAxis("Mouse Y");

        //modify rotX and Y by the mouse x and y multipleid by the sensitivity and time.deltatime
        rotX += mouseX * sens * Time.deltaTime;
        rotY += mouseY * sens * Time.deltaTime;

        // apply clamping on the x axis
        rotY = Mathf.Clamp(rotY, -clamp, clamp);

        //create a local quaternion with rotx and y values
        Quaternion localRot = Quaternion.Euler(-rotY, rotX, 0f);
        Quaternion bodyRot = Quaternion.Euler(0f, rotX, 0f);
        //update the transform
        transform.rotation = localRot;
        player.transform.rotation = bodyRot;
    }
    private void Interact ()
        
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            if(hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter))
            Debug.Log("THERE IS A" + hit.collider.name);
        }
        //if the collider has a door component, open the door
        //if the collider has a key component, add key to inventory
        //if the collider has a lock component, check for key in inventory then unlock
    }
}

public interface IInteraction
{
    public void Activate();

}