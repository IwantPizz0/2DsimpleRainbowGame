using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class layerMaskUtil
{
    public static bool layerMaskContainsLayer(LayerMask layerMask, int layer)
    {
        if (layerMask == (layerMask | (1 << layer)))
            return true; return false;
    }
}
