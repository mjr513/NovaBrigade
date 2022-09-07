using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    
    public TextMeshProUGUI healthText = default;
    public HealthScript steve;

    void Start()
    {

    }

    void Update()
    {
        healthText.text = steve.currentHealth.ToString("00");
    }

}
