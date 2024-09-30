using WebAPI.EndPoints;

namespace WebAPI
{
    public static class ConfigureApp
    {
        public static void Configure(this WebApplication app)
        {      
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Endpoints
            app.ConfigureCommonEndPoints();
            app.ConfigureGeographyEndPoints();            
        }
    }
}
