using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ShootPoint : MonoBehaviour, Iinteractable
{
    public bool IsTaked { get; private set; }

    private void Start()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
        IsTaked = false;
    }

    public void SetIsTaked(bool isTaked)
    {
        IsTaked = isTaked;
    }
}
