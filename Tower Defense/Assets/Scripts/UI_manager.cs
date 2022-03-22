using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_manager : MonoBehaviour
{
    public TextMeshProUGUI purse;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoins()
    {
        score += 1000;
        purse.text = "Purse: " + score;
    }
}
