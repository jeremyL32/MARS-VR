using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCount : MonoBehaviour
{
    
    public int count = 0;
    public TextMeshProUGUI textField;

    private void OnTriggerEnter(Collider other)
    {
        MeshCollider temp = other as MeshCollider;
        if(temp != null) // is a mesh collider
        {
            if (other.tag == "Gem")
            {
                count += 1;
                other.tag = "Counted";
            }
            
        }

        textField.text = "Count: " + count.ToString();
        Debug.Log(count);
     
        }

    private void Update()
    {
        if (count == 5)
        {
            GUI.Label(new Rect(3,3,7, 50), "Gun");
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect (5, 5, 10, 100), "Points: " + count );
    }
    
}
