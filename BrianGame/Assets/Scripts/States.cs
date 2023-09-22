using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class States 
{
    public static UI_State Currentstate = UI_State.none;
    public static UI_State PreviousState = UI_State.none;

    public static void Set_UI_state(UI_State state)
    {
        PreviousState = Currentstate;
        Currentstate = state;
    }

}

public enum UI_State
{
    none,
    SplashScreen,
    HomeScreen,
    MenuScreen
}
