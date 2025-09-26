using UnityEngine;

[RequireComponent(typeof(Health))]
public class AnimationController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Health _health;

    private float _rotationSpeed = 40f;

    private Vector3 _startRotation;

    private void OnEnable()
    {
        _health.Dead += OnDeath;    
    }

    private void OnDisable()
    {
        _health.Dead -= OnDeath;
    }

    private void Awake()
    {
        _startRotation = transform.rotation.eulerAngles;
        _health = GetComponent<Health>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnDeath(Health health)
    {

        if(health.TryGetComponent<ShootingCharacter>(out ShootingCharacter character))
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;

            _rigidbody.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.None;

            _rigidbody.angularVelocity = _rotationSpeed;

            if (character is Terminator)
                GameObject.FindWithTag("InputReader").GetComponent<InputReader>().SetInputEnabled(false);
        }
    }

    public void ResetAllStates()
    {
        if(TryGetComponent<Enemy>(out Enemy enemy))
        {
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        if(TryGetComponent<Terminator>(out Terminator terminator))
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }

        transform.rotation = Quaternion.Euler(_startRotation);

        _rigidbody.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezePositionZ;
    }
}
