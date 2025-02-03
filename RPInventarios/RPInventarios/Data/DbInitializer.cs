using RPInventarios.Models;

namespace RPInventarios.Data;

public static class DbInitializer
{
    public static void Initialize(InventariosContext context)
    {
        //checkamos si existe alguna marca
        if (context.Marcas.Any())
        {
            return; //la base de datos a sido inicializada con informacion
        }
        var marcas = new Marca[]
        {
            new Marca {Nombre = "Rino"},
            new Marca {Nombre = "Rocco"},
            new Marca {Nombre = "Azuri"},
            new Marca {Nombre = "Reni"},
            new Marca {Nombre = "Bazy"},
            new Marca {Nombre = "Asis"},

        };

        context.Marcas.AddRange(marcas);
        context.SaveChanges();

        var departamentos = new Departamento[] {
            new Departamento {Nombre = "Administracion General"},
            new Departamento {Nombre = "Recursos Humanos"},
            new Departamento {Nombre = "Recursos Materiales "},
            new Departamento {Nombre = "Informatica"},
            new Departamento {Nombre = "Deportes"},
        };

        context.Departamentos.AddRange(departamentos);
        context.SaveChanges();


        var productos = new Producto[]
        {
            new Producto
            {
                Nombre = "Silla secretarial",
                Descripcion = "Silla de imitacion de piel secreatarial",
                MarcaId = context.Marcas.First(u => u.Nombre == "Rino").Id,
                Costo = 2500M
            },
            new Producto
            {
                Nombre = "Escritorio Gerencial",
                Descripcion = "Escritorio negro de criztal",
                MarcaId = context.Marcas.First(u => u.Nombre == "Azuri").Id,
                Costo = 2500M
            },
            new Producto
            {
                Nombre = "Cafetera Industrial  ",
                Descripcion = "Cafetera para 50 tazas",
                MarcaId = context.Marcas.First(u => u.Nombre == "Rocco").Id,
                Costo = 2500M
            },
            new Producto
            {
                Nombre = "Computadora   ",
                Descripcion = "Computadora Gamer",
                MarcaId = context.Marcas.First(u => u.Nombre == "Asis").Id,
                Costo = 267500M
            },
            new Producto
            {
                Nombre = "Proyector   ",
                Descripcion = "Proyector Inalambrico ",
                MarcaId = context.Marcas.First(u => u.Nombre == "Reni").Id,
                Costo = 67500M
            }
        };
        context.Productos.AddRange(productos);
        context.SaveChanges();
    }
}