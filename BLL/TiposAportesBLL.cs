using GestionPersonas.DAL;
using GestionPersonas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.BLL
{
    class TiposAportesBLL
    {
        public static List<TiposAportes> GetTiposAportes()
        {
            List<TiposAportes> lista = new List<TiposAportes>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.tiposAportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
