using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text ScoreboardText;
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreboardText.text = score.ToString();
    }
}
