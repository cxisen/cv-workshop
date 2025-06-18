﻿using backend.Data.Mappers;
using backend.Services;

namespace backend.Endpoints;

public static class ExperienceEndpoints
{
    public static void MapExperienceEndpoints(this WebApplication app)
    {
        // GET /experiences
        app.MapGet(
                "/experiences",
                async (ICvService cvService) =>
                {
                    // TODO: Oppgave 2
                    var experiences = await cvService.GetAllExperiencesAsync();
                    var experiencesDtos = experiences.Select(e => e.ToDto()).ToList();

                    return Results.Ok(experiencesDtos);
                }
            )
            .WithName("GetAllExperiences")
            .WithTags("Experiences");

        // GET /experiences/{id}
        app.MapGet(
                "/experiences/{id:guid}",
                async (Guid id, ICvService cvService) =>
                {
                    // TODO: Oppgave 2
                    var experience = await cvService.GetExperienceByIdAsync(id);

                    if (experience == null)
                        return Results.NotFound("Experience not found");
                    
                    return Results.Ok(experience);
                }
            )
            .WithName("GetExperienceById")
            .WithTags("Experiences");

        // GET /experiences/type/{type}
        app.MapGet(
                "/experiences/type/{type}",
                async (string type, ICvService cvService) =>
                {
                    // TODO: Oppgave 3

                    return Results.Ok();
                }
            )
            .WithName("GetExperiencesByType")
            .WithTags("Experiences");
    }
}
