using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] // b
    public int score = 0;

    private TMP_Text uiText; // c
    
    void Start()
    {
        uiText = GetComponent<TMP_Text>(); // d
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0"); // e
    }
}
