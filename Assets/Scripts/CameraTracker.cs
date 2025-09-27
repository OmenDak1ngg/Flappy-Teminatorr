using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Terminator _terminator;
    [SerializeField] private float _offsetX;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _terminator.transform.position.x + _offsetX;

        transform.position = position;
    }
}
