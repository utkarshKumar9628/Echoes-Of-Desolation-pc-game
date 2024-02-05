using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextEnable : MonoBehaviour
{
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    public void EnableText()
    {
        if (text != null) 
        {

            text.gameObject.SetActive(true);
        
        }
    }
}
