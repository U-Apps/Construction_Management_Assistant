﻿using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using System.Linq.Expressions;

namespace ConstructionManagementAssistant_Core.Mapping;

public static class SiteEngineerProfile
{

    // returns Expression so ef can translate it to sql
    public static Expression<Func<SiteEngineer, GetSiteEngineerDto>> ToGetSiteEngineerDto()
    {
        return siteEngineer => new GetSiteEngineerDto
        {
            Id = siteEngineer.Id,
            //FullName = siteEngineer.GetFullName(), // ef, cant use it in query directly 
            FullName = siteEngineer.FirstName
                       + (string.IsNullOrEmpty(siteEngineer.SecondName) ? "" : " " + siteEngineer.SecondName)
                       + (string.IsNullOrEmpty(siteEngineer.ThirdName) ? "" : " " + siteEngineer.ThirdName)
                       + " " + siteEngineer.LastName,
            Email = siteEngineer.Email,
            PhoneNumber = siteEngineer.PhoneNumber,
            Address = siteEngineer.Address,
            IsAvailable = siteEngineer.IsAvailable
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
