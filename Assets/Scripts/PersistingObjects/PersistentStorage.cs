using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentStorage : MonoBehaviour
{

    string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveFile");
    }

    public void Save(PersistableObject o) {
        using (
              var writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
            ) {
            o.Save(new GameDataWriter(writer));
        }
    }

    public void Load(PersistableObject o) {
        using (
            var reader = new BinaryReader(File.Open(savePath, FileMode.Open))
            ) {
            o.Load(new GameDataReader(reader));
        }
    }

}
