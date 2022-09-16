using CursoArquitecturaNet.DTOs.Base;

namespace CursoArquitecturaNet.DTOs
{
    public class ProductDto : BaseDto
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
    }
}
