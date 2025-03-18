using System;
using System.Collections.Generic;

namespace PracticaBiblioteca.AppWebMVC.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public DateTime? UltimoInicioSesion { get; set; }

    public byte? Estatus { get; set; }
}
