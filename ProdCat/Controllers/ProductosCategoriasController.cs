using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProdCat.Models;
using System.IO;
using System.Web.Mvc;

namespace ProdCat.Controllers
{
    public class ProductosCategoriasController : Controller
    {
        Models.Tarea1Entities contexto = new Models.Tarea1Entities();

        // GET: ProductosCategorias

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Validar()
        {
            //Capturar los  valores del formulario
            var email = Request["email"];
            var pass = Request["password"];
            //Buscar los datos en la BD
            var usu = (from u in contexto.Usuario where u.email == email && u.pass == pass select u).FirstOrDefault();
            //Si existen Crear session con los datos
            if (usu != null)
            {
                Session["Usuario"] = usu;
                return RedirectToAction("Listar");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //Si no redirecciono al Index con un mensaje

        }

        public ActionResult Listar()
        {
            if (Session["Usuario"] != null)
            {

                var cat = contexto.CategoriaProducto.ToList();
                ViewBag.Categorias = cat;
                return View(cat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Eliminar(int id)
        {
            if (Session["Usuario"] != null)
            {
                var cat = (from c in contexto.CategoriaProducto where c.Id == id select c).FirstOrDefault();

                //string Imagen = prod.nombreImagen;

                contexto.CategoriaProducto.Remove(cat);

                contexto.SaveChanges();

                return RedirectToAction("Listar");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult GuardarModificar()
        {
            int Id = int.Parse(Request["Id"]);
            var Nombre = Request["Nombre"];

            CategoriaProducto cat = (from c in contexto.CategoriaProducto where c.Id == Id select c).FirstOrDefault();
            if (cat != null)
            {
                cat.Id = Id;
                cat.Nombre = Nombre;

                contexto.SaveChanges();
            }

            return RedirectToAction("Listar");
        }

        public ActionResult MostrarModificar(int id)
        {
            var cat = (from c in contexto.CategoriaProducto where c.Id == id select c).FirstOrDefault();

            if (cat != null)
            {
                var cate = contexto.CategoriaProducto.ToList();
                ViewBag.Categorias = cat;
                return View(cat);
            }
            else
                return RedirectToAction("Listar");
        }

        public ActionResult Guardar()
        {
            string mensaje = "";
            var Id = Request["Id"];
            var Nombre = Request["Nombre"];

            CategoriaProducto cat = new CategoriaProducto();
            cat.Id = int.Parse(Id);
            cat.Nombre = Nombre;

            try
            {
                contexto.CategoriaProducto.Add(cat);
                contexto.SaveChanges();
                mensaje = "Guardado con exito";
            }
            catch (Exception ex)
            {
                mensaje = "Error al guardar los datos";
            }
            ViewBag.mensaje = mensaje;

            return RedirectToAction("Listar");
        }







    }
}