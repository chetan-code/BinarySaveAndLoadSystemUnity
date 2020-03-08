using UnityEngine;
using System.Collections;
using System.IO;


public class GameDataReader
{
    BinaryReader reader;

    //lets create a constructor
    public GameDataReader(BinaryReader reader) {
        this.reader = reader;
    }

    //here we need to return as we are reading
    public float ReadFloat() {
        return reader.ReadSingle();
    }

    public int ReadInt() {
        return reader.ReadInt32();
    }

    public Quaternion ReadQuaternion() {
        Quaternion value;
        value.x = reader.ReadSingle();
        value.y = reader.ReadSingle();
        value.z = reader.ReadSingle();
        value.w = reader.ReadSingle();
        return value;
    }

    public Vector3 ReadVector3() {
        Vector3 value;
        value.x = reader.ReadSingle();
        value.y = reader.ReadSingle();
        value.z = reader.ReadSingle();
        return value;
    }
}
