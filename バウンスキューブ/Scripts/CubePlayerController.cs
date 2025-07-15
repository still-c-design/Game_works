using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerController : MonoBehaviour
{
    public GameObject playerCube;
    public float moveSpeed = 1.0f;
    public float jumpPower = 1.0f;
    public float fallStrength = 1.0f;
    public Vector3 initialLocate;

    public PhysicMaterial physicMaterial;
    public float correctDynamicFriction;
    public float correctstaticFriction;
    public float correctBounciness;

    public AudioSource audioSource;
    public AudioClip boyon;


    private new Rigidbody rigidbody;

    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        correctDynamicFriction = physicMaterial.dynamicFriction;
        correctstaticFriction = physicMaterial.staticFriction;
        correctBounciness = physicMaterial.bounciness;

        physicMaterial.bounciness = correctBounciness;

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-Vector3.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            rigidbody.AddForce(Vector3.up * jumpPower);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(-Vector3.up * fallStrength);
        }

        if (playerCube.transform.position.y <= -20.0f)
        {
            playerCube.transform.position = initialLocate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGround = true;
            audioSource.PlayOneShot(boyon);
        }

        if (collision.gameObject.CompareTag("frozen"))
        {
            isGround = true;
            physicMaterial.dynamicFriction = 0.0f;
            physicMaterial.staticFriction = 0.0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGround = false;
        }

        if (collision.gameObject.CompareTag("frozen"))
        {
            isGround = false;
            physicMaterial.dynamicFriction = correctDynamicFriction;
            physicMaterial.staticFriction = correctstaticFriction;
        }
    }

}
