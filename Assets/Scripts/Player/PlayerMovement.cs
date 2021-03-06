﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    #region Attributes in Editor
    public float speed = 5f;
    #endregion
    #region Input Handling Attributes
    private bool isClicked = false;
    public bool IsClicked
    {
        get {
#if UNITY_STANDALONE
            Debug.Log("Unity Standalone");
            if(Input.GetMouseButtonDown(0)) {
                switch(isClicked) {
                    case true:
                        isClicked = false;
                        break;
                    case false:
                        isClicked = true;
                        break;
                    default:
                        break;
                }
            }
#endif
#if UNITY_ANDROID
            Debug.Log("Unity Android");
            if(Input.touches.Length > 0){
                isClicked = true;
            }
            else
            {
                isClicked = false;
            }
#endif
            return isClicked;
        }
    }
    private Vector3 target;
    public Vector3 Target
    {
        get {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            return target;
        }
    }
    #endregion
    // Update is called once per frame
    void Update() {
        if(IsClicked) {
            transform.position = Vector3.MoveTowards(transform.position,
                Target, speed * Time.deltaTime / transform.localScale.x);
        }
    }
}
