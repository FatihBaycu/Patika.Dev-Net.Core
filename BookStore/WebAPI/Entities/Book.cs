using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int GenreId { get; set; }
    public int PageSize { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }

}
