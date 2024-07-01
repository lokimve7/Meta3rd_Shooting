using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float x, y, z;
    public Transform trX, trY, trZ;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            x += 10;
            transform.localEulerAngles = new Vector3(x, y, z);
            trX.localEulerAngles = new Vector3(x, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            y += 10;
            transform.localEulerAngles = new Vector3(x, y, z);
            trY.localEulerAngles = new Vector3(0, y, 0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            z += 10;
            transform.localEulerAngles = new Vector3(x, y, z);
            trZ.localEulerAngles = new Vector3(0, 0, z);

        }
    }
}
