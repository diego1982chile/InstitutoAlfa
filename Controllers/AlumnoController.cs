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

        private readonly CursoDAO cursoDAO = new CursoDAO();

        private readonly MatriculaDAO matriculaDAO = new MatriculaDAO();

        private readonly AnyoDAO anyoDAO = new AnyoDAO();

        private readonly BimestreDAO bimestreDAO = new BimestreDAO();

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
                try
                {
                    alumno = alumnoDAO.createAlumno(alumno);                    
                    return RedirectToAction("Index").Information("Se ha creado el alumno correctamente");
                }
                catch (Exception e)
                {                    
                    return View("New").Warning("Error: " + e.Message);                    
                }
            }  
            else
            {
                return View("New").Warning("Error: El formulario no corresponde al modelo Alumno");
            }

        }

        public ActionResult ViewAlumno(int id_alumno)
        {
            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);

            alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);

            ViewBag.Alumno = alumno;

            ViewBag.Nacimiento = alumno.nacimiento.ToString("yyyy-MM-dd"); ;

            return View("View");
        }

        public ActionResult EditAlumno(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Alumno = alumno;
                alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);
                ViewBag.Nacimiento = alumno.nacimiento.ToString("yyyy-MM-dd");

                try
                {
                    Alumno persisted = alumnoDAO.getAlumnoById(alumno.id);

                    if(alumno.Equals(persisted))
                    {                        
                        return View("View").Warning("Error: No se ha realizado ningún cambio a los datos del alumno");
                    }

                    alumno = alumnoDAO.updateAlumno(alumno);
                    alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);
                    ViewBag.Alumno = alumno;
                    ViewBag.Nacimiento = alumno.nacimiento.ToString("yyyy-MM-dd");
                    return View("View").Information("Se ha modificado el alumno correctamente");
                }
                catch (Exception e)
                {                    
                    return View("View").Warning("Error: " + e.Message);
                }
            }
            else
            {                
                return View("Index").Warning("Error: El formulario no corresponde al modelo Alumno");
            }

        }

        public ActionResult DeleteAlumno(int id_alumno)
        {            
            try
            {
                alumnoDAO.deleteAlumno(id_alumno);
                return RedirectToAction("Index").Information("Se ha eliminado el alumno y todos sus cursos");                    
            }
            catch (Exception e)
            {
                return View("Index").Warning("Error: " + e.Message);
            }                        

        }

        public ActionResult TakeAlumno(int id_alumno)
        {
            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);

            List<Anyo> anyos = anyoDAO.getAllAnyos();

            List<Bimestre> bimestres = bimestreDAO.getAllBimestres();

            ViewBag.Anyos = anyos;

            ViewBag.Bimestres = bimestres;            

            ViewBag.Alumno = alumno;

            return View("Take");
        }


        public ActionResult TakeCurso(int id_alumno, int id_curso)
        {
            Alumno alumno = alumnoDAO.getAlumnoById(id_alumno);
            Curso curso = cursoDAO.getCursoById(id_curso);
            Matricula matricula = null;

            try
            {
                matricula = matriculaDAO.createMatricula(alumno, curso);                
                alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);
                ViewBag.Alumno = alumno;
                ViewBag.Nacimiento = alumno.nacimiento.ToString("yyyy-MM-dd");
                return View("View").Information("Se ha tomado el curso " + curso.codigo + " correctamente");                
            }
            catch (Exception e)
            {                
                List<Anyo> anyos = anyoDAO.getAllAnyos();
                List<Bimestre> bimestres = bimestreDAO.getAllBimestres();
                ViewBag.Anyos = anyos;
                ViewBag.Bimestres = bimestres;
                ViewBag.Alumno = alumno;
                alumno.matriculas = matriculaDAO.getMatriculasByAlumno(alumno);
                return View("Take").Warning("Error: " + e.Message);
            }
            
        }


    }
}