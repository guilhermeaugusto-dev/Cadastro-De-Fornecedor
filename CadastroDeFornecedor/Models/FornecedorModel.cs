using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Estagio.Models
{
    public class FornecedorModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"\d{14}", ErrorMessage = "O CNPJ deve ter 14 números")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O segmento é obrigatório")]
        [RegularExpression(@"^(Comércio|Serviço|Indústria)$", ErrorMessage = "Segmento inválido")]
        public string Segmento { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"\d{8}", ErrorMessage = "O CEP deve ter 8 números")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(255, ErrorMessage = "O endereço pode ter no máximo 255 caracteres")]
        public string Endereco { get; set; }
    
    }
}