using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreWriter : MonoBehaviour
{
    private string scorePretext = "Score: ";
    private string healthPretext = "Health: ";
    private string expPretext = "Exp: ";

    public GameObject scoreTextObj;
    public GameObject healthTextObj;
    public GameObject levelNameObj;
    public GameObject levelExpObj;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI levelName;
    private TextMeshProUGUI expName;

    void Awake()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
        healthText = healthTextObj.GetComponent<TextMeshProUGUI>();
        levelName = levelNameObj.GetComponent<TextMeshProUGUI>();
        expName = levelExpObj.GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        SceneManager.sceneLoaded += (_,_) => UpdateLevelName();
        UpdateLevelName();
    }
    public void UpdateScore(float num)
    {
        scoreText.text = scorePretext + num.ToString();
    }
    public void UpdateHealth(float num)
    {
        healthText.text = healthPretext + num.ToString();
    }
    public void UpdateExpName(float num)
    {
        expName.text = expPretext + num.ToString();
    }
    public void UpdateLevelName()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        levelName.text = SceneManager.GetActiveScene().name;
    }
    
}
