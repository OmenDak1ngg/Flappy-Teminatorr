using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class RemoveZone : MonoBehaviour, Iinteractable
{
    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
