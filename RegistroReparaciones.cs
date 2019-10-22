using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using System.Xml.Linq;

namespace ReparacionesGrafico.Core
{
    class RegistroReparaciones
    {
        public const string ArchivoXml = "reparaciones.xml";
        public const string EtqReparaciones = "reparaciones";
        public const string EtqReparacion = "reparacion";

        public List<Reparacion> reparaciones;


        public RegistroReparaciones()
        {
            this.reparaciones = new List<Reparacion>();
    }


        public RegistroReparaciones(List<Reparacion> reparaciones)
        {
            this.reparaciones.AddRange(reparaciones);
        }

        public void AddReparacion(Reparacion r)
        {
            this.reparaciones.Add(r);
        }



        public int CountReparaciones
        {
            get { return this.reparaciones.Count; }
        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Reparacion r in this.reparaciones)
            {
                toret.AppendLine(r.ToString());
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
            var root = new XElement(EtqReparaciones);
            string tipo = "";


                foreach (Reparacion rep in this.reparaciones)
            {
              
                    root.Add(
                        new XElement(EtqReparacion,
                                new XAttribute("tipo", rep.GetType().ToString().Split('.')[1]),
                                new XAttribute("numSerie", rep.numSerie),
                                new XAttribute("horas", rep.horas),
                                new XAttribute("precio", rep.precio)));
                }

                
            doc.Add(root);
            doc.Save(nf);
        }

        public RegistroReparaciones RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }



        public static RegistroReparaciones RecuperaXml(string f)
        {
            var toret = new RegistroReparaciones();

            try
            {
                var doc = XDocument.Load(f);

                if (doc.Root != null
                  && doc.Root.Name == EtqReparaciones)
                {

                    var aps = doc.Root.Elements(EtqReparacion);

                    foreach (XElement reparacionxml in aps)
                    {
                        if ((string)reparacionxml.Attribute("tipo") == "SustitucionPiezas")
                        {
                            toret.AddReparacion(new SustitucionPiezas(
                                 (int)reparacionxml.Attribute("precio"),
                            (double)reparacionxml.Attribute("horas"),
                            (int)reparacionxml.Attribute("numSerie")));
                        }
                        else
                        {
                            toret.AddReparacion(new ReparacionCompleja(
                             (int)reparacionxml.Attribute("precio"),
                        (double)reparacionxml.Attribute("horas"),
                        (int)reparacionxml.Attribute("numSerie")));

                        }
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
            this.reparaciones.Clear();
        }

     
        public string toString()
        {
            StringBuilder toret = new StringBuilder();

            foreach (Reparacion r in reparaciones)
            {
                toret.Append(r.ToString());
            }

            return toret.ToString();
        }


    }

    
}
