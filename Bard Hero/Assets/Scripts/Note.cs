using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum Note : byte {
    None = 0,
    Green = 1 << 0,
    Red = 1 << 1,
    Yellow = 1 << 2,
    Blue = 1 << 3,
    Orange = 1 << 4,
}
