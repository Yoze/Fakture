using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IspisBrojaSlovimaSR
{
    public class IspisBrojaSlovimaRSD
    {
        public string BrojSlovima { get; set; }

        public IspisBrojaSlovimaRSD(decimal _broj)
        {            
            BrojSlovima = Slovima(_broj);
        }

        private string Slovima(decimal broj)
        {

            string rez; // rezultat string
            int celi; // ceo broj
            int dec; // decimala
            string cbr; // ceo broj string
            int duzina;// dužina broja
            char ch;// vodeća nula
            string cbroj; // broj iz txt boxa + vodeće nule sa dužinom duzina
            int i;
            string tric; // tri cifre iz cbr, odakle se parse int 
            int trojka;// trojka iz 
            int cs; // stotine
            int cd;// desetice
            int cj; // jedinice
            string sl1; // slog
            string slovima;


            if (broj == 0) return rez = "nula";
            else
            {
                string[] imebr = new string[10];

                imebr[1] = "jedan";
                imebr[2] = "dva";
                imebr[3] = "tri";
                imebr[4] = "četiri";
                imebr[5] = "pet";
                imebr[6] = "šest";
                imebr[7] = "sedam";
                imebr[8] = "osam";
                imebr[9] = "devet";

                rez = string.Empty;

                celi = (int)broj;
                dec = Convert.ToInt32( ((broj - celi) * 100) % 100);
                cbr = celi.ToString();
                duzina = 15 - cbr.Length;

                ch = (char)48;
                cbroj = new string(ch, duzina) + cbr.Substring(0, cbr.Length);

                i = 1;

                while (i < 15)
                {
                    tric = cbroj.Substring(i - 1, 3);

                    trojka = Int32.Parse(tric);

                    if (!(tric == "000"))
                    {
                        cs = int.Parse(tric.Substring(0, 1)); // cs
                        cd = int.Parse(tric.Substring(1, 1)); // cd
                        cj = int.Parse(tric.Substring(2, 1)); // cj


                        switch (cs)
                        {
                            case 2:
                                rez += "dve";
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                rez += imebr[cs];
                                break;
                        }



                        switch (cs)
                        {
                            case 1:
                                rez += "stotinu";
                                break;
                            case 2:
                            case 3:
                            case 4:
                                rez += "stotine";
                                break;
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                                rez += "stotina";
                                break;
                        }

                        sl1 = (cj == 0) ? "" : imebr[cj];

                        switch (cd)
                        {
                            case 4:
                                rez += "četrdeset";
                                break;
                            case 6:
                                rez += "šezdeset";
                                break;
                            case 5:
                                rez += "pedeset";
                                break;
                            case 9:
                                rez += "devedeset";
                                break;
                            case 2:
                                rez += "dvadeset";
                                break;
                            case 3:
                                rez += "trideset";
                                break;
                            case 7:
                                rez += "sedamdeset";
                                break;
                            case 8:
                                rez += "osamdeset";
                                break;
                            case 1:
                                sl1 = "";
                                switch (cj)
                                {
                                    case 0:
                                        rez += "deset";
                                        break;
                                    case 1:
                                        rez += "jedanaest";
                                        break;
                                    case 4:
                                        rez += "četrnaest";
                                        break;
                                    case 6:
                                        rez += "šesnaest";
                                        break;
                                    default:
                                        rez += imebr[cj] + "naest";
                                        break;
                                }
                                break;
                        }
                        //if (cd > 1) rez += "deset";


                        if (i == 4 || i == 10 && cd != 1)
                        {
                            if (cj == 1) sl1 = "jedna";
                            if (cj == 2) sl1 = "dve";
                        }
                        rez += sl1;


                        switch (i)
                        {
                            case 1:
                                {
                                    rez += "bilion";
                                    if (cj > 1 || cd == 1) rez += "a";
                                    break;
                                }
                            case 4:
                                {
                                    rez += "milijard";
                                    if ((trojka % 100) > 11 && (trojka % 100) < 19) rez += "i";
                                    else
                                    {
                                        if (cj == 1) rez += "a";
                                        else
                                        {
                                            if (cj > 4 || cj == 0) rez += "i";
                                            else
                                            {
                                                if (cj > 1) rez += "e";
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    rez += "milion";
                                    if ((trojka % 100) > 11 && (trojka % 100) < 19 || cj != 1) rez += "a";
                                    break;
                                }
                            case 10:
                                {
                                    rez += "hiljad";
                                    if (((trojka % 100) > 11 && (trojka % 100) < 19) || cj == 1) rez += "a";
                                    else
                                    {
                                        if ((trojka == 1)) rez += "u";
                                        else
                                        {
                                            if ((cj > 4 || cj == 0)) rez += "a";
                                            else
                                            {
                                                if (cj > 1) rez += "e";
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }

                    i += 3;
                }

                return slovima = rez + " RSD i " + dec.ToString() + "/100";
            }
        }
    }
}
