var datatable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblProductos").DataTable({
        "ajax": {
            "url": "/admin/productos/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idProducto", "width": "10%" },
            { "data": "nombreProducto", "width": "20%" },
            { "data": "precio", "width": "10%" },
            { "data": "marca.nombreMarca", "width": "15%" },
            { "data": "categoria.descripcionCategoria", "width": "15%" },
            { "data": "descripcion", "width": "20%" },
            {
                "data": "idProducto",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Productos/Details/${data}" class="btn btn-warning text-white" style="cursor:pointer; width:140px;">
                                <i class="fa-solid fa-circle-info"></i> Detalles
                            </a>
                            &nbsp;
                            <a href="/Admin/Productos/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-edit"></i> Editar
                            </a>
                            &nbsp;
                            <a href="/Admin/Productos/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer; width:140px;">
                                <i class="far fa-trash-alt"></i> Borrar
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
