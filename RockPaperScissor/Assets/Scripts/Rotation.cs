using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    
   // public GameObject obj;
    private Vector3 RotateAmount;  // degrees per second to rotate in each axis. Set in inspector.
    public int x = 100;
    public int y = 100;
    public int z = 100;

    void Start()
    {
       // obj.SetActive(false);
       gameObject.SetActive(false);
    }

    // Update is called once per frame
     void Update () {
        RotateAmount = new Vector3(x, y, z);
        transform.Rotate(RotateAmount* Time.deltaTime);
    }
}
