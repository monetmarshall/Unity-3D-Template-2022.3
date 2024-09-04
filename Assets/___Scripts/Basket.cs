using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    
    private void Update()
    {
      // Get the current screen position of the mouse from Input
      Vector3 mousePos2D = Input.mousePosition; // a
      
      // The Camera's z position sets how far to push the mouse into 3D
      // If this line casues a NullReferenceException, select the Main Camera
      // In the hierarchy and set its tag to MainCamera in the Inspector
      mousePos2D.z = Camera.main.transform.position.z ; // b
      
      // Convert the point from 2D space into 3D game world space
      Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
      
      // Move the x position of this Basket to the x position of the mouse
      Vector3 pos = this.transform.position;
      pos.x = mousePos3D.x;
      this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // a
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            // c
            Destroy(collidedWith);
        }
    }
}
