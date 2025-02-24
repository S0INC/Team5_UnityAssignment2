using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int player1_score = 0;
    public int player2_score = 0;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void addPointP1() {
        player1_score+=1;
        player1ScoreText.SetText(player1_score.ToString());
    }
    public void addPointP2() {
        player2_score+=1;
        player2ScoreText.SetText(player2_score.ToString());
    }
}
