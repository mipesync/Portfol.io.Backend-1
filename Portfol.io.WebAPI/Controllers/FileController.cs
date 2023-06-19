using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Files.Commands.AddImage;
using Portfol.io.Application.Aggregate.Files.Commands.DeleteImage;
using Portfol.io.Application.Aggregate.Files.Queries.GetImageByAlbumId;
using Portfol.io.Application.Aggregate.Files.Queries.GetImageById;
using Portfol.io.Application.Models;

namespace Portfol.io.WebAPI.Controllers
{
    //[Authorize]
    public class FileController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public FileController(IMapper mapper, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("getByAlbumId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByAlbumId(Guid albumId)
        {
            var result = await Mediator.Send(new GetImagesByAlbumIdQuery { AlbumId = albumId });

            foreach(var photo in result.Images!)
            {
                photo.Path = $"{UrlRaw}{photo.Path}";
            }

            return Ok(result);
        }

        [HttpGet("getById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid PhotoId)
        {
            var photo = await Mediator.Send(new GetImageByIdQuery { Id = PhotoId });
            photo.Path = $"{UrlRaw}{photo.Path}";

            return Ok(photo);
        }

        [HttpPost("addToAlbum")]
        public async Task<IActionResult> AddToAlbum([FromForm] AddToAlbumDto addToAlbumDto)
        {
            var command = _mapper.Map<AddImageCommand>(addToAlbumDto);
            command.WebRootPath = _environment.WebRootPath;

            var guid = await Mediator.Send(command);

            return Ok(new { photoId = guid });
        }

        [HttpPost("deleteFromAlbum")]
        public async Task<IActionResult> DeleteFromAlbum([FromForm] DeleteFromAlbumDto deleteFromAlbumDto)
        {
            var command = _mapper.Map<DeleteImageCommand>(deleteFromAlbumDto);
            command.WebRootPath = _environment.WebRootPath;

            await Mediator.Send(command);
            return Ok();
        }
    }
}
