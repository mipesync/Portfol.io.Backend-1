﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfol.io.Application.Aggregate.Albums.Commands.CreateAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.DeleteAlbumCover;
using Portfol.io.Application.Aggregate.Albums.Commands.LikeAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.MarkAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.RemoveAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbum;
using Portfol.io.Application.Aggregate.Albums.Commands.UpdateAlbumCover;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByTags;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumsByUserId;
using Portfol.io.Application.Aggregate.Albums.Queries.GetAllAlbums;
using Portfol.io.Application.Aggregate.Albums.Queries.GetMarkedAlbums;
using Portfol.io.Application.Aggregate.Albums.Queries.SearchAlbum;
using Portfol.io.Application.Models;
using CreateAlbumDto = Portfol.io.Application.Models.CreateAlbumDto;

namespace Portfol.io.WebAPI.Controllers
{
    /// <summary>
    /// The album controller, which contains all the logic for working with albums.
    /// </summary>
    //[Authorize]
    public class AlbumController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public AlbumController(IMapper mapper, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAlbums()
        {
            var result = await Mediator.Send(new GetAllAlbumsQuery { UserId = UserId, Url = UrlRaw });

            return Ok(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid albumId)
        {
            var query = new GetAlbumByIdQuery { Id = albumId, UserId = UserId, Url = UrlRaw };

            var album = await Mediator.Send(query);

            return Ok(album);
        }

        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var query = new GetAlbumsByUserIdQuery 
            { 
                UserId = userId, 
                AUserId = UserId,
                Url = UrlRaw
            };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getByTags")]
        public async Task<IActionResult> GetByTags([FromQuery] IEnumerable<Guid> tagIds)
        {
            var query = new GetAlbumsByTagsQuery { TagIds = tagIds, Url = UrlRaw };
            query.UserId = UserId;

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getMarked")]
        public async Task<IActionResult> GetMarked()
        {
            var result = await Mediator.Send(new GetMarkedAlbumsQuery { UserId = UserId, Url = UrlRaw });

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateAlbumDto createAlbumDto)
        {
            if (!ModelState.IsValid) return BadRequest(new {message = "Model is not valid."});

            var command = _mapper.Map<CreateAlbumCommand>(createAlbumDto);
            command.UserId = UserId;

            var guid = await Mediator.Send(command);
            return Ok(new {albumId = guid });
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateAlbumDto updateAlbumDto)
        {
            if (!ModelState.IsValid) return BadRequest(new { message = "Model is not valid." });

            await Mediator.Send(_mapper.Map<UpdateAlbumCommand>(updateAlbumDto));
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid albumId)
        {
            await Mediator.Send(new RemoveAlbumCommand { Id = albumId });
            return Ok();
        }

        [HttpPost("like")]
        public async Task<IActionResult> Like(Guid albumId)
        {
            await Mediator.Send(new LikeAlbumCommand { UserId = UserId, AlbumId = albumId });
            return Ok();
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await Mediator.Send(new SearchAlbumQuery
            {
                Query = query.ToLower(),
                UserId = UserId
            });

            return Ok(result);
        }

        [HttpPut("updateCover")]
        public async Task<IActionResult> UpdateCover(IFormFile file, Guid AlbumId)
        {
            var command = new UpdateAlbumCoverCommand
            {
                AlbumId = AlbumId,
                Image = file,
                WebRootPath = _environment.WebRootPath,
                UserId = UserId
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("deleteCover")]
        public async Task<IActionResult> DeleteCover(Guid AlbumId)
        {
            var command = new DeleteAlbumCoverCommand
            {
                AlbumId = AlbumId,
                WebRootPath = _environment.WebRootPath
            };

            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("markAlbum")]
        public async Task<IActionResult> MarkAlbum(Guid AlbumId)
        {
            var command = new MarkAlbumCommand
            {
                AlbumId = AlbumId,
                UserId = UserId
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}
