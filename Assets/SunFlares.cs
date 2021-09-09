using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using EZCameraShake;

public class SunFlares : MonoBehaviour
{
    public Tilemap tileMap;
    public Transform hitDetector;
    public LayerMask groundLayer;
    public float speed;
    public AudioClip FlareDestroy;
    private Rigidbody2D rb;
    private RaycastHit2D hit;
    private FlareShooter flareShooter;
    public GameObject destroyParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tileMap = FindObjectOfType<Tilemap>();
        flareShooter = FindObjectOfType<FlareShooter>();
        StartCoroutine(delay());
        rb.velocity = (transform.right*speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hit = Physics2D.CircleCast(hitDetector.position,0.1f,Vector3.zero,0f,groundLayer);

        if(hit.collider != null)
        {
            tileMap.SetTile(tileMap.WorldToCell(hit.point),null);
            CameraShaker.Instance.ShakeOnce(5f,2f,0.1f,0.8f);
            flareShooter.PlayDestroyAudio();
            Instantiate(destroyParticles,hitDetector.position,Quaternion.identity);
            Destroy(gameObject);
            
        }
    }

    IEnumerator delay() { yield return new WaitForSeconds(5); Destroy(gameObject); } 
}
