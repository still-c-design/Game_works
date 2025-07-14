using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody myRigidbody;

    [SerializeField] private Text gameOverText;

    private bool _gameOverisCall = false;


    // Start is called before the first frame update
    void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        myRigidbody = GetComponent<Rigidbody>();
        if (myRigidbody != null)
        {
            myRigidbody.velocity = new Vector3(speed, speed, 0.0f);
        }
    }

    private void Update()
    {
        if (gameOverText != null && _gameOverisCall)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GameOver");
            _gameOverisCall = true;
        }
    }
}
