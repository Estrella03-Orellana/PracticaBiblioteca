using System;
using System.Collections.Generic;

namespace PracticaBiblioteca.AppWebMVC.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int? AutorId { get; set; }

    public int? EditorialId { get; set; }

    public virtual Autor? Autor { get; set; }

    public virtual Editorial? Editorial { get; set; }

    public virtual ICollection<Genero> Generos { get; set; } = new List<Genero>();
}
