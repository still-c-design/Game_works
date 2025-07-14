using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxkunController : MonoBehaviour
{
    [Header("キャラクターの設定")]
    [SerializeField] private float moveSpeed = 5.0f;


    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer を取得
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // 🔼 上に移動（Wキー or ↑キー）
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = 1f;
        }
        // 🔽 下に移動（Sキー or ↓キー）
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        // ◀ 左に移動（Aキー or ←キー）
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
            _spriteRenderer.flipX = true;  // 左向きに反転
        }
        // ▶ 右に移動（Dキー or →キー）
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = 1f;
            _spriteRenderer.flipX = false;
        }

        _moveInput = new Vector2(moveX, moveY).normalized; // 斜め移動時に速度を一定にする
    }

    void FixedUpdate()
    {
        _rb.velocity = _moveInput * moveSpeed; // Rigidbody2D を使って移動
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("→"))
        {

        }
        else if (other.CompareTag("↑"))
        {

        }
        else if (other.CompareTag("↓"))
        {

        }
        else if (other.CompareTag("←"))
        {

        }


    }
}
