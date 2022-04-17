using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour
{
    public float topScore;
    public Text topScoreText, topNameText;

    public void Update()
    {
        topScoreText.text = "Survived for: " + topScore.ToString("0.0") + "sec";
    }
}
