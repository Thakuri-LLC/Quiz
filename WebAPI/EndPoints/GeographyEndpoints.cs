using Dapper;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ViewModel;
using WebAPI.Services;

namespace WebAPI.EndPoints
{
    public static class GeographyEndpoints
    {
        private const string BASE_ENDPOINT = "Geography";

        public static void ConfigureGeographyEndPoints(this WebApplication app)
        {
            // Get Next Quiz
            app.MapGroup(BASE_ENDPOINT)
                .MapGet("/Next/{sessionID}", (long sessionID, DatabaseService db) =>
                {
                    var query = @"
                    select top 4
                        q.QuizID,
	                    q.Question,
	                    cqo.QuizOptionID, 
                        cqo.QuizOptionName,
                        qo.QuizOptionID, 
                        qo.QuizOptionName	
                    from dbo.QuizLog ql
                    join qz.Quiz q on q.QuizID = ql.QuizID
                    join qz.QuizOption qo on qo.QuizID = q.QuizID
                    join qz.QuizOption cqo on cqo.QuizID = q.QuizID
                    where SessionID = @sessionID and ql.OptionID is null
                    order by ql.QuizLogID";

                    using (var quizDb = db.GetConnection())
                    {
                        var quiz = quizDb.Query<QuizViewModel, QuizOptionViewModel, QuizOptionViewModel, QuizViewModel >(query, 
                            (qz, cqo, qo) =>
                            {
                                qz.CorrectOption = cqo;
                                qz.Options.Add(qo);
                                return qz;
                            },
                            splitOn: "QuizOptionID, QuizOptionID",
                        param: new { @sessionID });

                        var result = quiz.GroupBy(p => p.QuizID).Select(g =>
                        {
                            var groupedPost = g.First();
                            groupedPost.Options = g.SelectMany(p => p.Options).ToList();
                            return groupedPost;
                        });

                        return result.FirstOrDefault();
                    }
                })
            .WithName("GetNextGeographyChallenge")
            .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
            {
                Summary = "Get next question of geography",
                Description = "",
                Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = BASE_ENDPOINT } }
            });

            // Select Quiz Option
            app.MapGroup(BASE_ENDPOINT)
                .MapGet("/Next/{sessionID}/{quizID}/{quizOptionID}", (long sessionID, int quizID, int quizOptionID, DatabaseService db) =>
                {
                    var query = @"
                    select top 4
                        q.QuizID,
	                    q.Question,
	                    cqo.QuizOptionID, 
                        cqo.QuizOptionName,
                        qo.QuizOptionID, 
                        qo.QuizOptionName	
                    from dbo.QuizLog ql
                    join qz.Quiz q on q.QuizID = ql.QuizID
                    join qz.QuizOption qo on qo.QuizID = q.QuizID
                    join qz.QuizOption cqo on cqo.QuizID = q.QuizID
                    where SessionID = @sessionID and ql.OptionID is null
                    order by ql.QuizLogID";

                    using (var quizDb = db.GetConnection())
                    {
                        var quiz = quizDb.Query<QuizViewModel, QuizOptionViewModel, QuizOptionViewModel, QuizViewModel>(query,
                            (qz, cqo, qo) =>
                            {
                                qz.CorrectOption = cqo;
                                qz.Options.Add(qo);
                                return qz;
                            },
                            splitOn: "QuizOptionID, QuizOptionID",
                        param: new { @sessionID });

                        var result = quiz.GroupBy(p => p.QuizID).Select(g =>
                        {
                            var groupedPost = g.First();
                            groupedPost.Options = g.SelectMany(p => p.Options).ToList();
                            return groupedPost;
                        });

                        return result.FirstOrDefault();
                    }
                })
            .WithName("GetNextGeographyChallenge")
            .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
            {
                Summary = "Get next question of geography",
                Description = "",
                Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = BASE_ENDPOINT } }
            });
        }
    }
}
