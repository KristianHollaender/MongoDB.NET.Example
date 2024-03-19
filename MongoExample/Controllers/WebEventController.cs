using Microsoft.AspNetCore.Mvc;
using MongoExample.Core.Models;
using MongoExample.Core.Services;

namespace MongoExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WebEventController : ControllerBase
{
    private readonly WebEventService _webEventService;
    
    public WebEventController(WebEventService webEventService)
    {
        _webEventService = webEventService;
    }
    
    [HttpGet]
    public WebEventModel GetEventById(string id)
    {
        return _webEventService.GetEvent(id);
    }

    [HttpGet("GetEvents")]
    public List<WebEventModel> GetEvents()
    {
        return _webEventService.GetEvents();
    }
    
    [HttpPost]
    public void SaveEvent([FromBody] WebEventModel webEvent)
    {
        _webEventService.SaveEvent(webEvent);
    }
}