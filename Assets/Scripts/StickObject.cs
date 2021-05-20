using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StickObject
{
    public string Name;
    public string Tag;
    public bool ShouldRestartLevel;
    public bool ShouldStartNextLevel;
}
