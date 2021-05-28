using repaso.Dato;
using repaso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace repaso.Controllers
{
    public class vehiculoController : Controller
    {
        vehiculoAdmin admin = new vehiculoAdmin();
        // GET: vehiculo
        public ActionResult Index()
        {
            IEnumerable<vehiculo> lista = admin.Consultar();
            return View(lista);
        }

        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }
        public ActionResult Nuevo(vehiculo modelo)
        {
            admin.Guardar(modelo);
            ViewBag.mensaje = "Vehiculo Guardado";
            return View("Guardar", modelo);
        }

        public ActionResult Detalle(int id = 0)
        {
            vehiculo modelo = admin.Consultar(id);
            return View(modelo);
        }

        public ActionResult Modificar(int id = 0)
        {
            ViewBag.mensaje = "";
            vehiculo modelo = admin.Consultar(id);
            return View(modelo);
        }

        public ActionResult Actualizar(vehiculo modelo)
        {
            admin.Modificar(modelo);
            ViewBag.mensaje = "Vehiculo Actualizado";
            return View("Modificar", modelo);
        }

        public ActionResult Eliminar( int id = 0)
        {
            vehiculo modelo = new vehiculo()
            {
                Id = id
            };
            admin.Eliminar(modelo);
            IEnumerable<vehiculo> lista = admin.Consultar();
            ViewBag.mensaje = "Vehiculo Eliminado";
            return View("Index", lista);
        }
    }

    
}