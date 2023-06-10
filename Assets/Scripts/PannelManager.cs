using UnityEngine;

public class PannelManager : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    [SerializeField] GameObject _closepannel;
    public void Close()
    {
        _pannel.SetActive(false);
    }
    public void Open()
    {
        _pannel.SetActive(true);
    }
    public void OpenAndClose()
    {
        _pannel.SetActive(true);
        _closepannel.SetActive(false);
    }
    public void CloseAndOpen()
    {
        _pannel.SetActive(false);
        _closepannel.SetActive(true);
    }
}
