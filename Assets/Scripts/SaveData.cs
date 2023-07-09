using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] Dealer dealer;
    string persistentPath = "";

    private void Awake()
    {
        SetPaths();
    }

    private void Start()
    {
        if (File.Exists(persistentPath))
            Debug.Log("Save File Found");
        else Debug.Log("No Save File Found");
    }


    void SetPaths()
    {
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        Debug.Log("save path is " + persistentPath);
    }


    public void Save()
    {
        HandData handData = new(dealer.Serialize());
        string json = JsonUtility.ToJson(handData);
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(persistentPath);
        writer.Write(json);

    }

    public void Load()
    {
        if (File.Exists(persistentPath))
        {
            using StreamReader reader = new StreamReader(persistentPath);
            string json = reader.ReadToEnd();

            //scoreData = JsonUtility.FromJson<ScoreData>(json);
            dealer.LoadHand(JsonUtility.FromJson<HandData>(json));
        }
    }

}

//a class for serializing an array of num values so it can be saved as JSON
public class HandData
{
    public int[] hand = new int[7];

    public HandData(int[] cards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            hand[i] = cards[i];
        }
    }
}

