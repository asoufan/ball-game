using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBoundary;
    private float objectWidth; //must include object width and height in clamp calculations to avoid half the object being outside the screen because it is being clamped at the center
    private float objectHeight;
    void Start()
    {
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x /2; //because the object is being clamped at the center, only need to divide it by 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y /2;
    }

    void LateUpdate() //late update because it is called after FixedUpdate in the movement script
    {
       Vector3 viewPosition = transform.position; //so we can alter our objects x and y coordinates
       viewPosition.x = Mathf.Clamp(viewPosition.x, screenBoundary.x*-1 + objectWidth, screenBoundary.x - objectWidth); //clamp our objetct's x position to the screen boundary's x position   note: we multiply by -1 because the screen coordinates are always negative/reversed
       viewPosition.y = Mathf.Clamp(viewPosition.y, screenBoundary.y*-1 + objectHeight, screenBoundary.y - objectHeight); //must add object width and height to minimum value and subtract from maximum value
       transform.position = viewPosition; //set current position to be equal to new altered position
    }
}
