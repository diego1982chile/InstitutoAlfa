using InstitutoAlfa.DAOs;
using InstitutoAlfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstitutoAlfa.Controllers
{    

    public class CursoController : Controller
    {

        private readonly AnyoDAO anyoDAO = new AnyoDAO();

        private readonly BimestreDAO bimestreDAO = new BimestreDAO();

        private readonly CursoDAO cursoDao = new CursoDAO();

        // GET: Curso
        public ActionResult Index()
        {            
            List<Anyo> anyos = anyoDAO.getAllAnyos();

            List<Bimestre> bimestres = bimestreDAO.getAllBimestres();

            ViewBag.Anyos = anyos;

            ViewBag.Bimestres = bimestres;

            return View();
        }

        public JsonResult GetCursos(int id_anyo, int id_bimestre)
        {
            Anyo anyo = anyoDAO.getAnyoById(id_anyo);

            Bimestre bimestre = bimestreDAO.getBimestreById(id_bimestre);

            List<Curso> cursos = cursoDao.getCursosByAnyoAndBimestre(anyo, bimestre);

            //List<Student> students = new List<Student>();
            //students = context.Students.ToList();

            return Json(cursos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewCurso(int id_curso)
        {
            Curso curso = cursoDao.getCursoById(id_curso);

            //List<Curso> cursos = cursoDao.getCursosByAnyoAndBimestre(anyo, bimestre);

            //List<Student> students = new List<Student>();
            //students = context.Students.ToList();

            ViewBag.Curso = curso;

            return View("View");
        }
    }
}