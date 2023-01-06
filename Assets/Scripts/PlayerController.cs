using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed =5.0f;
    private Rigidbody playerRb;
    private GameObject focalPointRef;
    public bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        focalPointRef = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //float mouseInput = Input.GetAxis("Mouse X");
        playerRb.AddForce(focalPointRef.transform.forward * forwardInput * speed * Time.deltaTime);

        //playerRb.AddForce(focalPointRef.transform.right * mouseInput * speed * Time.deltaTime);
    }

    // when working only with box colliders we want to use on trigger enter

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            hasPowerup= true;
        }
    }

    //when working with physics we want to use the on collinsion enter
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemey") && hasPowerup)
        {
            Debug.Log("collided with: "+ collision.gameObject.name);
        }
    }

}
