using GakkoHorizontalSlice.Services;
using Microsoft.AspNetCore.Mvc;

namespace GakkoHorizontalSlice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController:ControllerBase
{
    private IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteClient(int id)
    {
        var count = _clientService.DeleteClient(id);
        return NoContent();
    }
}