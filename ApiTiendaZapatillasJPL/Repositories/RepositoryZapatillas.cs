using ApiTiendaZapatillasJPL.Data;
using ApiTiendaZapatillasJPL.Helper;
using Microsoft.EntityFrameworkCore;
using NuggetTiendaZapatillasJPL.Models;

namespace ApiTiendaZapatillasJPL.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        //FUNCION PARA SACAR TODAS LAS ZAPATILLAS
        public async Task<List<Zapatilla>> GetZapatillassAsync()
        {
            return await this.context.Zapatillas.ToListAsync();

        }

        //FUNCION PARA LOS DETALLES
        public async Task<Zapatilla> FindZapatillaAsync(int id)
        {
            return await this.context.Zapatillas
            .FirstOrDefaultAsync(x => x.IdZapatilla == id);
        }

        //FUNCION PARA SACAR ZAPATILLAS Y CATEGORIA
        public async Task <List<VistaZapatillasCategoria>> zapatillasCategoria(string nombreCategoria)
        {
            return await this.context.ZapatillasCategoria
            .Where(x => x.NombreCategoria == nombreCategoria).ToListAsync();
        }

        //FUNCION PARA INSERTAR COMPRA
        public async Task InsertVentasAsync
        (string numerotarjeta, string nombre, string apellidos, string direccion, string email, 
            string tel, int cp)
        {
            Compra compra = new Compra();
            compra.NumeroTarjeta = numerotarjeta;
            compra.Nombre = nombre;
            compra.Apellidos = apellidos;
            compra.Direccion = direccion;
            compra.Email = email;
            compra.NumeroTelefono= tel;
            compra.CodigoPostal = cp;
            this.context.Compras.Add(compra);
            await this.context.SaveChangesAsync();
        }

    }
}
