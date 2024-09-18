using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        // Your code here: Update the scoreText with the current score
        // Hint: use scoreText.text to access the string component of
        // Hint: Use gm.GetScore();

        scoreText.text = (gm.GetScore.()).toString;

    }
}