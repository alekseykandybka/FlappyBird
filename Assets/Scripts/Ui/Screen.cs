using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected GameObject _window;
    [SerializeField] protected Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public void Open()
    {
        _window.SetActive(true);
    }
    
    public void Close()
    {
        _window.SetActive(false);
    }
    
}
