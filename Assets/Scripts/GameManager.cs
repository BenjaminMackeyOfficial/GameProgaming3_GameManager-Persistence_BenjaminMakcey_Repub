using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    private static GameManager instance;

    //refs
    public ScoreWriter scoreWriter;
    public FileManager fileManager;
    //
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this);
        }
    }


    private void Start()
    {
        scoreWriter = ScoreWriter.Initialize(transform);
        fileManager = FileManager.Initialize(transform);
    }

}
