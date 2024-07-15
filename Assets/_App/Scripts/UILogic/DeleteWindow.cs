using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWindow : MonoBehaviour
{
    public Animator DeleteWindowAnimator;
    public string AnimBoolName = "On";

    public void SwitchActivation(bool value)
    {
        DeleteWindowAnimator.SetBool(AnimBoolName, value);
    }
}
