using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{

    public controlme player;
    public override void OnPointerDown(PointerEventData eventData)
    {
        player.onDrag = true;
        base.OnPointerDown(eventData);

    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        player.onDrag = false;
        base.OnPointerUp(eventData);
    }

}