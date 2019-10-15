using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public int magicSave;

    public enum state
    {
        None = 0,
        Fire = 1,//1
        Warter,//2
        Sunder,//3
        Wind,//4
    }

    state currentState = new state();

    void Start()
    {

    }

    void Update()
    {
        switch (magicSave)
        {
            case 0:
                currentState = state.None;
                break;

            case 1:
                currentState = state.Fire;
                break;
            case 2:
                currentState = state.Warter;
                break;
            case 3:
                currentState = state.Sunder;
                break;
            case 4:
                currentState = state.Wind;
                break;
        }
    }

    public void OnClick(int A)
    {
        magicSave = A;//Inspecter上で設定
    }

    public int GETSELECT()
    {
        return (int)currentState;
    }
}
