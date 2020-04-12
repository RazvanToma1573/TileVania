using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsToAddForCoinPickup = 100;
    BoxCollider2D coinCollider;

    private void Start()
    {
        this.coinCollider = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (coinCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            FindObjectOfType<GameSession>().addCoin(pointsToAddForCoinPickup);
            AudioSource.PlayClipAtPoint(this.coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
