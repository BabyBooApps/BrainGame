using UnityEngine;
using System.Collections;


public class HorizontalMovementAnimation : MonoBehaviour
{
    public float moveDistance = 100.0f; // The distance to move in the X direction.
    public float moveDuration = 2.0f;  // The duration of the movement animation in seconds.

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        MoveRight();
    }

    private void MoveRight()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "x", startPos.x + moveDistance,
            "time", moveDuration,
            "easetype", iTween.EaseType.easeInOutSine,
            "oncomplete", "MoveBack"
        ));
    }

    private void MoveBack()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "x", startPos.x,
            "time", moveDuration,
            "easetype", iTween.EaseType.easeInOutSine,
            "oncomplete", "MoveRight"
        ));
    }
}
