-- Create Person table
CREATE TABLE Person (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    SecondName NVARCHAR(100),
    ThirdName NVARCHAR(100),
    LastName NVARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20) UNIQUE,
    NationalNumber VARCHAR(50) UNIQUE,
    Email VARCHAR(100) UNIQUE
);
GO

-- Create Employees table
CREATE TABLE Employees (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    PersonId INT NOT NULL,
    HireDate DATE NOT NULL,
    JobId TINYINT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);
GO

-- Create Jobs table
CREATE TABLE Jobs (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL
);
GO

-- Create Contractors table
CREATE TABLE Contractors (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    PersonId INT,
    IsAvailable BIT NOT NULL,
    ContractorType TINYINT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);
GO


-- Create Clients table
CREATE TABLE Clients (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    PersonId INT NOT NULL,
    ClientTypeId TINYINT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);
GO

-- Create Projects table
CREATE TABLE Projects (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NTEXT,
    StartDate DATE,
    ExpectedEndDate DATE,
    ContractorId INT,
    ClientId INT,
    IsConstruction BIT NOT NULL,
    SiteEngineerId INT,
    ProjectContractId INT,
    FOREIGN KEY (SiteEngineerId) REFERENCES Employees(Id),
    --FOREIGN KEY (ProjectContractId) REFERENCES Documents(Id),
    FOREIGN KEY (ContractorId) REFERENCES Contractors(Id),
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);
GO


-- Create Milestone table
CREATE TABLE Milestone (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000),
    ProjectId INT NOT NULL,
    SiteEngineerId INT,
    StartDate DATE,
    ExpectedEndDate DATE,
    ActualEndDate DATE,
    FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
    FOREIGN KEY (SiteEngineerId) REFERENCES Employees(Id)
);
GO

-- Create Tasks table
CREATE TABLE Tasks (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Description NVARCHAR(500),
    StartDate DATE,
    ExpectedEndDate DATE,
    ActualEndDate DATE,
    MilestoneId INT,
    SiteEngineerId INT,
    TaskDocumentId INT,
    FOREIGN KEY (MilestoneId) REFERENCES Milestone(Id),
    FOREIGN KEY (SiteEngineerId) REFERENCES Employees(Id)
);
GO

-- Create DocumentClassifications table
CREATE TABLE DocumentClassifications (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL
);
GO


-- Create Documents table
CREATE TABLE Documents (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000),
    DocumentClassificationId INT NOT NULL,
    DateCreated DATE NOT NULL,
    ProjectId INT NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    FOREIGN KEY (DocumentClassificationId) REFERENCES DocumentClassifications(Id),
    FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
);
GO



-- Create EquipmentStatus table
CREATE TABLE EquipmentStatus (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Status NVARCHAR(50) NOT NULL
);
GO

-- Create Equipment table
CREATE TABLE Equipment (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    StatusId TINYINT NOT NULL,
    PurchaseDate DATE NOT NULL,
    FOREIGN KEY (StatusId) REFERENCES EquipmentStatus(Id)
);
GO



-- Create CostTypes table
CREATE TABLE CostTypes (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    TypeName NVARCHAR(100) NOT NULL
);
GO

-- Create TaskReports table
CREATE TABLE TaskReports (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    TaskId INT NOT NULL,
    SubcontractorId INT NOT NULL,
    ReportId INT NOT NULL,
    FOREIGN KEY (TaskId) REFERENCES Tasks(Id),
    FOREIGN KEY (ReportId) REFERENCES Documents(Id)
);
GO

-- Create ProjectReports table
CREATE TABLE ProjectReports (
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	ProjectId INT NOT NULL,
	ReportId INT NOT NULL,
	ContractorId INT NOT NULL,
	CompletedDate DATE,
	FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
	FOREIGN KEY (ReportId) REFERENCES Documents(Id),
	FOREIGN KEY (ContractorId) REFERENCES Contractors(Id)
);
GO

