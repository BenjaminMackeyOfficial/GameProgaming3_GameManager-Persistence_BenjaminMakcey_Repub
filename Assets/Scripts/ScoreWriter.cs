using UnityEngine;
using UnityEngine.UI;

public class ScoreWriter : MonoBehaviour
{
    public static ScoreWriter Initialize(Transform parent)
    {
        GameObject newCanvas = Instantiate(canvasPrefab);
        newCanvas.transform.SetParent(parent);

        ScoreWriter newScoreWriter = canvasPrefab.transform.GetComponent<ScoreWriter>();

        return newScoreWriter;
    }

    [SerializeField] static GameObject canvasPrefab;

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
