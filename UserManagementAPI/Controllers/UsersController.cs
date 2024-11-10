using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagementAPI.DTOs;
using UserManagementAPI.Interfaces;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult> GetUserProfile()
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserProfile(userEmail);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("profile")]
        public async Task<ActionResult> UpdateUserProfile(UserDto user)
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                user.Email = userEmail;
                await _unitOfWork.UserRepository.UpdateUserProfile(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPatch("profile")]
        public async Task<ActionResult> UpdateUserProfile(JsonPatchDocument<UserDto> patchDocument)
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                await _unitOfWork.UserRepository.UpdateUserProfilePatch(userEmail, patchDocument);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
