using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;

namespace ConstructionManagementAssistant_Core.Mapping;

public static class SiteEngineerProfile
{
    public static GetSiteEngineerDto ToGetSiteEngineerDto(this SiteEngineer siteEngineer)
    {
        return new GetSiteEngineerDto
        {
            Id = siteEngineer.Id,
            FullName = siteEngineer.GetFullName(),
            Email = siteEngineer.Email,
            PhoneNumber = siteEngineer.PhoneNumber,
        };
    }
    public static SiteEngineer ToSiteEngineer(this AddSiteEngineerDto addSiteEngineerDto)
    {
        return new SiteEngineer
        {
            FirstName = addSiteEngineerDto.FirstName,
            SecondName = addSiteEngineerDto.SecondName,
            ThirdName = addSiteEngineerDto.ThirdName,
            LastName = addSiteEngineerDto.LastName,
            Email = addSiteEngineerDto.Email,
            PhoneNumber = addSiteEngineerDto.PhoneNumber,
            NationalNumber = addSiteEngineerDto.NationalNumber,
            Address = addSiteEngineerDto.Address,
            HireDate = addSiteEngineerDto.HireDate,
            CreatedDate = DateTime.Now,
            IsAvailable = true
        };
    }
    public static SiteEngineer ToSiteEngineer(this UpdateSiteEngineerDto updateSiteEngineerDto)
    {
        return new SiteEngineer
        {
            Id = updateSiteEngineerDto.Id,
            FirstName = updateSiteEngineerDto.FirstName,
            SecondName = updateSiteEngineerDto.SecondName,
            ThirdName = updateSiteEngineerDto.ThirdName,
            LastName = updateSiteEngineerDto.LastName,
            Email = updateSiteEngineerDto.Email,
            PhoneNumber = updateSiteEngineerDto.PhoneNumber,
            NationalNumber = updateSiteEngineerDto.NationalNumber,
            Address = updateSiteEngineerDto.Address,
            HireDate = updateSiteEngineerDto.HireDate,
            ModifiedDate = DateTime.Now,
        };
    }
}
