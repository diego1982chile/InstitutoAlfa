using System.Web;
using System.Web.Optimization;

namespace InstitutoAlfa
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));            

            // Datatables            
            bundles.Add(new ScriptBundle("~/bundles/datatablesjs").Include(
                 "~/Scripts/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatablescss").Include(
                        "~/Content/datatables.min.css"));

            // Datatables            
            bundles.Add(new ScriptBundle("~/bundles/loadingoverlay").Include(
                 "~/Scripts/loadingOverlay.js"));

            // Alumnos            
            bundles.Add(new ScriptBundle("~/bundles/alumnosindexjs").Include(
                 "~/Scripts/alumnos-index.js"));

            // Cursos            
            bundles.Add(new ScriptBundle("~/bundles/cursosindexjs").Include(
                 "~/Scripts/cursos-index.js"));            
        }
    }
}
