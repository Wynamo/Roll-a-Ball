using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour
{

    //true = up, false = down
    public bool direction = true;
    // Before rendering each frame..
    void Update()
    {
        // Rotate the game object that this script is attached to by 15 in the X axis,
        // 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
        // rather than per frame.
        //transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        if (transform.position.y >= 2)
        {
            direction = false;
        }
        else if (transform.position.y <= 1)
        {
            direction = true;
        }


        if (!direction)
        {
            transform.position -= transform.up * 1 * Time.deltaTime;
        }
        else if (direction) 
        {
            transform.position += transform.up * 1 * Time.deltaTime;
        }
    }
}