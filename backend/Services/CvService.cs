using backend.Data;
using backend.Data.Mappers;
using backend.Data.Models;
using backend.Data.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class CvService(AppDbContext context) : ICvService
{
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await context.Users.OrderBy(u => u.Name).ToListAsync();
    }

    // TODO: Oppgave 1
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await context.Users.FindAsync(id);
    }


    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
    {
        // TODO: Oppgave 2
        return await context.Experiences.OrderBy(e => e.Title).ToListAsync();
        // return [];
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        // TODO: Oppgave 2
        return await context.Experiences.FindAsync(id);
        // return null;
    }

    public async Task<IEnumerable<Experience>> GetExperiencesByTypeAsync(string type)
    {
        // TODO: Oppgave 3
        return await context.Experiences
            .Where(e => e.Type == type)
            .OrderBy(e => e.Title)
            .ToListAsync();
        // return [];
    }

    // TODO: Oppgave 4 ny metode (husk å legge den til i interfacet)
    public async Task<IEnumerable<User>> GetUsersWithDesiredSkills(IEnumerable<string> desiredTechnologies)
    {
        var desiredSkills = desiredTechnologies.Select(t => new Skill(Technology: t));
        var users = await context.Users.ToListAsync();
        
        return users.Where(u =>
            UserMapper.ParseUserSkills(u.Skills).Any(skill => desiredSkills.Contains(skill))
        );
    }
}
