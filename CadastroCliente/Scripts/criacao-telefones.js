$(function () {
    var qtdTelefones = 0;

    $("#btn-add-telefone").click(function (e) {
        e.preventDefault();

        var blocoTelefone = '<div class="row">' +
            '    <div class="col-md-2">' +
			'        <input class="form-control txt-ddd text-box single-line" maxlength="2" name="Telefones[' + qtdTelefones + '].DDD" placeholder="DDD" type="text"/>' +
			'    </div>' +
            '    <div class="col-md-6">' +
			'        <input class="form-control txt-numero text-box single-line" maxlength="10" name="Telefones[' + qtdTelefones + '].Numero"  placeholder="Número" type="text"/>' +
			'    </div>' +
            '    <div class="col-md-1">' +
            '        <button class="btn btn-danger btn-remover-telefone">' +
            '            <span class="glyphicon glyphicon-trash"></span>' +
            '        </button>' +
            '    </div>' +
            '</div>';

        $("#div-telefones").append(blocoTelefone);

        qtdTelefones++;
    });

    $("#div-telefones").on("click", ".btn-remover-telefone", function (e) {
        e.preventDefault();

        $(this).parent().parent().remove();

        qtdTelefones--;

        $("#div-telefones .row").each(function (indice, elemento) {
            $(elemento).find(".txt-ddd").attr("name", "Telefones[" + indice + "].DDD");
            $(elemento).find(".txt-numero").attr("name", "Telefones[" + indice + "].Numero");
        });
    });
});