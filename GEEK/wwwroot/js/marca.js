var datatable;


$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblMarcas").DataTable({
        "ajax": {
            "url": "/admin/marcas/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idMarca", "width": "20%" },
            { "data": "nombreMarca", "width": "20%" },
            {
                "data": "rutaImagen",
                "render": function (imagen) {
                    return `<img src="../${imagen}" width="180" />`
                },
                "width": "40%"
            },
            {
                "data": "idMarca",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Marcas/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Editar
                            </a>
                         </div>
                     `;
                }, "width": "40%"
            }
        ],

        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}