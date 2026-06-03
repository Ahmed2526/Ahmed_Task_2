using System.ComponentModel.DataAnnotations.Schema;

namespace Ahmed_Task_2.Web.Models
{
    public class TaxSubType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(TaxType))]
        public int TaxTypeId { get; set; }
        public TaxType TaxType { get; set; }
    }
}
