using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fakture.Model
{
    public class PoreskiRekapitularZaReport
    {

        // Opsta stopa
        //public int OpstaStopaPDV { get;  }
        public decimal OpstaStopaUkupnaOsnovica { get; set; }
        public decimal OpstaStopaUkupanPDV { get; set; }
        
        // Posebna stopa
        //public int PosebnaStopaPDV { get;  }
        public decimal PosebnaStopaUkupnaOsnovica { get; set; }
        public decimal PosebnaStopaUkupanPDV { get; set; }

        // lista stavki fakture
        private List<ListaStavkiFaktureView> ListaStavkiFakture;


        public PoreskiRekapitularZaReport(List<ListaStavkiFaktureView> _listaStavki)
        {
            ListaStavkiFakture = _listaStavki;

            //OpstaStopaPDV = 20;
            OpstaStopaUkupnaOsnovica = decimal.Zero;
            OpstaStopaUkupanPDV = decimal.Zero;

            //PosebnaStopaPDV = 10;
            PosebnaStopaUkupnaOsnovica = decimal.Zero;
            PosebnaStopaUkupanPDV = decimal.Zero;

            UradiPoreskuRekapitulaciju();
        }


        // poreska kalkulacija za opštu i posebnu stopu PDV-a
        private void UradiPoreskuRekapitulaciju()
        {
            foreach (ListaStavkiFaktureView item in ListaStavkiFakture)
            {
                switch (item.StopaPDV)
                {
                    case 20:
                        {
                            OpstaStopaUkupnaOsnovica += item.OsnovicaPDV;
                            OpstaStopaUkupanPDV += item.IznosPDV;
                        }
                        break;

                    case 10:
                        {
                            PosebnaStopaUkupnaOsnovica += item.OsnovicaPDV;
                            PosebnaStopaUkupanPDV += item.IznosPDV;
                        }
                        break;
                    
                }

                //if (item.StopaPDV == OpstaStopaPDV)
                //{
                //    OpstaStopaUkupnaOsnovica += item.OsnovicaPDV;
                //    OpstaStopaUkupanPDV += item.IznosPDV;
                //}
                //if (item.StopaPDV == PosebnaStopaPDV)
                //{
                //    PosebnaStopaUkupnaOsnovica += item.OsnovicaPDV;
                //    PosebnaStopaUkupanPDV += item.IznosPDV;
                //}
            }           

        }
    }
}
