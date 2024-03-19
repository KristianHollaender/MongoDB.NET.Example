using MongoExample.Core.Models;
using MongoExample.Core.Repositories;

namespace MongoExample.Core.Services;

public class WebEventService
{
    private readonly WebEventRepository _webEventRepository;
    
    public WebEventService(WebEventRepository webEventRepository)
    {
        _webEventRepository = webEventRepository;
    }
    
    public WebEventModel GetEvent(string id){
        return _webEventRepository.GetById(id);
    }
    
    public List<WebEventModel> GetEvents(){
        return _webEventRepository.GetEvents();
    }
    
    public void SaveEvent(WebEventModel webEvent){
        _webEventRepository.InsertOne(webEvent);
    }
    
    public void SaveEvents(IEnumerable<WebEventModel> webEvents){
        _webEventRepository.InsertMany(webEvents);
    }
}