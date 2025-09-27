using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class EndGameScreen : MonoBehaviour
{
    private void Start()
    {
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
