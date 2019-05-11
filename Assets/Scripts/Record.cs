using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Record 
{
    public string filePath = Application.streamingAssetsPath + "/PlayerInput.txt";

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void Write(string PlayerInput)
    {
        if (!File.Exists(filePath))
        {
            try
            {           
                StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/PlayerInput.txt");       
                sw.WriteLine(PlayerInput);
                sw.Close();
            }
            catch (Exception e)
            {
                Debug.Log("Exception: " + e.Message);
            }
            finally
            {
                Debug.Log("FileWritingSuccessful");
                Debug.Log(Application.streamingAssetsPath.ToString());
            }
        }
        else
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(PlayerInput);
                Debug.Log("FileWritingSuccessful");
            }
        }
    }
}
