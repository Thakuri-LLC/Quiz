using Dapper;
using Microsoft.OpenApi.Models;
using ViewModel;
using WebAPI.Services;

namespace WebAPI.EndPoints
{
    public static class CommonEndpoints
    {
        private const string BASE_ENDPOINT = "Common";

        public static void ConfigureCommonEndPoints(this WebApplication app)
        {
            app.MapGroup(BASE_ENDPOINT)
                .MapGet("/StartNextSession", (DatabaseService db) =>
                {
                    var sessionID = DateTime.Now.Ticks;
                    var query = @"
                    insert into dbo.QuizLog
                    (SessionID, QuizID)
                    select @sessionID, QuizID from qz.Quiz";
                    using (var quizDb = db.GetConnection())
                    {
                        quizDb.Query<QuizViewModel>(query, new { sessionID });
                    }
                    return sessionID;
                })
            .WithName("StartNextSession")
            .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
            {
                Summary = "Start next session using current date time",
                Description = "",
                Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = BASE_ENDPOINT } }
            });
        }
    }
}
