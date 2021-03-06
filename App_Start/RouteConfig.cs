using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InstitutoAlfa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */

            // Alumnos Routes

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Alumno", action = "Index" }
            );

            routes.MapRoute(
                name: "NewAlumno",
                url: "{controller}/{action}",
                defaults: new { controller = "Alumno", action = "NewAlumno" }
            );

            routes.MapRoute(
                name: "CreateAlumno",
                url: "{controller}/{action}",
                defaults: new { controller = "Alumno", action = "CreateAlumno" }
            );

            routes.MapRoute(
                name: "ViewAlumno",
                url: "{controller}/{action}/{id_alumno}",
                defaults: new { controller = "Alumno", action = "ViewAlumno", id_alumno = "" }
            );

            routes.MapRoute(
                name: "EditAlumno",
                url: "{controller}/{action}",
                defaults: new { controller = "Alumno", action = "EditAlumno" }
            );

            routes.MapRoute(
                name: "DeleteAlumno",
                url: "{controller}/{action}/{id_alumno}",
                defaults: new { controller = "Alumno", action = "DeleteAlumno", id_alumno = "" }
            );

            routes.MapRoute(
                name: "TakeAlumno",
                url: "{controller}/{action}/{id_alumno}",
                defaults: new { controller = "Alumno", action = "TakeAlumno", id_alumno = "" }
            );

            routes.MapRoute(
                name: "TakeCurso",
                url: "{controller}/{action}/{id_alumno}/{id_curso}",
                defaults: new { controller = "Alumno", action = "TakeCurso", id_alumno = "", id_curso = "" }
            );

            // Cursos Routes

            routes.MapRoute(
                name: "Curso",
                url: "{controller}/{action}",
                defaults: new { controller = "Curso", action = "Index" }
            );
            
            routes.MapRoute(
                name: "GetCursos",
                url: "{controller}/{action}/{id_anyo}/{id_bimestre}",
                defaults: new { controller = "Curso", action = "GetCursos", id_anyo = "", id_bimestre = "" }
            );
            
            routes.MapRoute(
                name: "ViewCurso",
                url: "{controller}/{action}/{id_curso}",
                defaults: new { controller = "Curso", action = "ViewCurso", id_curso = "" }
            );            

        }
    }
}
