namespace FullStack0507.MyWebApi.Dtos
{
    public class AddProductRequest
    {
        public decimal price { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string barcode { get; set; }
    }
}
