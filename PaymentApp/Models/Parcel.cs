using System.Data;

namespace PaymentApp.Models
{
    public class Parcel
    {
        public DataSetDateTime initial { get; set; }
        public DataSetDateTime final { get; set; }
    }
}