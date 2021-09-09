using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SunLaser : MonoBehaviour
{
    public Camera camera;
    public LayerMask groundLayer;
    public Tilemap tileMap;
    public float laserRange;
    public float reloadTime;
    private Vector3 mousePos;
    private LineRenderer lineRenderer;
    private RaycastHit2D hit;
    private RaycastHit2D circleHit;
    private bool reloading;
    private float timeAtReload;
    void Start()
    {
        camera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        reloading = false;
    }


    void Update()
    {
        GetMousePos();
        hit = Physics2D.Raycast(transform.position,(Vector2)(mousePos - transform.position),laserRange,groundLayer);
        circleHit = Physics2D.CircleCast(hit.point,0.2f,Vector3.zero,0f,groundLayer);
        if(Input.GetMouseButton(0) && !reloading && circleHit.collider != null)
        {
            tileMap.SetTile(tileMap.WorldToCell(circleHit.point),null);
            lineRenderer.positionCount = 2;
            reloading = true;
            timeAtReload = Time.time;

        }
        if(reloading)
        {
            lineRenderer.positionCount = 0;
        }
        if(lineRenderer.positionCount > 0)
        {
            DrawLaser();
        }

        if(reloading)
        {
            if(Time.time - timeAtReload >= reloadTime)
            {
                reloading = false;
            }
        }
    }

   void GetMousePos()
   {
       mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
       mousePos.z = 2;
   }
   void DrawLaser()
   {
       if(lineRenderer.positionCount > 0)
       {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,hit.point);
       }
   }
}
