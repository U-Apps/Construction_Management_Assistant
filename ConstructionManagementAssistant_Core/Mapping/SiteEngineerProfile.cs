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
    public static void UpdateSiteEngineer(this SiteEngineer siteEngineer, UpdateSiteEngineerDto updateSiteEngineerDto)
    {
        siteEngineer.Id = updateSiteEngineerDto.Id;
        siteEngineer.FirstName = updateSiteEngineerDto.FirstName;
        siteEngineer.SecondName = updateSiteEngineerDto.SecondName;
        siteEngineer.ThirdName = updateSiteEngineerDto.ThirdName;
        siteEngineer.LastName = updateSiteEngineerDto.LastName;
        siteEngineer.Email = updateSiteEngineerDto.Email;
        siteEngineer.PhoneNumber = updateSiteEngineerDto.PhoneNumber;
        siteEngineer.NationalNumber = updateSiteEngineerDto.NationalNumber;
        siteEngineer.Address = updateSiteEngineerDto.Address;
        siteEngineer.HireDate = updateSiteEngineerDto.HireDate;
        siteEngineer.ModifiedDate = DateTime.Now;
    }
}
