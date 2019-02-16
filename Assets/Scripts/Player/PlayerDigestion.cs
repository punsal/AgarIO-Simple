using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDigestion : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Food") {
            transform.localScale += CalculateRelativeIncrease(other.transform.localScale);
            other.gameObject.SetActive(false);
        }
    }
    private Vector3 CalculateRelativeIncrease(Vector3 other) {
        /** <summary>
                Takes a relative Vector3 variable,
                Apply simple function calculation,
                return incremental output.
            </summary>
            <function>
                F(other) = 1f / [(y'{x,y,z} / other{x,y,z}) * 20f)]     
            </function>
        */

        //calculate relative percentage of otherVector3
        Vector3 increase = new Vector3()
        {
            x = 100 / (transform.localScale.x / other.x),
            y = 100 / (transform.localScale.y / other.y),
            z = 100 / (transform.localScale.z / other.z)
        };
        //Apply calculated percentage into first scale change parameters
        increase *= 0.01f;
        increase /= 20f;

        return increase;
    }
}