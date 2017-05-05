$(document).ready(function () {
    $(document).on("click", ".btn-remover", function () {
        var teste = $(this).data("batata");
        var diciplina = $(this).data("diciplina");

        swal({
            title: "Remover Diciplina",
            text: "Voce tem certeza que deseja remover a Diciplina de  " + diciplina,
              type: "warning",
              showCancelButton: true,
              confirmButtonColor: "#DD6B55",
              confirmButtonText: "Sim",
              closeOnConfirm: false
        },
            function () {
                var url = "/Arvore/DeletaMateria/";
                $.post({
                    type: "GET",
                    url: url, 
                    data: { idMateria: teste },
                    success: function (date) {
                        swal("Material Deletada", "Materia deletada", "success");
                        window.location = "/Arvore/Arvores";
                    }   
                });
            });
    });
});