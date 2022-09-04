using RegistroOcupaciones.Models;
using RegistroOcupaciones.DAL;
using Microsoft.EntityFrameworkCore;

namespace RegistroOcupaciones.BLL
{
    public class OcupacionesBLL
    {
        public Contexto _contexto;

        public OcupacionesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int id)
        {
            bool encontrado = false;
            try
            {
                encontrado = _contexto.Ocupaciones.Any(l => l.OcupacionId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }
        private bool Insertar(Ocupaciones ocupacion)
        {
            bool paso = false;
            try
            {
                _contexto.Ocupaciones.Add(ocupacion);
                paso = _contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            return paso;
        }
        private bool Modificar(Ocupaciones ocupacion)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(ocupacion).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }
        public bool Guardar(Ocupaciones ocupacion)
        {
            if (!Existe(ocupacion.OcupacionId))
            {
                return Insertar(ocupacion);
            }
            else
            {
                return Modificar(ocupacion);
            }
        }
        public Ocupaciones Buscar(int id)
        {
            Ocupaciones ocupacion;

            try
            {
                ocupacion = _contexto.Ocupaciones.Where(p => p.OcupacionId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return ocupacion;
        }
    }
}