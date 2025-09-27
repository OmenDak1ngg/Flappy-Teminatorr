using UnityEngine;

public class ButtomRemoveZone : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;

    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    private void HandleCollision(Iinteractable interactable)
    {
        if(interactable is Enemy)
        {
            _scoreCounter.Increase();
        }
    }
}
