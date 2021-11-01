using GestionPersonas.DAL;
using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.BLL
{
    class AportesBLL
    {
        public static bool Guardar(Aportes aporte)
        {
            if (!Existe(aporte.AporteId))
                return Insertar(aporte);
            else
                return Modificar(aporte);
        }

        private static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Aportes.Add(aporte);

                foreach (var detalle in aporte.AportesDetalle)
                {
                    detalle.TiposAportes.Logrado += aporte.Monto;
                }

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var aporteAnterior = contexto.Aportes
                    .Where(x => x.AporteId == aporte.AporteId)
                    .Include(x => x.AportesDetalle)
                    .ThenInclude(x => x.Personas)
                    .AsNoTracking()
                    .SingleOrDefault();

                foreach (var detalle in aporteAnterior.AportesDetalle)
                {
                    detalle.TiposAportes.Logrado += aporte.Monto;
                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM GruposDetalle Where AportesId={aporte.AporteId}");

                foreach (var item in aporteAnterior.AportesDetalle)
                {
                    item.TiposAportes.Logrado += aporte.Monto;

                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(aporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var aporte = AportesBLL.Buscar(id);

                if (aporte != null)
                {
                    
                    foreach (var detalle in aporte.AportesDetalle)
                    {
                        detalle.TiposAportes.Logrado -= aporte.Monto;
                    }

                    contexto.Aportes.Remove(aporte); 
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Aportes Buscar(int id)
        {
            Aportes aportes = new Aportes();
            Contexto contexto = new Contexto();

            try
            {
                aportes = contexto.Aportes.Include(x => x.AportesDetalle)
                    .Where(x => x.AporteId == id)
                     .Include(x => x.AportesDetalle)
                    .ThenInclude(x => x.Personas)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return aportes;
        }

        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> Lista = new List<Aportes>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Aportes.Any(e => e.AporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
