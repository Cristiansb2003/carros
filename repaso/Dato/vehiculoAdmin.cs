using repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace repaso.Dato
{
    public class vehiculoAdmin
    {
        //Este es para consultar datos
        public IEnumerable<vehiculo> Consultar()
        {
            using(autosEntities contexto = new autosEntities())
            {
                return contexto.vehiculo.AsNoTracking().ToList();
            }
        }

        //Guardar vehiculo en la base de datos
        public void Guardar(vehiculo modelo)
        {
            using(autosEntities contexto = new autosEntities())
            {
                contexto.vehiculo.Add(modelo);//Aqui agrego lo que me manden de la pagina
                contexto.SaveChanges();
            }
        }

        //Consultar
        public vehiculo Consultar(int id)
        {
            using(autosEntities contexto = new autosEntities())
            {
                return contexto.vehiculo.FirstOrDefault(v => v.Id == id);
            }
        }

        //Modificar los datos del vehiculo
        public void Modificar(vehiculo modelo)
        {
            using (autosEntities contexto = new autosEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }


        //Eliminar auto
        public void Eliminar(vehiculo modelo)
        {
            using(autosEntities contexto = new autosEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}