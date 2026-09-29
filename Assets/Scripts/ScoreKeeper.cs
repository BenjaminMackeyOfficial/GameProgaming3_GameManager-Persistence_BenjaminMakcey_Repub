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
    public float exp;

    void Start()
    {
        PlayerData dat=GameManager.Instance.fileManager.load();
        score = dat.score;
        health = dat.health;
        exp = dat.exp;
        Debug.Log(dat.exp);
        GameManager.Instance.scoreWriter.UpdateScore(score);
        GameManager.Instance.scoreWriter.UpdateHealth(health);
        GameManager.Instance.scoreWriter.UpdateExpName(exp);
    }
    private void OnDestroy()
    {
        PlayerData dat = new PlayerData(score, health, exp);
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

    public void ChangeExp(int ammount)
    {
        exp += ammount;
        GameManager.Instance.scoreWriter.UpdateExpName(exp);
    }

    //input stuff (this is where real score tracking would go)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) ChangeScore(1);
        if (Input.GetKeyDown(KeyCode.A)) ChangeScore(-1);

        if (Input.GetKeyDown(KeyCode.E)) ChangeHealth(1);
        if (Input.GetKeyDown(KeyCode.D)) ChangeHealth(-1);

        if (Input.GetKeyDown(KeyCode.E)) ChangeHealth(1);
        if (Input.GetKeyDown(KeyCode.D)) ChangeHealth(-1);

        if (Input.GetKeyDown(KeyCode.R)) ChangeExp(1);
        if (Input.GetKeyDown(KeyCode.F)) ChangeExp(-1);
    }


    //

}
