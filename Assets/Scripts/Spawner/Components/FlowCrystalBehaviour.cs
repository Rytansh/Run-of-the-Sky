using UnityEngine;
using System;

public class FlowCrystalBehaviour : MonoBehaviour
{
    private FlowCrystal crystal;
    public event Action<FlowCrystal> OnCrystalCollected;

    public void Initialise(FlowCrystal crystal)
    {
        this.crystal = crystal;
        OnCrystalCollected = null;
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = this.gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            Debug.Log("Player collected crystal.");
            OnCrystalCollected?.Invoke(crystal);
        }
    }
}
