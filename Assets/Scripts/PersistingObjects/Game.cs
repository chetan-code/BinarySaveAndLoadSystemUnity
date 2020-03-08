using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : PersistableObject
{
    const int saveVersion = 1;

    public PersistentStorage storage;
    public ShapeFactory shapeFactory;
    public KeyCode createKey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;
    public KeyCode saveKey = KeyCode.S;
    public KeyCode loadKey = KeyCode.L;

    List<PersistableObject> shapes;
    string savePath;

    private void Awake()
    {
        shapes = new List<PersistableObject>();
    }

    private void Update()
    {
        //Creating new cubes on keyinput - c
        if (Input.GetKeyDown(createKey))
        {
            CreateObjects();
        }
        //starting a new game
        else if (Input.GetKeyDown(newGameKey))
        {
            BeginNewGame();
        }
        //saving the game
        else if (Input.GetKeyDown(saveKey))
        {
            storage.Save(this);
        }
        //loading form saved file 
        else if (Input.GetKeyDown(loadKey)) {
            BeginNewGame();
            storage.Load(this);
        }
    }

    private void CreateObjects() {
        Shape instance = shapeFactory.GetRandom();
        Transform t = instance.transform;
        t.localPosition = Random.insideUnitSphere * 5;
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(0.1f, 1f);
        shapes.Add(instance);
    }

    private void BeginNewGame() {
        //destroy all objects present in the scene
        for (int i = 0; i < shapes.Count; i++) {
            Destroy(shapes[i].gameObject);
        }
        //clear list after destroying all the objects
        shapes.Clear();
    }

    public override void Save(GameDataWriter writer) {
        writer.Write(shapes.Count);
        for (int i = 0; i < shapes.Count; i++) {
            shapes[i].Save(writer);
        }
    }

    public override void Load(GameDataReader reader)
    {
        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
        {
            Shape instance = shapeFactory.Get(0);
            instance.Load(reader);
            shapes.Add(instance);
        }
    }

    //private void Save() {
    //    //We create a binary writer with a file 
    //    using( 
    //        //creatig the file
    //        var writer = new BinaryWriter(File.Open(savePath, FileMode.Create))
    //    ) {
    //        //lets write some data to file - we can write simple values like integer bools etc
    //        writer.Write(objects.Count);//count
    //        //lets write position
    //        for (int i = 0; i < objects.Count; i++) {
    //            Transform t = objects[i];
    //            writer.Write(t.localPosition.x);
    //            writer.Write(t.localPosition.y);
    //            writer.Write(t.localPosition.z);
    //        }
    //    }
    //    //using keyword make sure we dispose writer after its exection completes
    //    Debug.Log("File saved at :" + savePath);
    //}

    //private void Load() {
    //    //loading a new game with saved data
    //    BeginNewGame();
    //    using (
    //            //opening the already saved file
    //            var reader = new BinaryReader(File.Open(savePath, FileMode.Open))
    //        ) {
    //        //reading the object counts
    //        int count = reader.ReadInt32();
    //        //reading position one by one (in same order)
    //        for (int i = 0; i < count; i++) {
    //            Vector3 p;
    //            p.x = reader.ReadSingle();//float is read with readsingle
    //            p.y = reader.ReadSingle();
    //            p.z = reader.ReadSingle();
    //            //lets instantiate new cubes based on the data
    //            Transform t = Instantiate(prefab);
    //            t.localPosition = p;
    //            objects.Add(t);
    //        }
    //    }
    //}
}
