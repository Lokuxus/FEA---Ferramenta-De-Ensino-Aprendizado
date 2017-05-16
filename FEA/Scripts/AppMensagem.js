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

    $(document).on("click", ".btn-add-arvore", function () {
        var Turma   = document.getElementById('txtTurma').value; 
        var Materia = document.getElementById('txtMateria').value;

        swal({
            title: "Cadastrar arvores?",
            text: "Você deseja cadastrar a Materia: " + Materia + " Turma: " + Turma,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Confirmar",
            cancelButtonText: "Cancelar",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                        var url = "/Arvore/SalvaCadastroArvore/";
                        $.post({
                            type: "GET",
                            url: url,
                            data: { materia: Materia, turma: Turma },
                            success: function (date) {
                                swal("Materia Cadastrada!", "Materia cadatrada com sucesso", "success");
                                window.location = "/Arvore/Arvores";
                            }
                        });
                } else {
                    
                    window.location = "/Arvore/Arvores";
                }
            });
    });

    $(document).on("click", ".btn-resolver", function () {

        var questao = $(this).data("questao");
        var respA   = $(this).data("respostaa");
        var respB   = $(this).data("respostab");
        var respC   = $(this).data("respostac");
        
        
        swal({

            title: "<small>Responda a questão " + questao + " </small>",
            type: "warning",

            //text: "<input type=\"radio\" name=\"reason\" value=\"male\">" + respA + " < br > <input type=\"radio\" name=\"reason\" value=\"female\">" + respB + " < br > <input type=\"radio\" name=\"reason\" value=\"female\">"+ respC + " ",
            text: "A: " + respA + " <br> " + "B: " + respB + " <br> " + "C: " + respC,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false,
            html: true
    },
            function(isConfirm) {
                if (isConfirm){
                    swal("Resultado","Falta Validar.");
                } else {
                    swal("Cancelado", " ");
                }
            });
    });

});