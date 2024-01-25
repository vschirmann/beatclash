using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMergeBehaviour", menuName = "Beatclash/Merge Behaviour/Default", order = 0)]
public class DefaultMergeBehaviour : MergeBehaviour
{
    public override void Merge()
    {
        Debug.Log("Default Merge Behaviour");
    }
}
