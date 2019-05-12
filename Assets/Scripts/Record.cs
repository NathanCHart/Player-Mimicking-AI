using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Record
{

    public string filePath;

    // Start is called before the first frame update
    void Start()
    {

    }

    [STAThread]
    public void WritePlayer(string PlayerInput)
    {
        filePath = Application.streamingAssetsPath + "/PlayerInput.txt";

        if (!File.Exists(filePath))
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
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

    [STAThread]
    public void WriteDistance(float distance)
    {
        filePath = Application.streamingAssetsPath + "/Distance.txt";

        if (!File.Exists(filePath))
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(distance);
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
                sw.WriteLine(distance);
                Debug.Log("FileWritingSuccessful");
            }
        }
    }

    [STAThread]
    public void WriteEnemy(string enemyInput)
    {
        filePath = Application.streamingAssetsPath + "/EnemyInput.txt";

        if (!File.Exists(filePath))
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(enemyInput);
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
                sw.WriteLine(enemyInput);
                Debug.Log("FileWritingSuccessful");
            }
        }
    }
}
