$(document).ready(function () {

    $('#alumnos').DataTable({
        "columnDefs": [
            { "visible": false, "targets": 0 },
        ],
        "drawCallback": function (settings) {
            $('#alumnos').show();
        }
    });  


    $('#matriculas').DataTable({
        "columnDefs": [
            { "visible": false, "targets": 0 },
        ]
    });
    
});