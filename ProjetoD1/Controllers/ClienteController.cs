using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjetoD1.Interfaces.Repository;
using ProjetoD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoD1.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var clientes = await _repository.GetAll();
                return Ok(clientes);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro ao listar clientes");
            }
          
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var clientes = await _repository.GetByName(name);
                if (clientes.Count() <= 0 )
                {
                    return NotFound();
                }
                return Ok(clientes);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro ao listar clientes");
            }
            
        }


        [HttpGet("id/{idCliente}")]
        public async Task<IActionResult> GetById([FromRoute] string idCliente)
        {
            try
            {
                var clientes = await _repository.GetById(idCliente);
                if (clientes == null)
                {
                    return NotFound();
                }
                return Ok(clientes);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro ao listar clientes");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Create(ClienteModel cliente)
        {
            try
            {
                await _repository.Create(cliente);
                return Created("/", cliente);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao cadastrar um novo cliente");
            }
            
        }


        [HttpPut("{idCliente}")] //--Atualizo o objeto inteiro
        public async Task<IActionResult> Atualizar([FromRoute] string idCliente, [FromBody] ClienteModel clienteInput)
        {
            try
            {
                var cliente = await _repository.GetById(idCliente);
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado");
                }
                
                await _repository.Update(clienteInput);
                return Ok(clienteInput);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar o cliente");
            }
        }


    }
}
