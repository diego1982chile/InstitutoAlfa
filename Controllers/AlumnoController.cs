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

        public ActionResult ViewAlumno(int id_alumno)
        {
            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);

            alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);

            ViewBag.Alumno = alumno;

            return View("View");
        }


    }
}