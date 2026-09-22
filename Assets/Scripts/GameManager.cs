using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public ScoreKeeper scoreKeeper;
    public FileManager fileManager;
    //

    //
    [SerializeField] GameObject ScoreUIPrefab;
    [SerializeField] GameObject FileManagerPrefab;
    [SerializeField] GameObject ScoreKeeperPrefab;

    private SceneManager sceneManager;
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
        fileManager = MakeFileManager();
        fileManager.transform.SetParent(transform, false);

        scoreWriter = MakeScoreUI();
        scoreWriter.transform.SetParent(transform, false);

        scoreKeeper = MakeScoreKeeper();
        scoreKeeper.transform.SetParent(transform, false);
    }
    
    private ScoreWriter MakeScoreUI()
    {
        GameObject curScoreUI = Instantiate(ScoreUIPrefab);
        return curScoreUI.GetComponent<ScoreWriter>();
    }
    private FileManager MakeFileManager()
    {
        GameObject curFileManager = Instantiate(FileManagerPrefab);
        return curFileManager.GetComponent<FileManager>();
    }

    private ScoreKeeper MakeScoreKeeper()
    {
        GameObject curScoreKeeper = Instantiate(ScoreKeeperPrefab);
        return curScoreKeeper.GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(2); 
    }

}
