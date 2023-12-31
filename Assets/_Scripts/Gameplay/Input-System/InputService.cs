
public class InputService : IUpdatable
{
    private IInputHandler _inputHandler;

    public InputService(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;

        GameController gameController = ServiceLocator.Instance.Get<GameController>();
        
        gameController.updatablesHolder.Registration(this);
    }

    public void EveryFrameRun()
    {
        SendDirection();
        SendInteract();
    }

    private void SendDirection() => 
        GameplayInputEventBus.OnGetDirection(_inputHandler.GetDirection());

    private void SendInteract()
    {
        if(_inputHandler.Interact())
            GameplayInputEventBus.OnInteract();
    }
        
}
