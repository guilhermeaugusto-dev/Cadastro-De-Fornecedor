// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    const $cep = $("#cep");
    const $end = $("#endereco");
    const $cepMsg = $("[data-valmsg-for='CEP']");

    function onlyDigits(v) {
        return (v || "").replace(/\D/g, "").slice(0, 8);
    }

    function preencherEnderecoPorCep(cep) {
        if (cep.length !== 8) return;

        $end.prop("disabled", true);
        $cepMsg.text("");

        fetch(`https://viacep.com.br/ws/${cep}/json/`)
            .then(r => r.json())
            .then(d => {
                if (d.erro) {
                    $end.val("");
                    $cepMsg.text("CEP não encontrado.");
                    return;
                }

                const log = d.logradouro || "";
                const bai = d.bairro || "";
                const loc = d.localidade || "";
                const uf = d.uf || "";

                let endereco = [log, bai].filter(Boolean).join(", ");
                const cidadeUf = [loc, uf].filter(Boolean).join("/");

                if (cidadeUf) {
                    endereco = endereco ? `${endereco} - ${cidadeUf}` : cidadeUf;
                }

                if (endereco.length > 255) {
                    endereco = endereco.substring(0, 255);
                }

                $end.val(endereco);
            })
            .catch(() => {
                $cepMsg.text("Erro ao consultar CEP.");
            })
            .finally(() => {
                $end.prop("disabled", false);
            });
    }

    $cep.on("input", function () {
        const v = onlyDigits(this.value);
        if (this.value !== v) this.value = v;
        if (v.length === 8) preencherEnderecoPorCep(v);
    });

    $end.attr("maxlength", "255");
});
