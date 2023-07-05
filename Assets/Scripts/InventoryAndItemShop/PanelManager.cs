using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _closepanel;
    Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    public void Close()
    {
        _panel.SetActive(false);
        _player._playerState = Player.state.Wandering;
        _player._cvcam.enabled = true;
    }
    public void Open()
    {
        _panel.SetActive(true);
    }
    public void OpenAndClose()
    {
        _panel.SetActive(true);
        _closepanel.SetActive(false);
    }
    public void CloseAndOpen()
    {
        _panel.SetActive(false);
        _closepanel.SetActive(true);
    }
}
