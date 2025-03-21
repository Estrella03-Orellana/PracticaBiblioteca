﻿using System;
using System.Collections.Generic;

namespace PracticaBiblioteca.AppWebMVC.Models;

public partial class Editorial
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
