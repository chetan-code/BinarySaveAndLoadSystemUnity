using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    public int ShapeId {
        get {
            return shapeId;
        }
        set {
            if (shapeId == 0)
            {
                shapeId = value;
            }
            else {
                Debug.LogError("Not allowed to change shapeId.");
            }
        }
    }

    int shapeId = int.MinValue;

}
