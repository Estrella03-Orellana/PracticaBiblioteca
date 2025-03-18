using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaBiblioteca.AppWebMVC.Models;

public partial class Libro
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El Titulo es obligatorio" )]
    public string Titulo { get; set; } = null!;

    [Display(Name ="Autor")]
    public int? AutorId { get; set; }

    [Display(Name = "Editorial")]
    public int? EditorialId { get; set; }

    public virtual Autor? Autor { get; set; }

    public virtual Editorial? Editorial { get; set; }

  
}