-- Create Costs table
CREATE TABLE Costs (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    ReportId INT,
    ProjectId INT NOT NULL,
    CostTypeId TINYINT NOT NULL,
    CostDescription NVARCHAR(500),
    BillDate DATE,
    BillCost SMALLMONEY,
    Bill INT,
    FOREIGN KEY (ReportId) REFERENCES Documents(Id),
    FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
    FOREIGN KEY (CostTypeId) REFERENCES CostTypes(Id)
);
GO


-- Create ProjectEquipment table
CREATE TABLE ProjectEquipment (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    EquipmentId INT NOT NULL,
    ProjectId INT NOT NULL,
    CostReportId INT,
    ReservationDate DATETIME NOT NULL,
    EquipmentUserId INT NOT NULL,
    FOREIGN KEY (EquipmentId) REFERENCES Equipment(Id),
    FOREIGN KEY (ProjectId) REFERENCES Projects(Id),
    FOREIGN KEY (CostReportId) REFERENCES Costs(Id)
);
GO

-- Create SubContractorSpecialties table
CREATE TABLE SubContractorSpecialties (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO

-- Create SubContractor table
CREATE TABLE SubContractor (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    PersonId INT NOT NULL,
    SpecialtyId TINYINT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id),
    FOREIGN KEY (SpecialtyId) REFERENCES SubContractorSpecialties(Id)
);
GO


-- not implemnted yet !!
-- Create CompletedProjects table
CREATE TABLE CompletedProjects (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    CompletionDate DATE NOT NULL,
    HandoverDate DATE,
    HandoverContractId INT,
    FOREIGN KEY (Id) REFERENCES Projects(Id),
    FOREIGN KEY (HandoverContractId) REFERENCES Documents(Id)
);
GO

-- Create ProjectsUnderImplementation table
CREATE TABLE ProjectsUnderImplementation (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    FOREIGN KEY (Id) REFERENCES Projects(Id)
);
GO

-- Create CanceledProjects table
CREATE TABLE CanceledProjects (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    CancellationDate DATE NOT NULL,
    CancellationReason NVARCHAR(1000) NOT NULL,
    CancellationReportId INT,
    TerminationContractId INT,
    CanceledAtMilestoneId INT,
    FOREIGN KEY (Id) REFERENCES Projects(Id),
    FOREIGN KEY (CancellationReportId) REFERENCES Documents(Id),
    FOREIGN KEY (TerminationContractId) REFERENCES Documents(Id),
    FOREIGN KEY (CanceledAtMilestoneId) REFERENCES Milestone(Id)
);
GO



-- Create Individuals table
CREATE TABLE Individuals (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);
GO

-- Create Organizations table
CREATE TABLE Organizations (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    RepresentativeId INT,
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100),
    FOREIGN KEY (RepresentativeId) REFERENCES Person(Id)
);
GO

-- Create ClientTypes table
CREATE TABLE ClientTypes (
    Id TINYINT NOT NULL IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL
);
GO

-- Create TaskCosts table
CREATE TABLE TaskCosts (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    TaskReportId INT NOT NULL,
    CostId INT NOT NULL,
    FOREIGN KEY (TaskReportId) REFERENCES TaskReports(Id),
    FOREIGN KEY (CostId) REFERENCES Costs(Id)
);
GO

-- Create CurrentAssignedProjects table
CREATE TABLE CurrentAssignedProjects (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    ContractorId INT NOT NULL,
    ProjectId INT NOT NULL,
    FOREIGN KEY (ContractorId) REFERENCES Contractors(Id),
    FOREIGN KEY (ProjectId) REFERENCES Projects(Id)
);
GO

-- Create CurrentAssignedTasks table
CREATE TABLE CurrentAssignedTasks (
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    SubContractorId INT NOT NULL,
    TaskId INT NOT NULL,
    FOREIGN KEY (SubContractorId) REFERENCES SubContractor(Id),
    FOREIGN KEY (TaskId) REFERENCES Tasks(Id)
);
GO
