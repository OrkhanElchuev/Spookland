using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    private void Start()
    {
        // Hide default cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Follow mouse position
        transform.position = Input.mousePosition;
    }
}
