using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLocationController : MonoBehaviour
{
    public GameObject player;

    public float heightThreshold = 10f; // プレイヤーがこの高さを超えたら追従する
    public float offsetPlayerDistance = 8.0f;

    private float initialYPos; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("not found player Object");
        }

        initialYPos = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float playerYPos = player.transform.position.y;
        if (heightThreshold <= playerYPos && initialYPos <= playerYPos)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = playerYPos - offsetPlayerDistance;
            transform.position = newPosition;
        }

    }
}
