
$(document).ready(function() {

    $('#cursos').DataTable()

    $('#seleccion').on('submit', function (e) {
        e.preventDefault();
        e.stopPropagation();
    });    

    $("#consultar").click(function () {
        consultar();
    });

});

function consultar() {

    if ($("#anyo").val() == 0 || $("#bimestre").val() == "") {
        alert("Debe seleccionar año y bimestre");
        return false;
    }

    var spinHandle = loadingOverlay().activate();    

    var id_anyo = $("#anyo").val();

    var id_bimestre = $("#bimestre").val();

    var url = "Curso/GetCursos/" + id_anyo + "/" + id_bimestre;    
    
    $.getJSON(url, null, function (json) {

        loadingOverlay().cancel(spinHandle);
        
        var data = [];

        $(json).each(function () {
            console.log(JSON.stringify(this));
            
            var registry = [];
            registry.push(this.codigo);
            registry.push(this.asignatura.nombre);
            registry.push(this.profesor.nombre);
            registry.push(this.sala.codigo);        
            registry.push(this.estado);
            data.push(registry);                        
        });
        
        $('#cursos').dataTable().fnClearTable();
        $('#cursos').dataTable().fnAddData(data);
    });    
    
}

 