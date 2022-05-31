using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : Singleton<InputControl>
{
    public string horStandaloneAxisName;
    public string verStandaloneAxisName;

    public float HorizontalAxis
    {
        get { return horizontalAxis; }
        private set { horizontalAxis = value; }
    }
    public float VerticalAxis
    {
        get { return verticalAxis; }
        private set { verticalAxis = value; }
    }

    private float horizontalAxis = 0f;
    private float verticalAxis = 0f;

    private void Update()
    {
#if UNITY_EDITOR
        HorizontalAxis = Input.GetAxis(horStandaloneAxisName);
        VerticalAxis = Input.GetAxis(verStandaloneAxisName);
#elif UNITY_ANDROID
        HorizontalAxis = UltimateJoystick.GetHorizontalAxis("MoveJoystick");
        VerticalAxis = UltimateJoystick.GetHorizontalAxis("MoveJoystick");
#endif
    }
}
