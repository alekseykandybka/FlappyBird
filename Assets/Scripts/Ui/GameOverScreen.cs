using UnityEngine.Events;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClecked;
    protected override void OnButtonClick()
    {
        RestartButtonClecked?.Invoke();
    }
}
