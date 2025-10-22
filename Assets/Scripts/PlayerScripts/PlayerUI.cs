using UnityEngine;
using TMPro;
using System;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
   public void UpdateText(String promptMessage)
    {
        promptText.text = promptMessage;
    }
}
