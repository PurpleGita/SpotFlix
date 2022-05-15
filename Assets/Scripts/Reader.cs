using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace RMS
{

    public class Reader : MonoBehaviour
    {

        public string filename;

        void Start()
        {

            
        }


        public string[] ReadString(string filename)
        {
            string path = Application.persistentDataPath + filename;
            string[] lines = System.IO.File.ReadAllLines(path);
            Debug.Log(lines[0]);
            return lines;
            
        }
    }

}