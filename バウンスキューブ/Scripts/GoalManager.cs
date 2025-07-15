using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GoalManager : MonoBehaviour
{
    [SerializeField] private Text clearTextPrefab;
    [SerializeField] private Canvas canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text clearText = Instantiate(clearTextPrefab, canvas.transform);
        }
    }
}
