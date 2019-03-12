using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public GameObject diver;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var diverPos = diver.transform.position;
            diverPos.x = 0f;
            diverPos.y = .5f;
            diverPos.z = -3f;
            diver.transform.position = diverPos;

            Physics.IgnoreCollision(diver.GetComponent<Collider>(), water.GetComponent<Collider>(), false);

        }
    }

}
