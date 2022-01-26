using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public TextMeshProUGUI countText;


    private float movementX;
    private float movementY;
    public float speed;


    void SetCountText() 
    {
        countText.text = "Power : " + count.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>(); //gets reference to the rigidbody component on Player
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //Storing an X,Y value that has been changed, hence why its a Vector 2

        movementX = movementVector.x; //Storing the x
        movementY = movementVector.y; //Storing the y

    }

    private void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed); //Where the magic really happens, where the force is added to the ball to make it move

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

}
