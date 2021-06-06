using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private static float moveSpeed = 10.0f;
    private static int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
   
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "count : " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }



}
