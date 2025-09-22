using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class EndGameScreen : MonoBehaviour
{
    private Canvas _canvas;
    
    private void Start()
    {
        _canvas = GetComponent<Canvas>();

        gameObject.SetActive(false);
    }

    public void ShowEndGameScreen()
    {
        gameObject.SetActive(true);
    }

    public void HideEndGameScreen()
    {
        gameObject.SetActive(false);
    }
}
