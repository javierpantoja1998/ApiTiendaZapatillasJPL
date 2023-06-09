﻿using ApiTiendaZapatillasJPL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuggetTiendaZapatillasJPL.Models;

namespace ApiTiendaZapatillasJPL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapatillasController : ControllerBase
    {
        private RepositoryZapatillas repo;

        public ZapatillasController(RepositoryZapatillas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Zapatilla>>> Get()
        {
            return await this.repo.GetZapatillassAsync();
        }

        //FUNCION PARA SACAR LOS DETALLES
        [HttpGet("{id}")]
        public async Task<ActionResult<Zapatilla>> FindZapatilla(int id)
        {
            return await this.repo.FindZapatillaAsync(id);
        }

        [HttpGet]
        [Route("[action]/{nombreCategoria}")]
        public async Task <ActionResult<List<VistaZapatillasCategoria>>> ZapatillasCategoria(string nombreCategoria)
        {
            return await this.repo.zapatillasCategoria(nombreCategoria);
        }


        [HttpPost]
        [Route("[action]/{numerotarjeta}/{nombre}/{apellidos}/{direccion}/{telefono}/{email}/{tel}/{cp}")]
        public async Task<ActionResult> Compra
           (string numerotarjeta, string nombre, string apellidos, string direccion, string email,
            string tel, int cp)
        {
            Compra user = new Compra();
            

            await this.repo.InsertVentasAsync(numerotarjeta, nombre, apellidos, direccion, email, tel,cp);
            
            return Ok();
        }

    }
}
