using InstitutoAlfa.DAOs;
using InstitutoAlfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstitutoAlfa.Controllers
{    

    public class AlumnoController : Controller
    {

        private readonly AlumnoDAO alumnoDAO = new AlumnoDAO();

        private readonly MatriculaDAO matriculaDAO = new MatriculaDAO();

        public ActionResult Index()
        {            
            List<Alumno> alumnos = alumnoDAO.getAllAlumnos();
            
            ViewBag.Alumnos = alumnos;
            
            return View();
        }

        public ActionResult NewAlumno()
        {            
            return View("New");
        }

        public ActionResult CreateAlumno(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                alumno = alumnoDAO.createAlumno(alumno);
                // Aquí cualquier uso de las variables del Modelo
            }            

            return View("Index");
        }

        public ActionResult ViewAlumno(int id_alumno)
        {
            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);

            alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);

            ViewBag.Alumno = alumno;

            ViewBag.Nacimiento = alumno.nacimiento.ToString("yyyy-MM-dd"); ;

            return View("View");
        }


    }
}