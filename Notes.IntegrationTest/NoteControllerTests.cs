using Notes.Application.Notes.Queries.GetNoteList;
using Notes.IntegrationTests.Utilities;
using Notes.WebApi;
using System.Net;

namespace Notes.IntegrationTests;

public class NoteControllerTests()
{
    private readonly CustomWebApplicationFactory<Startup> factory = new();

    [Fact]
    public async Task GetOrdersCount_SendRequest_ShouldReturnActualOrdersCount()
    {
        // Arrange

        int countTake = 10;
        int countSkip = 0;
        
        var httpClient = factory.CreateClient();

        //Act

        var response = await httpClient.GetJsonResultAsync<List<NoteItemVm>>($"api/v1/Note/{countSkip}/{countTake}", HttpStatusCode.OK);

        // Assert

        Assert.Equal(10, response.Count);
    }
}