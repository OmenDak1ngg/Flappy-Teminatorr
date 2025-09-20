using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TerminatorMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _boostForce;

    [SerializeField] private InputReader _inputReader;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _inputReader.Boosted += Boost;
    }

    private void OnDisable()
    {
        _inputReader.Boosted -= Boost;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.linearVelocity = new Vector2(_moveSpeed, 0);
    }

    private void Boost()
    {
        _rigidbody.linearVelocity = new Vector2(_moveSpeed, _boostForce);
    }
}
