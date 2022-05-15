using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RMS
{
    public class manager : MonoBehaviour
    {
        //scripts
        public Reader reader;
        //duplicate object
        internal ListItem listItem;
        //obekt referancer
        internal GameObject duplicate;
        public GameObject listeFilm;
        public GameObject listeMusik;
        public GameObject listeSerie;
        public GameObject listedobject;
        public GameObject[] ListObjects;
        public Text _1title;
        public Text _1undertext;
        public Text _2title;
        public Text _2undertext;
        public Text _3title;
        public Text _3undertext;
        //Værdier
        public int IndexNext = 1;
        public bool søger = false;
        internal bool index1Tom = false;
        internal bool index2Tom = false;
        internal bool index3Tom = false;
        public Text søgtText;

        
        void Awake() 
        {
            Reader reader = GetComponent<Reader>();
            
        }

        void Start()
        {
            int i = 0;
            string[] filmArray = reader.ReadString("/FilmData.txt");
            foreach (var item in filmArray)
            {
                duplicate = Instantiate(listeFilm);
                listItem = duplicate.GetComponent<ListItem>();
                listItem.SetText(filmArray[i] , "Film" , IndexNext);
                i++;
                IndexNext++;
            }

            i = 0;
            string[] musikArray = reader.ReadString("/MusikData.txt");
            foreach (var item in musikArray)
            {
                duplicate = Instantiate(listeMusik);
                listItem = duplicate.GetComponent<ListItem>();
                listItem.SetText(musikArray[i] , "Musik", IndexNext);
                i++;
                IndexNext++;
            }

            i = 0;
            string[] serieArray = reader.ReadString("/SerieData.txt");
            foreach (var item in serieArray)
            {
                duplicate = Instantiate(listeSerie);
                listItem = duplicate.GetComponent<ListItem>();
                listItem.SetText(serieArray[i], "Serie" , IndexNext);
                i++;
                IndexNext++;
            }

        }

        void Update() 
        {
            CheckOmListErTom();

            if (søger)
            {
                Søger();
            }
        }
        
        internal void Søger() 
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b') // has backspace/delete been pressed?
                {
                    if (søgtText.text.Length != 0)
                    {
                        søgtText.text = søgtText.text.Substring(0, søgtText.text.Length - 1);
                    }
                }
                else if ((c == '\n') || (c == '\r')) // enter/return
                {
                    int i = 0;
                    int nextAvaliableIndex = 1;
                    bool usedIndex = false;
                    ListObjects = GameObject.FindGameObjectsWithTag("Liste");
                    foreach (var item in ListObjects)
                    {
                        listItem = ListObjects[i].GetComponent<ListItem>();
                        usedIndex = listItem.Søgt(søgtText.text , nextAvaliableIndex);
                        if(usedIndex == true) {nextAvaliableIndex++;}
                        i++;
                    }
                    søger = false;
                }
                else
                {
                    søgtText.text += c;
                }
            }
        }

        internal void CheckOmListErTom() 
        {
            int i = 0;
            ListObjects = GameObject.FindGameObjectsWithTag("Liste");
            index1Tom = true;
            index2Tom = true;
            index3Tom = true;
            foreach (var item in ListObjects)
            {
                listItem = ListObjects[i].GetComponent<ListItem>();

                if (listItem.stringListSat == true)
                {
                    if (listItem.stringList[0] == "1")
                    {
                        index1Tom = false;
                    }
                    else if (listItem.stringList[0] == "2")
                    {
                        index2Tom = false;
                    }
                    else if (listItem.stringList[0] == "3")
                    {
                        index3Tom = false;
                    }
                    i++;
                }
            }
            if(index1Tom == true) 
            {
                _1title.text = "";
                _1undertext.text = "";
            }
            if (index2Tom == true)
            {
                _2title.text = "";
                _2undertext.text = "";
            }
            if (index3Tom == true)
            {
                _3title.text = "";
                _3undertext.text = "";
            }
        }

        public void SøgClicked() 
        {
            søger = true;
        }

        public void DownClicked() 
        {
            int i = 0;
            Debug.Log("klicekd");

            ListObjects = GameObject.FindGameObjectsWithTag("Liste");
            foreach (var item in ListObjects)
            {
                listItem = ListObjects[i].GetComponent<ListItem>();
                listItem.DownButtonClicked();
                i++;
            }
        }

        public void UpClicked()
        {
            int i = 0;
            Debug.Log("klicekd");

            ListObjects = GameObject.FindGameObjectsWithTag("Liste");
            foreach (var item in ListObjects)
            {
                listItem = ListObjects[i].GetComponent<ListItem>();
                listItem.OpButtonClicked();
                i++;
            }
        }

        public void FilmOgSerieKun() 
        {
            int i = 0;
            int nextAvaliableIndex = 1;
            bool usedIndex = false;
            ListObjects = GameObject.FindGameObjectsWithTag("Liste");
            foreach (var item in ListObjects)
            {
                listItem = ListObjects[i].GetComponent<ListItem>();
                usedIndex = listItem.FilmSerieKun(nextAvaliableIndex);
                if (usedIndex == true) { nextAvaliableIndex++; }
                i++;
            }
        }


        public void MusikKun()
        {
            int i = 0;
            int nextAvaliableIndex = 1;
            bool usedIndex = false;
            ListObjects = GameObject.FindGameObjectsWithTag("Liste");
            foreach (var item in ListObjects)
            {
                listItem = ListObjects[i].GetComponent<ListItem>();
                usedIndex = listItem.MusikKun(nextAvaliableIndex);
                if (usedIndex == true) { nextAvaliableIndex++; }
                i++;
            }
        }

    }
}
