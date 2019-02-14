using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isClicked = false;

    public bool IsClicked
    {
        get
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (isClicked)
                {
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
            return isClicked;
        }
    }

    private Vector3 mouseTarget;

    public Vector3 MouseTarget
    {
        get
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            return target;
        }
    }



    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsClicked)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                MouseTarget, speed * Time.deltaTime / transform.localScale.x);
        }
    }
}
