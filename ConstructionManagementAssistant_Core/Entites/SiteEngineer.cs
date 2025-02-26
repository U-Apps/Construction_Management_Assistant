﻿
namespace ConstructionManagementAssistant_Core.Entites;

public class SiteEngineer : Person, IEntity
{
    public DateOnly HireDate { get; set; }
    public bool IsAvailable { get; set; } = true;

    public ICollection<Project>? Projects { get; set; }

}

