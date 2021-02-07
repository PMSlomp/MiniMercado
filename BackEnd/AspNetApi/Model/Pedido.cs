namespace BackEnd.AspNetApi.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Data { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }
        public decimal PrecoFinal { get; set; }
        
    }
}