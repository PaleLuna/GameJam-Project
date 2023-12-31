using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BootPoint : MonoBehaviour
{
    private const int NEXT_SCENE = 1;

    private IEnumerator Start()
    {
        GameObject _dontDestroyObject = new GameObject("DontDestroy");
        DontDestroyOnLoad(_dontDestroyObject);

        yield return null;

        ServiceLocator serviceLocator = _dontDestroyObject.AddComponent<ServiceLocator>();

        GameController gameController = _dontDestroyObject.AddComponent<GameController>();

        yield return new WaitForEndOfFrame();
        
        serviceLocator.Registarion<GameController>(gameController);

        SetupGameController();
        
        gameController.stateHolder.ChangeState<PlayState>();
        Debug.Log(gameController.stateHolder.currentState);

        SceneManager.LoadScene(NEXT_SCENE);
    }

    private void SetupGameController()
    {
        GameController gameController = ServiceLocator.Instance.Get<GameController>();

        gameController.stateHolder
            .Registarion(new StartState(gameController));
        gameController.stateHolder
            .Registarion(new PlayState(gameController));
        gameController.stateHolder
            .Registarion(new PauseState(gameController));
    }
}