using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int countFruits = 0;
    [SerializeField] private Text fruitCountText;
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.CompareTag("Coin"))
        {
            Destroy(Collision.gameObject);
            countFruits++;
            Debug.Log("Fruits: " + countFruits);
            fruitCountText.text = "Fruits: " + countFruits;
        }
    }
}
