namespace _NetWebApi.Models
{
    public class Produto {

        public Produto() {}

        public Produto(int id, string nome, double preco) {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
    }
}