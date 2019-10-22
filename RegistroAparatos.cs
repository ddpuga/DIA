using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Xml.Linq;

namespace ReparacionesGrafico.Core
{
    class RegistroAparatos
    {
        public const string ArchivoXml = "aparatos.xml";
        public const string EtqAparatos = "aparatos";
        public const string EtqAparato = "aparato";

        public List<Aparato> aparatos;


        public RegistroAparatos()
        {
            this.aparatos = new List<Aparato>();
        }


        public RegistroAparatos(List<Aparato> aparatos)
        {
            this.aparatos.AddRange(aparatos);
        }

 
        public void AddAparato(Aparato a)
        {
            this.aparatos.Add(a);
        }

        public int CountAparatos
        {
            get { return this.aparatos.Count; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Aparato a in this.aparatos)
            {
                toret.AppendLine(a.ToString());
            }

            return toret.ToString();
        }



        public void GuardaXml()
        {
            this.GuardaXml(ArchivoXml);
        }



        public void GuardaXml(string nf)
        {
            var doc = new XDocument();
            var root = new XElement(EtqAparatos);


            foreach (Aparato ap in this.aparatos)
            {

                string tipo = ap.GetType().ToString().Split('.')[1];

                switch (tipo)
                {
                    case "AdaptadorTDT":
                        AdaptadorTDT tdt = (AdaptadorTDT)ap;
                        root.Add(
                    new XElement(EtqAparato,
                            new XAttribute("tipo", "AdaptadorTDT"),
                            new XAttribute("modelo", tdt.modelo),
                            new XAttribute("numSerie", tdt.numSerie),
                            new XAttribute("graba", tdt.Graba),
                            new XAttribute("tiempo", tdt.Tiempo)));
                        break;

                    case "Radio":
                        Radio ra = (Radio) ap;
                        root.Add(
                    new XElement(EtqAparato,
                            new XAttribute("tipo", "Radio"),
                            new XAttribute("modelo", ra.modelo),
                            new XAttribute("numSerie", ra.numSerie),
                            new XAttribute("bandas", ra.Bandas)));
                        break;

                    case "ReproductorDVD":
                        ReproductorDVD dvd = (ReproductorDVD)ap;
                        new XElement(EtqAparato,
                            new XAttribute("tipo", "Reproductor DVD"),
                            new XAttribute("modelo", dvd.modelo),
                            new XAttribute("numSerie", dvd.numSerie),
                            new XAttribute("bluray", dvd.BluRay),
                            new XAttribute("graba", dvd.Graba),
                            new XAttribute("tiempo", dvd.Tiempo));
                          break;
                    case "Televisor":
                        Televisor tv = (Televisor)ap;
                        new XElement(EtqAparato,
                            new XAttribute("tipo", "Televisor"),
                            new XAttribute("modelo", tv.modelo),
                            new XAttribute("numSerie", tv.numSerie),
                            new XAttribute("pulgadas", tv.Pulgadas));
                          break;

                }           
            }
            doc.Add(root);
            doc.Save(nf);
        }

        public RegistroAparatos RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }



        public static RegistroAparatos RecuperaXml(string f)
        {
            var toret = new RegistroAparatos();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqAparatos)
                {
                    var aps = doc.Root.Elements(EtqAparato);

                    foreach(XElement aparatoxml in aps)
                     {
                         toret.AddAparato(new Aparato(
                              (int)aparatoxml.Attribute("numSerie"),
                             (string)aparatoxml.Attribute("modelo")));
                     }


                }
            }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }

            return toret;
        }


        public void Clear()
        {
            this.aparatos.Clear();
        }


        public string toString()
        {
            StringBuilder toret = new StringBuilder();

            foreach (Aparato a in aparatos)
            {
                toret.Append(a.ToString());
            }

            return toret.ToString();
        }


    }


}
