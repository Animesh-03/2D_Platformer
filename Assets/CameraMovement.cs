using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
 {
     public Transform playerObject;
     public float moveSpeed = 1;
 
     public bool keepHeight = true; 
 
     private float buffer = 20;
 
     private Vector3 _pos;   
     private Rect _moveArea; 

     void Start() 
     { 
         _pos = transform.position;

         _moveArea.x = ((Screen.width / 2) - buffer / 2);
         _moveArea.width = buffer;
         _moveArea.y = ((Screen.height / 2) - buffer / 2);
         _moveArea.height = buffer;
     }
 
     void Update()
     {
         if (!vecInArea(playerObject.position))
         {
             Vector3 _newPos = new Vector3( playerObject.position.x, playerObject.position.y,transform.position.z);
             if (keepHeight)
                 _newPos.y = _pos.y;
             transform.position = Vector3.Lerp(transform.position, _newPos, moveSpeed * Time.deltaTime);
         }
     }
 
     bool vecInArea(Vector3 pos)
     {
         Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);
         return _moveArea.Contains(screenPos);
     }
 }
