using UnityEngine;
using UnityEngine.UI;

public class ScoreWriter : MonoBehaviour
{
    private string scorePretext = "Score: ";
    private string healthPretext = "Health: ";

    public Text scoreText;
    public Text healthText;


    public void UpdateScore(float num)
    {
        scoreText.text = scorePretext + num.ToString();
    }
    public void UpdateHealth(float num)
    {
        healthText.text = healthPretext + num.ToString();
    }
}
