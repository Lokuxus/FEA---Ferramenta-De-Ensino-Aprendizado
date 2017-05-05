$(document).ready(function () {
    $(document).on("click", ".btn-remover", function () {
        var teste = $(this).data("batata");

        swal({
              title: "Are you sure?",
              text: "You will not be able to recover this imaginary file!",
              type: "warning",
              showCancelButton: true,
              confirmButtonColor: "#DD6B55",
              confirmButtonText: "Yes, delete it!  " + teste,
              closeOnConfirm: false
        },
            function () {
                var url = "/Arvore/DeletaMateria/";
                $.post({
                    type: "GET",
                    url: url, 
                    data: { idMateria: teste },
                    success: function (date) {
                        window.location = "/Arvore/Arvores";
                        swal("Deleted!", "Your imaginary file has been deleted.", "success");

                    }
                });
            });
    });
});

function Teste(teste) {
    
}