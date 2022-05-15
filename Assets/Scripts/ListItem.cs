using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RMS
 {
    public class ListItem : MonoBehaviour
    {
        public Text _1title;
        public Text _1undertext;
        public Text _2title;
        public Text _2undertext;
        public Text _3title;
        public Text _3undertext;
        public List<string> stringList;
        internal bool stringListSat = false;
        public string titel;
        public string titelEpisode;
        public string kunstner;
        public string længde;
        public string genre;
        public string album;
        public string dato;
        public string sæson;
        public string episode;
        public string www;
        public string type;
        public int index;
        public float yPos;
        internal double længdeITimer;
        internal double længdeIMinutter;
        public SpriteRenderer spriteRenderer;
        public Sprite netflixsprite;
        public Sprite viaplaySprite;
        public Sprite spotifiySprite;
        public Sprite hboSprite;




        public void Update()
        {
            //køre kun hvis strinList er sat eller fucker parent det op.
            if (stringListSat)
            {
                SkiftPosition(stringList[0]);
                OpdaterText(stringList);
            }
        }


        public void SetText(string textline , string medie , int indexNext)
        {
            //finder titel og sætter den
            var startTag = "";
            int startIndex = textline.IndexOf(startTag) + startTag.Length;
            int endIndex = textline.IndexOf(",", startIndex);
            titel = (textline.Substring(startIndex, endIndex - startIndex));
            type = medie;
            index = indexNext;

            //kunne nemt havde været lavet til et loop så man ikke skulle skrive det samme så meget, men tænkte jeg først over da jeg nået til Serie T_T       eller i det mindste en switch case i mean come on man ved godt jeg ikke er klog men seriøst wtf tænkte jeg.
            if (type == "Film")
            {
                
                //finder længde og sætter den via titels længde
                startTag = titel + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                længde = (textline.Substring(startIndex, endIndex - startIndex));
                string længdeStringLængde = længde;
                længdeITimer = (Int32.Parse(længde) / 60)/60;
                længdeITimer = Math.Floor(længdeITimer);
                længdeIMinutter = Int32.Parse(længde) / 60 - længdeITimer * 60;
                længdeIMinutter = Math.Floor(længdeIMinutter);
                længde = længdeITimer + ":" +  længdeIMinutter;


                //finder genre og sætter den via titels længde og længde længde
                startTag = titel + ", " + længdeStringLængde + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                genre = (textline.Substring(startIndex, endIndex - startIndex));

                //finder genre og sætter den via titels længde, længde længde og genre længde
                startTag = titel + ", " + længdeStringLængde + ", " + genre + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                dato = (textline.Substring(startIndex, endIndex - startIndex));


                //finder genre og sætter den via titels længde, længde længde, genre længde og www
                startTag = titel + ", " + længdeStringLængde + ", " + genre + ", " + dato + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.Length;
                www = (textline.Substring(startIndex, endIndex - startIndex));

                stringList = new List<string>()
                {
                index.ToString(),type,titel,længde,genre,dato,www
                };
                stringListSat = true;
            }

            if (type == "Musik") 
            {
                //finder længde og sætter den via titels længde
                startTag = titel + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                kunstner = (textline.Substring(startIndex, endIndex - startIndex));


                startTag = titel + ", " + kunstner + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                genre = (textline.Substring(startIndex, endIndex - startIndex));

               
                startTag = titel + ", " + kunstner + ", " + genre + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                album = (textline.Substring(startIndex, endIndex - startIndex));


                startTag = titel + ", " + kunstner + ", " + genre + ", " + album + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                længde = (textline.Substring(startIndex, endIndex - startIndex));
                //tiemr = minutter minutter = sekunder
                string længdeStringLængde = længde;
                længdeITimer = (Int32.Parse(længde) / 60);
                længdeITimer = Math.Floor(længdeITimer);
                længdeIMinutter = Int32.Parse(længde) - længdeITimer * 60;
                længdeIMinutter = Math.Floor(længdeIMinutter);
                længde = længdeITimer + ":" + længdeIMinutter;

                startTag = titel + ", " + kunstner + ", " + genre + ", " + album + ", " + længdeStringLængde + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                dato = (textline.Substring(startIndex, endIndex - startIndex));



                startTag = titel + ", " + kunstner + ", " + genre + ", " + album + ", " + længdeStringLængde + ", " + dato + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.Length;
                www = (textline.Substring(startIndex, endIndex - startIndex));

                stringList = new List<string>()
                {
                index.ToString(),type,titel,kunstner,genre,album,længde,dato,www
                };
                stringListSat = true;
            }

            if (type == "Serie") 
            {
                startTag = titel + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                titelEpisode = (textline.Substring(startIndex, endIndex - startIndex));

                startTag = titel + ", " + titelEpisode + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                genre = (textline.Substring(startIndex, endIndex - startIndex));

                startTag = titel + ", " + titelEpisode + ", " + genre + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                længde = (textline.Substring(startIndex, endIndex - startIndex));
                string længdesStringLængde = længde;
                længdeIMinutter = Int32.Parse(længde) / 60;
                længde = længdeIMinutter.ToString();
                

                startTag = titel + ", " + titelEpisode + ", " + genre + ", " + længdesStringLængde + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                dato = (textline.Substring(startIndex, endIndex - startIndex));

                startTag = titel + ", " + titelEpisode + ", " + genre + ", " + længdesStringLængde + ", " + dato + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                sæson = (textline.Substring(startIndex, endIndex - startIndex));

                startTag = titel + ", " + titelEpisode + ", " + genre + ", " + længdesStringLængde + ", " + dato + ", " + sæson + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.IndexOf(",", startIndex);
                episode = (textline.Substring(startIndex, endIndex - startIndex));

                startTag = titel + ", " + titelEpisode + ", " + genre + ", " + længdesStringLængde + ", " + dato + ", " + sæson + ", " + episode + ", ";
                startIndex = textline.IndexOf(startTag) + startTag.Length;
                endIndex = textline.Length;
                www = (textline.Substring(startIndex, endIndex - startIndex));


                stringList = new List<string>()
                {
                index.ToString(),type,titel,titelEpisode,genre,længde,dato,sæson,www
                };
                stringListSat = true;
            }

            SkiftSprite(www);
            
        }

        internal void SkiftSprite(string www)
        {
            switch (www) 
            {

                case "Netflix":

                    spriteRenderer.sprite = netflixsprite;
                    break;

                case "Viaplay":

                    spriteRenderer.sprite = viaplaySprite;
                    break;

                case "HBO":

                    spriteRenderer.sprite = hboSprite;
                    break;

                case "Spotifiy":
                    spriteRenderer.sprite = spotifiySprite;
                    break;
            }


        }

        internal void SkiftPosition(string index)
        {
            yPos = 10;
            switch (index)
            {

                case "1":

                    yPos = 2.3f;
                    break;

                case "2":

                    yPos = -0.7f;
                    break;

                case "3":

                    yPos = -3.7f;
                    break;

                case "4":
                    yPos = -6.7f;
                    break;
            }
            transform.position = new Vector3(-6 , yPos , 0);
        }

        internal void OpdaterText(List<string> stringList) 
        {
            if (Int32.Parse(stringList[0]) > 0 && Int32.Parse(stringList[0]) < 4)
            {
                if (stringList[0] == "1")
                {
                    switch (stringList[1])
                    {
                        case "Film":
                            //index.ToString(),type,titel,længde,genre,dato,sæson,www
                            _1title.text = stringList[2];
                            _1undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + ", " + stringList[6];
                            break;

                        case "Musik":
                            //index.ToString(),type,titel,kunstner,genre,album,længde,dato,www
                            _1title.text = stringList[2];
                            _1undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + ", " + stringList[6] + ", " + stringList[7] + ", " +  stringList[8];
                            break;

                        case "Serie":
                            //index.ToString(),type,titel,titelEpisode,genre,længde,dato,sæson,www
                            _1title.text = stringList[2];
                            _1undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + " " + stringList[6] + ", " + stringList[7] + ", " +  stringList[8];
                            break;
                    }
                }else if (stringList[0] == "2") 
                {
                    switch (stringList[1])
                    {
                        case "Film":
                            //index.ToString(),type,titel,længde,genre,dato,sæson,www
                            _2title.text = stringList[2];
                            _2undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + ", " + stringList[6];
                            break;

                        case "Musik":
                            //index.ToString(),type,titel,kunstner,genre,album,længde,dato,sæson,www
                            _2title.text = stringList[2];
                            _2undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + ", " + stringList[6] + ", " + stringList[7] + ", " + stringList[8];
                            break;

                        case "Serie":
                            //index.ToString(),type,titel,titelEpisode,genre,længde,dato,sæson,www
                            _2title.text = stringList[2];
                            _2undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + " " + stringList[6] + ", " + stringList[7] + ", " + stringList[8];
                            break;
                    }
                }else if (stringList[0] == "3") 
                {
                    switch (stringList[1])
                    {
                        case "Film":
                            //index.ToString(),type,titel,længde,genre,dato,sæson,www
                            _3title.text = stringList[2];
                            _3undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + ", " + stringList[6];
                            break;

                        case "Musik":
                            //index.ToString(),type,titel,kunstner,genre,album,længde,dato,sæson,www
                            _3title.text = stringList[2];
                            _3undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + ", " + stringList[6] + ", " + stringList[7] + ", " + stringList[8];
                            break;

                        case "Serie":
                            //index.ToString(),type,titel,titelEpisode,genre,længde,dato,sæson,www
                            _3title.text = stringList[2];
                            _3undertext.text = stringList[3] + ", " + stringList[4] + ", " + stringList[5] + " " + stringList[6] + ", " + stringList[7] + ", " + stringList[8];
                            break;
                    }
                }
            }
        }

        public void DownButtonClicked() 
        {
            if (stringListSat)
            {
                int newIndex = Int32.Parse(stringList[0]) - 1;
                stringList[0] = newIndex.ToString();
            }
        }

        public void OpButtonClicked()
        {
            if (stringListSat)
            {
                int newIndex = Int32.Parse(stringList[0]) + 1;
                stringList[0] = newIndex.ToString();
            }
        }

        public void ResetIndex()
        { 
        }

        public bool Søgt(string søgtText, int nextAvaliableIndex)
        {
            if (stringListSat)
            {
                Debug.Log(søgtText);
                if (stringList[2].Contains(søgtText))
                {
                    stringList[0] = nextAvaliableIndex.ToString();
                    return true;   
                }
                else 
                { 
                    stringList[0] = 100.ToString();
                    return false;
                }
            }return false;
        }

        public bool FilmSerieKun(int nextAvaliableIndex) 
        {
            if (stringListSat)
            {
                
                if (stringList[1].Contains("Film") || stringList[1].Contains("Serie"))
                {
                    stringList[0] = nextAvaliableIndex.ToString();
                    return true;
                }
                else
                {
                    stringList[0] = 100.ToString();
                    return false;
                }
            }
            return false;
        }

        public bool MusikKun(int nextAvaliableIndex) 
        {
            if (stringListSat)
            {

                if (stringList[1].Contains("Musik"))
                {
                    stringList[0] = nextAvaliableIndex.ToString();
                    return true;
                }
                else
                {
                    stringList[0] = 100.ToString();
                    return false;
                }
            }
            return false;
        }
    }
    
}