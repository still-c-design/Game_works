using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    //[SerializeField] private float minSpeed = 0.1f;
    //[SerializeField] private float maxSpeed = 10.0f;

    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private GameObject clickEffect;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pochi;

    private Vector3 targetPos;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(pochi);
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            Instantiate(clickEffect, targetPos, Quaternion.identity);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
                );
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
