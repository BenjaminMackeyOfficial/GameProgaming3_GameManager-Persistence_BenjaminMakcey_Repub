using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ScoreKeeper Initialize(Transform parent)
    {
        ScoreKeeper keeper=  new ScoreKeeper();
        keeper.transform.SetParent(parent);

        return keeper;
    }
}
