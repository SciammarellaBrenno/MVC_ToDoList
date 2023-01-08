using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ToDoList.Models;

[Table("List")]
public class ListModel
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Anotacao { get; set; }

    public ListModel()
    {

    }

    public ListModel(string titulo, string anotacao) { 
        
        Titulo = titulo;
        Anotacao = anotacao;
    }
}
