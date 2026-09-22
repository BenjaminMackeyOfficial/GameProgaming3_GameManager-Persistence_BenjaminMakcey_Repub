using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    public static FileManager Initialize(Transform parent)
    {
        FileManager fileManager = new FileManager();
        fileManager.transform.SetParent(parent);

        return fileManager;
    }

    

    private void Awake()
    {
        
    }
}
