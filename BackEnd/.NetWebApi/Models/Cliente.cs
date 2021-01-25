namespace _NetWebApi.Models
{
    public class Cliente {
        public int id { get; set; }
        public string nome { get; set; }
        public string mail { get; set; }
        public Cliente() {}
        
        public Cliente (int id, string nome, string mail) {
            this.id = id;
            this.nome = nome;
            this.mail = mail;
        }
        
    }  
}