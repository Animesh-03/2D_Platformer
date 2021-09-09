using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareShooter : MonoBehaviour
{
    public Transform flare;
    private Vector3 mousePos;
    private Vector3 direction;
    private Camera camera;
    private float zRot;
    private AudioSource audioSource;
    void Start()
    {
        camera = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        direction = (mousePos - transform.position);
        zRot = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(flare,transform.position,Quaternion.Euler(0,0,zRot));
        }
    }

    void GetMousePos()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 2;
    }

    public void PlayDestroyAudio()
    {
        audioSource.Play();
    }
}
