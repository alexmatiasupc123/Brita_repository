using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;



namespace Britanico.Utilitario.Funciones
{


   public class Funciones
    {   
       
       public string determinaMes(DateTime fecha)
        {
            String nombreMes = "";

            Int32 mes = Convert.ToInt32(fecha.Month);
            switch (mes)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Setiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                case 12:
                    nombreMes = "Diciembre";
                    break;
                default:
                    break;


            }
            return nombreMes;
        }

  

       public string determinaMesCorto(DateTime fecha)
       {
           String nombreMes = "";

           Int32 mes = Convert.ToInt32(fecha.Month);
           switch (mes)
           {
               case 1:
                   nombreMes = "ENE.";
                   break;
               case 2:
                   nombreMes = "FEB.";
                   break;
               case 3:
                   nombreMes = "MAR.";
                   break;
               case 4:
                   nombreMes = "ABR.";
                   break;
               case 5:
                   nombreMes = "MAY.";
                   break;
               case 6:
                   nombreMes = "JUN.";
                   break;
               case 7:
                   nombreMes = "JUL.";
                   break;
               case 8:
                   nombreMes = "AGO.";
                   break;
               case 9:
                   nombreMes = "SET.";
                   break;
               case 10:
                   nombreMes = "OCT.";
                   break;
               case 11:
                   nombreMes = "NOV.";
                   break;
               case 12:
                   nombreMes = "DIC.";
                   break;
               default:
                   break;


           }
           return nombreMes;
       }

       public string determinaDiaSemana(String diaSistema)
       {
           String DiaSemana = "";
           switch (diaSistema)
           {
               case "Lunes":
                   DiaSemana = "Lun.";
                   break;
               case "Martes":
                   DiaSemana = "Mar.";
                   break;
               case "Miércoles":
                   DiaSemana = "Mie.";
                   break;
               case "Jueves":
                   DiaSemana = "Jue.";
                   break;
               case "Viernes":
                   DiaSemana = "Vie.";
                   break;
               case "Sábado":
                   DiaSemana = "Sab.";
                   break;
               case "Domingo":
                   DiaSemana = "Dom.";
                   break;
               case "Monday":
                   DiaSemana = "Lun.";
                   break;
               case "Tuesday":
                   DiaSemana = "Mar.";
                   break;
               case "Wednesday":
                   DiaSemana = "Mie.";
                   break;
               case "Thursday":
                   DiaSemana = "Jue.";
                   break;
               case "Friday":
                   DiaSemana = "Vie.";
                   break;
               case "Saturday":
                   DiaSemana = "Sab.";
                   break;
               case "Sunday":
                   DiaSemana = "Dom.";
                   break;

               default:
                   break;


           }
           return DiaSemana;
       }

       public string StripHtml(string html)
       {
           if (html == null || html == string.Empty)
               return string.Empty;

           return System.Text.RegularExpressions.Regex.Replace(html, "<[^>]*>", string.Empty);
       }



     
   }

   
}
