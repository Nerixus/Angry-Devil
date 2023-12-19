using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Unit : Moving_Unit
{

    private void Start()
    {
        base.Start();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime, Space.World);
    }
}
