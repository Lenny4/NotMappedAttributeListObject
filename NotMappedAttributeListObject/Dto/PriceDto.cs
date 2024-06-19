using System.ComponentModel.DataAnnotations.Schema;

namespace NotMappedAttributeListObject.Model
{
    [NotMapped]
    public class PriceDto
    {
        public short? SomeValue { get; set; }
    }
}
