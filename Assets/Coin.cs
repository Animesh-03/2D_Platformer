using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public AudioClip coinPickup;
    private CoinUI coinUI;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        coinUI = FindObjectOfType<CoinUI>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerMovement.audioSource.PlayOneShot(coinPickup);
            Destroy(gameObject);
            coinUI.coins++;
        }
    }
}
