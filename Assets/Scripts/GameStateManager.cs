using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameStates
    { 
        Playing,
        Loading,
        Paused,
    }

    public GameStates _state;

    private void Start()
    {
        _state = GameStates.Playing;
    }

    public bool RequestEnterPaused()
    {
        if (_state == GameStates.Paused || _state == GameStates.Loading) return false;
        _state = GameStates.Paused;
        Debug.Log("State: Paused");
        return true;
    }

    public bool RequestEnterPlay()
    {
        if (_state == GameStates.Playing) return false;
        _state = GameStates.Playing;
        Debug.Log("State: Play");
        return true;
    }

    public bool RequestEnterLoading()
    {
        if (_state == GameStates.Loading || _state == GameStates.Paused) return false;
        _state = GameStates.Loading;
        Debug.Log("State: Loading");
        return true;
    }


}
