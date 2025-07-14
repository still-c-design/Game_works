using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxkunButtonController : MonoBehaviour
{
    [Header("動かす対象のObject")]
    [SerializeField] private GameObject target;
    public float moveSpeed = 5f;

    [Space(20)]
    [Header("移動する方向を指定")]
    [SerializeField] private string moveDirection;

    private Rigidbody2D _rb;
    private Vector2 _moveInput;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pochi;


    void Start()
    {
        _rb = target.GetComponent<Rigidbody2D>();
        moveDirection = this.gameObject.name;
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(pochi);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Trigger 発動: " + gameObject.name);
            MoveTarget();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("プレイヤーが範囲を出た！");
            StopTarget();
        }
    }

    private void MoveTarget()
    {
        float moveX = 0f;
        float moveY = 0f;

        switch (moveDirection)
        {
            case "→": moveX = 1f; break;
            case "↑": moveY = 1f; break;
            case "↓": moveY = -1f; break;
            case "←": moveX = -1f; break;
            default:
            Debug.LogError("moveDirection の値が正しく設定されていません: " + moveDirection);
            break;
        }
        _moveInput = new Vector2(moveX, moveY).normalized;
        _rb.velocity = _moveInput * moveSpeed;

    }

    private void StopTarget()
    {
        _moveInput = Vector2.zero;
        _rb.velocity = Vector2.zero;
    }
}
