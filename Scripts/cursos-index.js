
$(document).ready(function () {



    $('#cursos').DataTable({
        "columnDefs": [
            { "visible": false, "targets": 0 },
            {
                "targets": 5,
                //"data": "download_link",
                "render": function (data, type, row, meta) {
                    //console.log(row[0]);
                    return '<a href="/Curso/ViewCurso?id_curso=' + row[0] + '">' + data + '</a>';
                    //return '<a href="Curso/ViewCurso/' + row[0] + '">' + data + '</a>';
                }
            },
            {
                "targets": 6,
                //"data": "download_link",
                "render": function (data, type, row, meta) {
                    //console.log(row[0]);
                    if (row[5] == 'Abierto') {
                        return '<a href="/Alumno/TakeCurso?id_alumno=' + row[0] + '&id_curso=' +  +'">Tomar</a>';
                    }
                    else {
                        return 'No Disponible';
                    }

                    //return '<a href="Curso/ViewCurso/' + row[0] + '">' + data + '</a>';
                }
            }
        ]
    });

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

    var url = "/Curso/GetCursos?id_anyo=" + id_anyo + "&id_bimestre=" + id_bimestre;    
    
    $.getJSON(url, null, function (json) {

        loadingOverlay().cancel(spinHandle);
        
        var data = [];

        $(json).each(function () {
            console.log(JSON.stringify(this));
            
            var registry = [];
            registry.push(this.id);
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

 