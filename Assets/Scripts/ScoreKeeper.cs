using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ScoreKeeper Initialize(Transform parent)
    {
        ScoreKeeper keeper=  new ScoreKeeper();
        keeper.transform.SetParent(parent);

        return keeper;
    }

    public float score;
    public float health;

    void Start()
    {
        PlayerData dat=GameManager.Instance.fileManager.load();
        score = dat.score;
        health = dat.health;
    }
    private void OnDestroy()
    {
        PlayerData dat = new PlayerData(score, health);
        GameManager.Instance.fileManager.save(dat);
    }

    public void ChangeScore(int ammount)
    {
        score += ammount;
        GameManager.Instance.scoreWriter.UpdateScore(score);
    }
    public void ChangeHealth(int ammount)
    {
        health += ammount;
        GameManager.Instance.scoreWriter.UpdateHealth(health);
    }

    //input stuff (this is where real score tracking would go)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) score += 1;
        if (Input.GetKeyDown(KeyCode.A)) score -= 1;

        if (Input.GetKeyDown(KeyCode.E)) health += 1;
        if (Input.GetKeyDown(KeyCode.D)) health -= 1;
    }


    //

}
