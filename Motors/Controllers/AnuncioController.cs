using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motors.Application.Interface;
using Motors.Domain.Entidades;
using Motors.ViewModel;
using System;
using System.Collections.Generic;

namespace Motors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IMapper _IMapper;
        private readonly IAppAnuncioWebmotors _IAppAnuncioWebmotors;

        public AnuncioController(IAppAnuncioWebmotors IAppAnuncioWebmotors, IMapper IMapper)
        {
            _IMapper = IMapper;
            _IAppAnuncioWebmotors = IAppAnuncioWebmotors;
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        [Route("ListaTodosAnuncios")]
        public IActionResult ListaTodosAnuncios()
        {
            try
            {
                var lista = _IAppAnuncioWebmotors.ListAll(false);

                var _listAnuncios = _IMapper.Map<List<TbAnuncioWebmotors>, List<AnuncioWebmotorsViewModel>>(lista);

                return Ok(_listAnuncios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [EnableCors("AllowOrigin")]
        [Route("ObterAnuncioPorID")]
        public IActionResult ObterAnuncioPorID(int ID)
        {
            try
            {
                var anuncio = _IAppAnuncioWebmotors.GetById(ID);

                var _anuncio = _IMapper.Map<TbAnuncioWebmotors, AnuncioWebmotorsViewModel>(anuncio);

                return Ok(_anuncio);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [EnableCors("AllowOrigin")]
        [Route("CadastrarAnuncio")]
        public IActionResult CadastrarAnuncio(AnuncioWebmotorsViewModel AnuncioViewModel)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(AnuncioViewModel.Marca))
                    return StatusCode(StatusCodes.Status400BadRequest, "Código invalido");

                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Modelo))
                    return StatusCode(StatusCodes.Status400BadRequest, "Modelo invalido");

                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Versao))
                    return StatusCode(StatusCodes.Status400BadRequest, "Versao invalido");

                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Observacao))
                    return StatusCode(StatusCodes.Status400BadRequest, "Observacao invalido");

                var anuncio = _IMapper.Map<AnuncioWebmotorsViewModel, TbAnuncioWebmotors>(AnuncioViewModel);

                _IAppAnuncioWebmotors.Add(anuncio);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut]
        [EnableCors("AllowOrigin")]
        [Route("EditarAnuncio")]
        public IActionResult EditarAnuncio(AnuncioWebmotorsViewModel AnuncioViewModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Marca))
                    return StatusCode(StatusCodes.Status400BadRequest, "Código invalido");

                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Modelo))
                    return StatusCode(StatusCodes.Status400BadRequest, "Modelo invalido");

                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Versao))
                    return StatusCode(StatusCodes.Status400BadRequest, "Versao invalido");

                if (string.IsNullOrWhiteSpace(AnuncioViewModel.Observacao))
                    return StatusCode(StatusCodes.Status400BadRequest, "Observacao invalido");

                var anuncio = _IMapper.Map<AnuncioWebmotorsViewModel, TbAnuncioWebmotors>(AnuncioViewModel);

                _IAppAnuncioWebmotors.Update(anuncio);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [EnableCors("AllowOrigin")]
        [Route("DeletarAnuncio")]
        public IActionResult DeletarAnuncio(int ID)
        {
            try
            {
                if (ID <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Código invalido");

                _IAppAnuncioWebmotors.Delete(ID);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}