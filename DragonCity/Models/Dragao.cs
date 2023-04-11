namespace DragonCity.Models;

public class dragoes
{
    //Atributos
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Tipo { get; set; }
    public double Dano { get; set; }
    public string Imagem { get; set; }

    // Método Construtor
    public dragoes()
    {
        Tipo = new List<string>();
    }
}
