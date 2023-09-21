using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ItemCollector : MonoBehaviour
{
    private int point = 0;
    public TMP_Text pointText;
    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherries"))
        {
            Destroy(collision.gameObject);
            point++;
            updateText();
        }
        if (collision.gameObject.CompareTag("Gems"))
        {
            Destroy(collision.gameObject);
            point += 10;
            updateText();
        }
    }

    private void updateText()
    {
        pointText.text = "Point: " + point.ToString();
    }
}
