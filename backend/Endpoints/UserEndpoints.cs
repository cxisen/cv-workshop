using backend.Data.Mappers;
using backend.Data.Requests;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        // GET /users
        app.MapGet(
                "/users",
                async (ICvService cvService) =>
                {
                    var users = await cvService.GetAllUsersAsync();
                    var userDtos = users.Select(u => u.ToDto()).ToList();

                    return Results.Ok(userDtos);
                }
            )
            .WithName("GetAllUsers")
            .WithTags("Users");

        // GET /users/{id}
        // TODO: Oppgave 1: skriv et endepunkt for å hente ut riktig bruker
        app.MapGet(
                "/users/{id:guid}",
                async (Guid id, ICvService cvService) =>
                {
                    var user = await cvService.GetUserByIdAsync(id);
                     
                    if (user == null)
                        return Results.NotFound("User not found");

                    return Results.Ok(user.ToDto());
                }
        )
        .WithName("GetUser")
        .WithTags("Users");

        // Retrieve all cvs that include any of the wanted skills
        app.MapPost(
                "/users/skills",
                async (SkillRequest skillRequest, ICvService cvService) =>
                {
                    // TODO: Oppgave 4
                    var users = await cvService.GetUsersWithDesiredSkills(skillRequest.WantedSkills);
                    var userDtos = users.Select(u => u.ToDto());

                    return Results.Ok(userDtos);
                }
            )
            .WithName("GetUsersWithDesiredSkill")
            .WithTags("Users");
    }
}
