namespace ConstructionManagementAssistant.EF.Data.Seading;

public static class SeedData
{
    public static List<Client> SeedClients()
    {
        return new List<Client>
        {
            new Client
            {
                Id = 1,
                FullName = "أحمد محمد",
                Email = "ahmed@example.com",
                PhoneNumber = "1121456789",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 2,
                FullName = "سارة علي",
                Email = "sara@example.com",
                PhoneNumber = "2927654321",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 3,
                FullName = "محمد حسن",
                Email = "mohamed@example.com",
                PhoneNumber = "31128833445",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 4,
                FullName = "ليلى إبراهيم",
                Email = "leila@example.com",
                PhoneNumber = "4243344556",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 5,
                FullName = "علي يوسف",
                Email = "ali@example.com",
                PhoneNumber = "0344455667",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 6,
                FullName = "فاطمة سعيد",
                Email = "fatima@example.com",
                PhoneNumber = "5445566778",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 7,
                FullName = "خالد عبد الله",
                Email = "khaled@example.com",
                PhoneNumber = "6556677889",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 8,
                FullName = "مريم أحمد",
                Email = "mariam@example.com",
                PhoneNumber = "7667788990",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 9,
                FullName = "يوسف علي",
                Email = "youssef@example.com",
                PhoneNumber = "0878899001",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 10,
                FullName = "نورا محمد",
                Email = "nora@example.com",
                PhoneNumber = "9889900112",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 11,
                FullName = "حسن علي",
                Email = "hassan@example.com",
                PhoneNumber = "14490011223",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 12,
                FullName = "منى سعيد",
                Email = "mona@example.com",
                PhoneNumber = "01022122334",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 13,
                FullName = "عمر خالد",
                Email = "omar@example.com",
                PhoneNumber = "01112233445",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 14,
                FullName = "هدى إبراهيم",
                Email = "huda@example.com",
                PhoneNumber = "2223344556",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 15,
                FullName = "ياسر يوسف",
                Email = "yasser@example.com",
                PhoneNumber = "03744455667",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 16,
                FullName = "نادية سعيد",
                Email = "nadia@example.com",
                PhoneNumber = "0045566778",
                ClientType = ClientType.individual,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 17,
                FullName = "ماجد عبد الله",
                Email = "majed@example.com",
                PhoneNumber = "9956677889",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 18,
                FullName = "سلمى أحمد",
                Email = "salma@example.com",
                PhoneNumber = "0667788990",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 19,
                FullName = "زياد علي",
                Email = "ziad@example.com",
                PhoneNumber = "0228899001",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new Client
            {
                Id = 20,
                FullName = "نور محمد",
                Email = "noor@example.com",
                PhoneNumber = "0874900112",
                ClientType = ClientType.Company,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            }
        };
    }

    public static List<SiteEngineer> SeedSiteEngineers()
    {

        return new List<SiteEngineer>
        {
            new SiteEngineer
            {
                Id = 21,
                FirstName = "أحمد",
                LastName = "محمد",
                PhoneNumber = "01553456789",
                Email = "ahmed.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 22,
                FirstName = "سارة",
                LastName = "علي",
                PhoneNumber = "0987654321",
                Email = "sara.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 23,
                FirstName = "محمد",
                LastName = "حسن",
                PhoneNumber = "0112233445",
                Email = "mohamed.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 24,
                FirstName = "ليلى",
                LastName = "إبراهيم",
                PhoneNumber = "0223344556",
                Email = "leila.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 25,
                FirstName = "علي",
                LastName = "يوسف",
                PhoneNumber = "0334455667",
                Email = "ali.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 26,
                FirstName = "فاطمة",
                LastName = "سعيد",
                PhoneNumber = "0445566778",
                Email = "fatima.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 27,
                FirstName = "خالد",
                LastName = "عبد الله",
                PhoneNumber = "0556677889",
                Email = "khaled.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1 ),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 28,
                FirstName = "مريم",
                LastName = "أحمد",
                PhoneNumber = "0667788990",
                Email = "mariam.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 29,
                FirstName = "يوسف",
                LastName = "علي",
                PhoneNumber = "0778899001",
                Email = "youssef.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 30,
                FirstName = "نورا",
                LastName = "محمد",
                PhoneNumber = "0889900112",
                Email = "nora.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 31,
                FirstName = "حسن",
                LastName = "علي",
                PhoneNumber = "0990011223",
                Email = "hassan.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 32,
                FirstName = "منى",
                LastName = "سعيد",
                PhoneNumber = "0106622334",
                Email = "mona.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 33,
                FirstName = "عمر",
                LastName = "خالد",
                PhoneNumber = "00025533445",
                Email = "omar.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 34,
                FirstName = "هدى",
                LastName = "إبراهيم",
                PhoneNumber = "01113446656",
                Email = "huda.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 35,
                FirstName = "ياسر",
                LastName = "يوسف",
                PhoneNumber = "0222005667",
                Email = "yasser.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 36,
                FirstName = "نادية",
                LastName = "سعيد",
                PhoneNumber = "4445555778",
                Email = "nadia.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 37,
                FirstName = "ماجد",
                LastName = "عبد الله",
                PhoneNumber = "0566677889",
                Email = "majed.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 38,
                FirstName = "سلمى",
                LastName = "أحمد",
                PhoneNumber = "0688898990",
                Email = "salma.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 39,
                FirstName = "زياد",
                LastName = "علي",
                PhoneNumber = "01118800001",
                Email = "ziad.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new SiteEngineer
            {
                Id = 40,
                FirstName = "نور",
                LastName = "محمد",
                PhoneNumber = "06900112",
                Email = "noor.engineer@example.com",
                HireDate = new DateOnly(2019, 8, 1),
                IsAvailable = true,
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            }
        };
    }

    public static List<WorkerSpecialty> SeedWorkerSpecialties()
    {

        return new List<WorkerSpecialty>
        {
            new WorkerSpecialty
            {
                Id = 1,
                Name = "نجار",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 2,
                Name = "حداد",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 3,
                Name = "سباك",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 4,
                Name = "كهربائي",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 5,
                Name = "بناء",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 6,
                Name = "دهان",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 7,
                Name = "مبلط",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 8,
                Name = "مقاول",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 9,
                Name = "مهندس معماري",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            },
            new WorkerSpecialty
            {
                Id = 10,
                Name = "مهندس مدني",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false
            }
        };
    }

    public static List<Worker> SeedWorkers()
    {
        return new List<Worker>
        {
            new Worker
            {
                Id = 1,
                FirstName = "محمد",
                SecondName = "علي",
                ThirdName = "حسن",
                LastName = "الخالد",
                NationalNumber = "123456789",
                PhoneNumber = "0512345611",
                Email = "mohamedd@example.com",
                Address = "شارع 10, الرياض",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 1
            },
            new Worker
            {
                Id = 2,
                FirstName = "أحمد",
                SecondName = "خالد",
                ThirdName = "سعيد",
                LastName = "الفهيد",
                NationalNumber = "227654321",
                PhoneNumber = "0228765432",
                Email = "ahmedd@example.com",
                Address = "شارع 20, جدة",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 2
            },
            new Worker
            {
                Id = 3,
                FirstName = "علي",
                SecondName = "ياسر",
                ThirdName = "طارق",
                LastName = "الغامدي",
                NationalNumber = "446789123",
                PhoneNumber = "0445678912",
                Email = "aliee@example.com",
                Address = "شارع 30, مكة",
                CreatedDate = new DateTime(2023, 10, 1),
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 3
            },
            new Worker
            {
                Id = 4,
                FirstName = "خالد",
                SecondName = "عمر",
                ThirdName = "مصطفى",
                LastName = "السعيد",
                NationalNumber = "1131654987",
                PhoneNumber = "0555165498",
                Email = "khassled@example.com",
                Address = "شارع 40, المدينة",
                IsDeleted = false,
                CreatedDate = new DateTime(2023, 10, 1),

                IsAvailable = true,
                SpecialtyId = 4
            },
            new Worker
            {
                Id = 5,
                FirstName = "ياسر",
                SecondName = "حسن",
                ThirdName = "سعد",
                LastName = "النجار",
                NationalNumber = "654667321",
                PhoneNumber = "0565498732",
                CreatedDate = new DateTime(2023, 10, 1),

                Email = "yas4ser@example.com",
                Address = "شارع 50, الدمام",
                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 5
            },
            new Worker
            {
                Id = 6,
                FirstName = "طارق",
                SecondName = "سعيد",
                ThirdName = "محمد",
                LastName = "الزيد",
                NationalNumber = "782223456",
                PhoneNumber = "668912345",
                Email = "taridq@example.com",
                CreatedDate = new DateTime(2023, 10, 1),

                Address = "شارع 60, الخبر",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 6
            },
            new Worker
            {
                Id = 7,
                FirstName = "مصطفى",
                SecondName = "عبدالله",
                ThirdName = "أحمد",
                LastName = "العبيد",
                NationalNumber = "852963741",
                PhoneNumber = "0585296374",
                Email = "mustaffa@example.com",
                Address = "شارع 70, الطائف",
                CreatedDate = new DateTime(2023, 10, 1),

                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 7
            },
            new Worker
            {
                Id = 8,
                FirstName = "سعيد",
                SecondName = "علي",
                ThirdName = "خالد",
                LastName = "الرشيد",
                NationalNumber = "963852741",
                PhoneNumber = "0596385274",
                Email = "saeefd@example.com",
                Address = "شارع 80, تبوك",
                IsDeleted = false,
                CreatedDate = new DateTime(2023, 10, 1),

                IsAvailable = true,
                SpecialtyId = 8
            },
            new Worker
            {
                Id = 9,
                FirstName = "عمر",
                SecondName = "ياسر",
                ThirdName = "طارق",
                CreatedDate = new DateTime(2023, 10, 1),

                LastName = "الغامدي",
                NationalNumber = "7431852963",
                PhoneNumber = "05743185296",
                Email = "omar@examp2le.com",
                Address = "شارع 90, بريدة",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 9
            },
            new Worker
            {
                Id = 10,
                FirstName = "حسن",
                SecondName = "محمد",
                ThirdName = "أحمد",
                LastName = "الفهيد",
                NationalNumber = "3692528147",
                PhoneNumber = "05369225814",
                Email = "hass2an@example.com",
                Address = "شارع 100, حائل",
                IsDeleted = false,
                CreatedDate = new DateTime(2023, 10, 1),

                IsAvailable = false,
                SpecialtyId = 10
            },
   new Worker
            {
                Id = 11,
                FirstName = "فهد",
                SecondName = "عبدالرحمن",
                ThirdName = "ناصر",
                LastName = "العبيد",
                NationalNumber = "1592357486",
                CreatedDate = new DateTime(2023, 10, 1),

                PhoneNumber = "05125935748",
                Email = "fahad@exam2ple.com",
                Address = "شارع 110, الرياض",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 1
            },
            new Worker
            {
                Id = 12,
                FirstName = "ناصر",
                SecondName = "سلمان",
                ThirdName = "فيصل",
                LastName = "الزيد",
                NationalNumber = "7523159486",
                PhoneNumber = "05275315948",
                CreatedDate = new DateTime(2023, 10, 1),

                Email = "nasse2r@example.com",
                Address = "شارع 120, جدة",
                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 2
            },
            new Worker
            {
                Id = 13,
                FirstName = "فيصل",
                SecondName = "عبدالعزيز",
                ThirdName = "راشد",
                LastName = "الرشيد",
                NationalNumber = "4862753159",
                CreatedDate = new DateTime(2023, 10, 1),

                PhoneNumber = "05483675315",
                Email = "faidsal@example.com",
                Address = "شارع 130, مكة",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 3
            },
            new Worker
            {
                Id = 14,
                FirstName = "راشد",
                SecondName = "عبدالله",
                ThirdName = "سعد",
                LastName = "السعد",
                NationalNumber = "35337159486",
                PhoneNumber = "02535715948",
                Email = "rashed@example.com",
                Address = "شارع 140, المدينة",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 4,
                CreatedDate = new DateTime(2023, 10, 1),

            },
            new Worker
            {
                Id = 15,
                FirstName = "سعد",
                SecondName = "عبدالمحسن",
                ThirdName = "فهد",
                LastName = "الفهد",
                NationalNumber = "95321753486",
                PhoneNumber = "05295175348",
                Email = "saad@example.com",
                Address = "شارع 150, الدمام",
                CreatedDate = new DateTime(2023, 10, 1),

                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 5
            },
            new Worker
            {
                Id = 16,
                FirstName = "عبدالله",
                SecondName = "عبدالرحمن",
                ThirdName = "ناصر",
                LastName = "الناصر",
                NationalNumber = "753486159",
                CreatedDate = new DateTime(2023, 10, 1),

                PhoneNumber = "0575348615",
                Email = "abdullah@example.com",
                Address = "شارع 160, الخبر",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 6
            },
            new Worker
            {
                Id = 17,
                FirstName = "عبدالرحمن",
                SecondName = "فيصل",
                ThirdName = "راشد",
                LastName = "الراشد",
                CreatedDate = new DateTime(2023, 10, 1),

                NationalNumber = "486159753",
                PhoneNumber = "0548615975",
                Email = "abdulrahman@example.com",
                Address = "شارع 170, الطائف",
                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 7
            },
            new Worker
            {
                Id = 18,
                FirstName = "عبدالعزيز",
                SecondName = "سعد",
                ThirdName = "فهد",
                LastName = "الفهد",
                NationalNumber = "159486753",
                CreatedDate = new DateTime(2023, 10, 1),

                PhoneNumber = "0515948675",
                Email = "abdulaziz@example.com",
                Address = "شارع 180, تبوك",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 8
            },
            new Worker
            {
                Id = 19,
                FirstName = "سلمان",
                SecondName = "راشد",
                ThirdName = "عبدالله",
                CreatedDate = new DateTime(2023, 10, 1),

                LastName = "العبدالله",
                NationalNumber = "753159486",
                PhoneNumber = "0575315948",
                Email = "salman@example.com",
                Address = "شارع 190, بريدة",
                IsDeleted = false,
                IsAvailable = true,
                SpecialtyId = 9
            },
            new Worker
            {
                Id = 20,
                FirstName = "عبدالمحسن",
                SecondName = "فهد",
                CreatedDate = new DateTime(2023, 10, 1),

                ThirdName = "ناصر",
                LastName = "الناصر",
                NationalNumber = "486753159",
                PhoneNumber = "0548675315",
                Email = "abdulmohsen@example.com",
                Address = "شارع 200, حائل",
                IsDeleted = false,
                IsAvailable = false,
                SpecialtyId = 10
            }
        };
    }

    public static List<Project> SeedProjects()
    {
        return new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "مشروع بناء مدرسة",
                    Description = "بناء مدرسة ابتدائية في المدينة",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
        ExpectedEndDate = new DateOnly(2022, 12, 1), // Static date
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 21,
                    ClientId = 1,
                    SiteAddress = "المدينة، شارع 1",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 2,
                    Name = "مشروع بناء مستشفى",
                    Description = "بناء مستشفى عام في المدينة",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
        ExpectedEndDate = new DateOnly(2022, 12, 1), // Static date
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 22,
                    ClientId = 2,
                    SiteAddress = "المدينة، شارع 2",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 3,
                    Name = "مشروع بناء مجمع سكني",
                    Description = "بناء مجمع سكني فاخر",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 23,
                    ClientId = 3,
                    SiteAddress = "المدينة، شارع 3",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 4,
                    Name = "مشروع بناء جسر",
                    Description = "بناء جسر يربط بين منطقتين",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 24,
                    ClientId = 4,
                    SiteAddress = "المدينة، شارع 4",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 5,
                    Name = "مشروع بناء مصنع",
                    Description = "بناء مصنع لإنتاج المواد الغذائية",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 25,
                    ClientId = 5,
                    SiteAddress = "المدينة، شارع 5",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 6,
                    Name = "مشروع بناء فندق",
                    Description = "بناء فندق خمس نجوم",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 26,
                    ClientId = 6,
                    SiteAddress = "المدينة، شارع 6",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 7,
                    Name = "مشروع بناء محطة قطار",
                    Description = "بناء محطة قطار حديثة",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                        ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 27,
                    ClientId = 7,
                    SiteAddress = "المدينة، شارع 7",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 8,
                    Name = "مشروع بناء مركز تجاري",
                    Description = "بناء مركز تجاري ضخم",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 28,
                    ClientId = 8,
                    SiteAddress = "المدينة، شارع 8",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 9,
                    Name = "مشروع بناء جامعة",
                    Description = "بناء جامعة حديثة",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 29,
                    ClientId = 9,
                    SiteAddress = "المدينة، شارع 9",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 10,
                    Name = "مشروع بناء حديقة عامة",
                    Description = "بناء حديقة عامة كبيرة",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 30,
                    ClientId = 10,
                    SiteAddress = "المدينة، شارع 10",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 11,
                    Name = "مشروع بناء مكتبة عامة",
                    Description = "بناء مكتبة عامة في المدينة",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
                     ExpectedEndDate = new DateOnly(2022, 12, 1), // Static date
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 31,
                    ClientId = 11,
                    SiteAddress = "المدينة، شارع 11",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 12,
                    Name = "مشروع بناء ملعب رياضي",
                    Description = "بناء ملعب رياضي حديث",
                    StartDate = new DateOnly(2022, 10, 1), // Static date
        ExpectedEndDate = new DateOnly(2022, 12, 1), // Static date
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 32,
                    ClientId = 12,
                    SiteAddress = "المدينة، شارع 12",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 13,
                    Name = "مشروع بناء محطة وقود",
                    Description = "بناء محطة وقود حديثة",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2022, 11, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 33,
                    ClientId = 13,
                    SiteAddress = "المدينة، شارع 13",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 14,
                    Name = "مشروع بناء مركز صحي",
                    Description = "بناء مركز صحي في المدينة",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 34,
                    ClientId = 14,
                    SiteAddress = "المدينة، شارع 14",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 15,
                    Name = "مشروع بناء مجمع تجاري",
                    Description = "بناء مجمع تجاري ضخم",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 35,
                    ClientId = 15,
                    SiteAddress = "المدينة، شارع 15",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 16,
                    Name = "مشروع بناء محطة كهرباء",
                    Description = "بناء محطة كهرباء حديثة",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 36,
                    ClientId = 16,
                    SiteAddress = "المدينة، شارع 16",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 17,
                    Name = "مشروع بناء محطة مياه",
                    Description = "بناء محطة مياه حديثة",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 37,
                    ClientId = 17,
                    SiteAddress = "المدينة، شارع 17",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 18,
                    Name = "مشروع بناء مركز شرطة",
                    Description = "بناء مركز شرطة حديث",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 38,
                    ClientId = 18,
                    SiteAddress = "المدينة، شارع 18",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 19,
                    Name = "مشروع بناء محطة إطفاء",
                    Description = "بناء محطة إطفاء حديثة",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 39,
                    ClientId = 19,
                    SiteAddress = "المدينة، شارع 19",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                },
                new Project
                {
                    Id = 20,
                    Name = "مشروع بناء مركز ثقافي",
                    Description = "بناء مركز ثقافي حديث",
                    StartDate = new DateOnly(2022, 10, 1),
                    ExpectedEndDate = new DateOnly(2020, 8, 1),
                    Status = ProjectStatus.InProgress,
                    SiteEngineerId = 40,
                    ClientId = 20,
                    SiteAddress = "المدينة، شارع 20",
                    GeographicalCoordinates = "24.7136, 46.6753",
                    CreatedDate = new DateTime(2023, 10, 1),
                    IsDeleted = false
                }
            };
    }


    public static List<Stage> SeedStages()
    {

        return new List<Stage>
        {
            // Stages for Project 1
            new Stage { Id = 1, Name = "تصميم", Description = "مرحلة تصميم المدرسة", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 1 },
            new Stage { Id = 2, Name = "بناء", Description = "مرحلة بناء المدرسة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 1 },
            new Stage { Id = 3, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 1 },

            // Stages for Project 2
            new Stage { Id = 4, Name = "تصميم", Description = "مرحلة تصميم المستشفى", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 2 },
            new Stage { Id = 5, Name = "بناء", Description = "مرحلة بناء المستشفى", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 2 },
            new Stage { Id = 6, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 2 },

            // Stages for Project 3
            new Stage { Id = 7, Name = "تصميم", Description = "مرحلة تصميم المجمع السكني", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 3 },
            new Stage { Id = 8, Name = "بناء", Description = "مرحلة بناء المجمع السكني", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 3 },
            new Stage { Id = 9, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1),  CreatedDate = new DateTime(2023, 10, 1),EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 3 },

            // Stages for Project 4
            new Stage { Id = 10, Name = "تصميم", Description = "مرحلة تصميم الجسر", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 4 },
            new Stage { Id = 11, Name = "بناء", Description = "مرحلة بناء الجسر", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 4 },
            new Stage { Id = 12, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1),  CreatedDate = new DateTime(2023, 10, 1),EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 4 },

            // Stages for Project 5
            new Stage { Id = 13, Name = "تصميم", Description = "مرحلة تصميم المصنع", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 5 },
            new Stage { Id = 14, Name = "بناء", Description = "مرحلة بناء المصنع", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 5 },
            new Stage { Id = 15, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1) ,  CreatedDate = new DateTime(2023, 10, 1),EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 5 },

            // Stages for Project 6
            new Stage { Id = 16, Name = "تصميم", Description = "مرحلة تصميم الفندق", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 6 },
            new Stage { Id = 17, Name = "بناء", Description = "مرحلة بناء الفندق", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 6 },
            new Stage { Id = 18, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 6 },

            // Stages for Project 7
            new Stage { Id = 19, Name = "تصميم", Description = "مرحلة تصميم محطة القطار", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 7 },
            new Stage { Id = 20, Name = "بناء", Description = "مرحلة بناء محطة القطار", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 7 },
            new Stage { Id = 21, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 7 },

            // Stages for Project 8
            new Stage { Id = 22, Name = "تصميم", Description = "مرحلة تصميم المركز التجاري", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 8 },
            new Stage { Id = 23, Name = "بناء", Description = "مرحلة بناء المركز التجاري", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 8 },
            new Stage { Id = 24, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 8 },

            // Stages for Project 9
            new Stage { Id = 25, Name = "تصميم", Description = "مرحلة تصميم الجامعة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 9 },
            new Stage { Id = 26, Name = "بناء", Description = "مرحلة بناء الجامعة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 9 },
            new Stage { Id = 27, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 9 },

            // Stages for Project 10
            new Stage { Id = 28, Name = "تصميم", Description = "مرحلة تصميم الحديقة العامة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 10 },
            new Stage { Id = 29, Name = "بناء", Description = "مرحلة بناء الحديقة العامة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 10 },
            new Stage { Id = 30, Name = "تشطيب", Description = "مرحلة التشطيب النهائية", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1) ,ProjectId = 10 },


            // Stages for Project 11
            new Stage { Id = 31, Name = "التخطيط", Description = "مرحلة التخطيط للمكتبة العامة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 11 },
            new Stage { Id = 32, Name = "التنفيذ", Description = "مرحلة بناء المكتبة العامة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 11 },
            new Stage { Id = 33, Name = "الفحص النهائي", Description = "الفحص النهائي للمكتبة قبل الافتتاح", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 11 },

            // Stages for Project 12
            new Stage { Id = 34, Name = "التخطيط", Description = "مرحلة التخطيط للملعب الرياضي", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 12 },
            new Stage { Id = 35, Name = "التنفيذ", Description = "مرحلة بناء الملعب الرياضي", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 12 },
            new Stage { Id = 36, Name = "الفحص النهائي", Description = "الفحص النهائي للملعب الرياضي", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), ProjectId = 12 },

            // Stages for Project 13
            new Stage { Id = 37, Name = "التخطيط", Description = "مرحلة التخطيط لمحطة الوقود", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 13 },
            new Stage { Id = 38, Name = "التنفيذ", Description = "مرحلة بناء محطة الوقود", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 13 },
            new Stage { Id = 39, Name = "الفحص النهائي", Description = "الفحص النهائي لمحطة الوقود", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 13 },

            // Stages for Project 14
            new Stage { Id = 40, Name = "التخطيط", Description = "مرحلة التخطيط للمركز الصحي", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 14 },
            new Stage { Id = 41, Name = "التنفيذ", Description = "مرحلة بناء المركز الصحي", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 14 },
            new Stage { Id = 42, Name = "الفحص النهائي", Description = "الفحص النهائي للمركز الصحي", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 14 },

            // Stages for Project 15
            new Stage { Id = 43, Name = "التخطيط", Description = "مرحلة التخطيط للمجمع التجاري", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 15 },
            new Stage { Id = 44, Name = "التنفيذ", Description = "مرحلة بناء المجمع التجاري", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 15 },
            new Stage { Id = 45, Name = "الفحص النهائي", Description = "الفحص النهائي للمجمع التجاري", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1) ,EndDate =  new DateOnly(2022, 11, 1), ProjectId = 15 },

            // Stages for Project 16
            new Stage { Id = 46, Name = "التخطيط", Description = "مرحلة التخطيط لمحطة الكهرباء", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 16 },
            new Stage { Id = 47, Name = "التنفيذ", Description = "مرحلة بناء محطة الكهرباء", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 16 },
            new Stage { Id = 48, Name = "الفحص النهائي", Description = "الفحص النهائي لمحطة الكهرباء", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 16 },

            // Stages for Project 17
            new Stage { Id = 49, Name = "التخطيط", Description = "مرحلة التخطيط لمحطة المياه", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 17 },
            new Stage { Id = 50, Name = "التنفيذ", Description = "مرحلة بناء محطة المياه", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 17 },
            new Stage { Id = 51, Name = "الفحص النهائي", Description = "الفحص النهائي لمحطة المياه", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 17 },

            // Stages for Project 18
            new Stage { Id = 52, Name = "التخطيط", Description = "مرحلة التخطيط لمركز الشرطة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 18 },
            new Stage { Id = 53, Name = "التنفيذ", Description = "مرحلة بناء مركز الشرطة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 18 },
            new Stage { Id = 54, Name = "الفحص النهائي", Description = "الفحص النهائي لمركز الشرطة", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 18 },

            // Stages for Project 19
            new Stage { Id = 55, Name = "التخطيط", Description = "مرحلة التخطيط لمحطة الإطفاء", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 19 },
            new Stage { Id = 56, Name = "التنفيذ", Description = "مرحلة بناء محطة الإطفاء", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 19 },
            new Stage { Id = 57, Name = "الفحص النهائي", Description = "الفحص النهائي لمحطة الإطفاء", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 19 },

            // Stages for Project 20
            new Stage { Id = 58, Name = "التخطيط", Description = "مرحلة التخطيط للمركز الثقافي", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 20 },
            new Stage { Id = 59, Name = "التنفيذ", Description = "مرحلة بناء المركز الثقافي", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate =  new DateOnly(2022, 11, 1), ProjectId = 20 },
            new Stage { Id = 60, Name = "الفحص النهائي", Description = "الفحص النهائي للمركز الثقافي", StartDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1) ,EndDate =  new DateOnly(2022, 11, 1), ProjectId = 20 }
        };
    }

    public static List<ConstructionManagementAssistant.Core.Entites.Task> SeedTasks()
    {

        return new List<ConstructionManagementAssistant.Core.Entites.Task>
        {
            // Project 1, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 1, StageId = 31, Name = "Gather Requirements", Description = "Collect requirements for the library design.", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 2, StageId = 31, Name = "Create Design Draft", Description = "Prepare initial architectural drafts.", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 3, StageId = 31, Name = "Conduct Design Review", Description = "Review designs with stakeholders.", StartDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  EndDate = new DateOnly(2022, 11, 1), IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 4, StageId = 31, Name = "Obtain Permits", Description = "Secure necessary construction permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 5, StageId = 31, Name = "Finalize Budget", Description = "Prepare and finalize the project budget.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 1, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 6, StageId = 32, Name = "Select Contractor", Description = "Choose a suitable contractor for construction.", StartDate =  new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 7, StageId = 32, Name = "Site Preparation", Description = "Prepare the site for construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 8, StageId = 32, Name = "Foundation Work", Description = "Conduct foundation work for the library.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 9, StageId = 32, Name = "Structural Framing", Description = "Complete structural framing of the building.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 10, StageId = 32, Name = "Roof Installation", Description = "Install roofing for the library.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 1, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 11, StageId = 33, Name = "Conduct Inspections", Description = "Perform general inspections of the construction.", StartDate = new DateOnly(2022, 11, 1), EndDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 12, StageId = 33, Name = "Install Electrical Systems", Description = "Install electrical systems and wiring.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 13, StageId = 33, Name = "Install HVAC Systems", Description = "Install heating, ventilation, and air conditioning systems.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 14, StageId = 33, Name = "Final Touch-ups", Description = "Complete final touch-ups and finishes.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 15, StageId = 33, Name = "Prepare for Opening", Description = "Prepare the library for the opening ceremony.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 2, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 16, StageId = 34, Name = "Conduct Site Analysis", Description = "Analyze the site for the hospital.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 17, StageId = 34, Name = "Develop Initial Plans", Description = "Prepare initial plans for the hospital.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 18, StageId = 34, Name = "Review with Stakeholders", Description = "Review plans with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 19, StageId = 34, Name = "Obtain Construction Permits", Description = "Get necessary permits for construction.", StartDate = new DateOnly(2022, 11, 1), EndDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 20, StageId = 34, Name = "Set Budget", Description = "Establish the project budget.", StartDate =  new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 2, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 21, StageId = 35, Name = "Select Construction Team", Description = "Select a construction team for the hospital.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 22, StageId = 35, Name = "Commence Foundation Work", Description = "Start the foundation work.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 23, StageId = 35, Name = "Build Structural Components", Description = "Construct structural components of the hospital.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 24, StageId = 35, Name = "Install Roof", Description = "Install the roof structure.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 25, StageId = 35, Name = "Begin Internal Work", Description = "Start internal work such as plumbing and electrical systems.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 2, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 26, StageId = 36, Name = "Conduct Final Inspection", Description = "Perform a thorough final inspection.", StartDate = new DateOnly(2022, 11, 1), EndDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 27, StageId = 36, Name = "Finalize Internal Installations", Description = "Complete all internal installations.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 28, StageId = 36, Name = "Prepare for Hand Over", Description = "Prepare the hospital for handover.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 29, StageId = 36, Name = "Organize Opening Ceremony", Description = "Plan and organize the opening ceremony.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 30, StageId = 36, Name = "Evaluate Project Completion", Description = "Conduct a project completion evaluation.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 3, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 31, StageId = 37, Name = "Conduct Site Assessment", Description = "Assess the site for residential complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 32, StageId = 37, Name = "Draft Initial Designs", Description = "Create initial designs for the complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 33, StageId = 37, Name = "Stakeholder Design Review", Description = "Review designs with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 34, StageId = 37, Name = "Get Necessary Permits", Description = "Obtain necessary building permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 35, StageId = 37, Name = "Finalize Project Budget", Description = "Finalize the budget for the project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 3, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 36, StageId = 38, Name = "Select Construction Team", Description = "Choose a construction team for the residential complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 37, StageId = 38, Name = "Prepare Site for Construction", Description = "Prepare the site for construction activities.", StartDate = new DateOnly(2022, 11, 1), EndDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 38, StageId = 38, Name = "Begin Foundation Work", Description = "Start foundation work for the complex.", StartDate =  new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 39, StageId = 38, Name = "Construct Structural Elements", Description = "Build structural elements of the residential complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 40, StageId = 38, Name = "Install Roof Structure", Description = "Install the roof structure for the complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 3, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 41, StageId = 39, Name = "Conduct Final Inspection", Description = "Perform final inspections of the residential complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 42, StageId = 39, Name = "Install Electrical Systems", Description = "Install electrical systems in the complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 43, StageId = 39, Name = "Install Plumbing Systems", Description = "Install plumbing systems in the complex.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 44, StageId = 39, Name = "Complete Interior Finishes", Description = "Finish the interiors of the residential units.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 45, StageId = 39, Name = "Prepare for Handover", Description = "Prepare the complex for handover to the client.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 4, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 46, StageId = 40, Name = "Site Evaluation", Description = "Evaluate site conditions for bridge construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 47, StageId = 40, Name = "Prepare Detailed Design", Description = "Create detailed design of the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 48, StageId = 40, Name = "Conduct Design Review", Description = "Review design with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 49, StageId = 40, Name = "Obtain Necessary Permits", Description = "Acquire necessary construction permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 50, StageId = 40, Name = "Finalize Project Budget", Description = "Finalize budget for the bridge construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 4, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 51, StageId = 41, Name = "Select Construction Team", Description = "Choose a construction team for the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 52, StageId = 41, Name = "Site Preparation", Description = "Prepare the site for bridge construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 53, StageId = 41, Name = "Start Foundation Work", Description = "Begin foundation work for the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 54, StageId = 41, Name = "Construct Bridge Structure", Description = "Construct the main structure of the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 55, StageId = 41, Name = "Install Safety Features", Description = "Install safety features and barriers on the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 4, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 56, StageId = 42, Name = "Final Inspection", Description = "Conduct final inspections of the bridge.", StartDate =  new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 57, StageId = 42, Name = "Conduct Load Testing", Description = "Perform load testing on the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 58, StageId = 42, Name = "Conduct Load Testing", Description = "Perform load testing on the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 59, StageId = 42, Name = "Conduct Load Testing", Description = "Perform load testing on the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 60, StageId = 42, Name = "Conduct Load Testing", Description = "Perform load testing on the bridge.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },


                  // Project 5, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 61, StageId = 43, Name = "Conduct Site Analysis", Description = "Analyze site conditions for the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 62, StageId = 43, Name = "Develop Initial Design", Description = "Prepare designs for the factory layout.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 63, StageId = 43, Name = "Review Design with Stakeholders", Description = "Conduct a design review with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 64, StageId = 43, Name = "Obtain Necessary Permits", Description = "Acquire permits for construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 65, StageId = 43, Name = "Finalize Project Budget", Description = "Finalize the budget for the factory project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 5, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 66, StageId = 44, Name = "Select Construction Team", Description = "Choose a construction team for the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 67, StageId = 44, Name = "Prepare Site for Construction", Description = "Prepare the site for factory construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 68, StageId = 44, Name = "Begin Foundation Work", Description = "Start foundation work for the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 69, StageId = 44, Name = "Construct Structural Elements", Description = "Build structural elements of the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 70, StageId = 44, Name = "Install Roof Structure", Description = "Install the roof structure for the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 5, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 71, StageId = 45, Name = "Conduct Final Inspection", Description = "Perform a final inspection of the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 72, StageId = 45, Name = "Install Electrical Systems", Description = "Install electrical systems in the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 73, StageId = 45, Name = "Install HVAC Systems", Description = "Install HVAC systems in the factory.", StartDate = new DateOnly(2022, 11, 1), EndDate =  new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 74, StageId = 45, Name = "Complete Interior Finishes", Description = "Finish the interiors of the factory.", StartDate =  new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 75, StageId = 45, Name = "Prepare for Handover", Description = "Prepare the factory for handover to the client.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 6, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 76, StageId = 46, Name = "Perform Site Survey", Description = "Survey the site for the hotel construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 77, StageId = 46, Name = "Draft Initial Designs", Description = "Create initial architectural designs for the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 78, StageId = 46, Name = "Review Design with Stakeholders", Description = "Conduct design review with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 79, StageId = 46, Name = "Obtain Necessary Permits", Description = "Acquire necessary construction permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 80, StageId = 46, Name = "Finalize Project Budget", Description = "Finalize the budget for the hotel project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 6, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 81, StageId = 47, Name = "Select Construction Team", Description = "Choose a construction team for the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 82, StageId = 47, Name = "Prepare Site for Construction", Description = "Prepare the site for hotel construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 83, StageId = 47, Name = "Begin Foundation Work", Description = "Start foundation work for the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 84, StageId = 47, Name = "Construct Structural Components", Description = "Construct structural components of the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 85, StageId = 47, Name = "Install Roof Structure", Description = "Install the roof structure for the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 6, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 86, StageId = 48, Name = "Conduct Final Inspection", Description = "Perform a final inspection of the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 87, StageId = 48, Name = "Install Electrical Systems", Description = "Install electrical systems in the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 88, StageId = 48, Name = "Install HVAC Systems", Description = "Install HVAC systems in the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 89, StageId = 48, Name = "Complete Interior Finishes", Description = "Finish the interiors of the hotel.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 90, StageId = 48, Name = "Prepare for Handover", Description = "Prepare the hotel for handover to the client.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 7, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 91, StageId = 49, Name = "Conduct Site Assessment", Description = "Assess site conditions for the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 92, StageId = 49, Name = "Prepare Initial Designs", Description = "Prepare initial designs for the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 93, StageId = 49, Name = "Review with Stakeholders", Description = "Review plans with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 94, StageId = 49, Name = "Obtain Necessary Permits", Description = "Acquire necessary construction permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 95, StageId = 49, Name = "Finalize Project Budget", Description = "Finalize the budget for the train station project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 7, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 96, StageId = 50, Name = "Select Construction Team", Description = "Choose a construction team for the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 97, StageId = 50, Name = "Prepare Site for Construction", Description = "Prepare the site for train station construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 98, StageId = 50, Name = "Begin Foundation Work", Description = "Start foundation work for the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 99, StageId = 50, Name = "Construct Structural Elements", Description = "Construct structural elements of the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 100, StageId = 50, Name = "Install Roof Structure", Description = "Install the roof structure for the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 7, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 101, StageId = 51, Name = "Conduct Final Inspection", Description = "Perform final inspections of the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 102, StageId = 51, Name = "Install Electrical Systems", Description = "Install electrical systems in the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 103, StageId = 51, Name = "Install HVAC Systems", Description = "Install HVAC systems in the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 104, StageId = 51, Name = "Complete Interior Finishes", Description = "Finish the interiors of the train station.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 105, StageId = 51, Name = "Prepare for Handover", Description = "Prepare the train station for handover to the client.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 8, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 106, StageId = 52, Name = "Conduct Market Analysis", Description = "Analyze the market for the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 107, StageId = 52, Name = "Draft Initial Layout", Description = "Create initial layout designs for the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 108, StageId = 52, Name = "Review with Stakeholders", Description = "Review designs with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 109, StageId = 52, Name = "Obtain Necessary Permits", Description = "Acquire necessary construction permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 110, StageId = 52, Name = "Finalize Project Budget", Description = "Finalize the budget for the shopping center project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 8, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 111, StageId = 53, Name = "Select Construction Team", Description = "Choose a construction team for the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 112, StageId = 53, Name = "Prepare Site for Construction", Description = "Prepare the site for shopping center construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 113, StageId = 53, Name = "Begin Foundation Work", Description = "Start foundation work for the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 114, StageId = 53, Name = "Construct Structural Components", Description = "Construct structural components of the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 115, StageId = 53, Name = "Install Roof Structure", Description = "Install the roof structure for the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            // Project 8, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 116, StageId = 54, Name = "Conduct Final Inspection", Description = "Perform final inspections of the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 117, StageId = 54, Name = "Install Electrical Systems", Description = "Install electrical systems in the shopping center.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },


            // Project 9, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 119, StageId = 55, Name = "Conduct Site Assessment", Description = "Assess the site for the university construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 120, StageId = 55, Name = "Draft Initial Plans", Description = "Prepare initial plans for the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 121, StageId = 55, Name = "Review with Stakeholders", Description = "Review plans with stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 122, StageId = 55, Name = "Obtain Necessary Permits", Description = "Acquire necessary construction permits.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 123, StageId = 55, Name = "Finalize Budget", Description = "Finalize the budget for the university project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 9, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 124, StageId = 56, Name = "Select Construction Team", Description = "Choose a construction team for the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 125, StageId = 56, Name = "Prepare Site for Construction", Description = "Prepare the site for university construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 126, StageId = 56, Name = "Begin Foundation Work", Description = "Start foundation work for the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 127, StageId = 56, Name = "Construct Structural Components", Description = "Construct structural components of the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 128, StageId = 56, Name = "Install Roof Structure", Description = "Install the roof structure for the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 9, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 129, StageId = 57, Name = "Conduct Final Inspection", Description = "Perform final inspections of the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 130, StageId = 57, Name = "Install Electrical Systems", Description = "Install electrical systems in the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 131, StageId = 57, Name = "Install HVAC Systems", Description = "Install HVAC systems in the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 132, StageId = 57, Name = "Complete Interior Finishes", Description = "Finish the interiors of the university.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 133, StageId = 57, Name = "Prepare for Handover", Description = "Prepare the university for handover to the client.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 10, Stage 1
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 134, StageId = 58, Name = "Conduct Site Evaluation", Description = "Evaluate the site for the public park.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 135, StageId = 58, Name = "Draft Initial Park Layout", Description = "Create initial layout for the public park.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 136, StageId = 58, Name = "Review with Stakeholders", Description = "Review park layout with community stakeholders.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 137, StageId = 58, Name = "Obtain Necessary Permits", Description = "Acquire necessary permits for park construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 138, StageId = 58, Name = "Finalize Project Budget", Description = "Finalize the budget for the public park project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 10, Stage 2
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 139, StageId = 59, Name = "Select Construction Team", Description = "Choose a construction team for the park.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 140, StageId = 59, Name = "Prepare Site for Construction", Description = "Prepare the park site for construction.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 141, StageId = 59, Name = "Begin Landscape Work", Description = "Start landscaping work for the park.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 142, StageId = 59, Name = "Install Park Amenities", Description = "Install benches, pathways, and other park amenities.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 143, StageId = 59, Name = "Complete Final Touches", Description = "Complete final touches and finishes in the park.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },

            // Project 10, Stage 3
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 144, StageId = 60, Name = "Conduct Final Inspection", Description = "Perform final inspections of the public park.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 145, StageId = 60, Name = "Address Any Issues", Description = "Fix any issues identified during inspections.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 146, StageId = 60, Name = "Prepare for Opening Ceremony", Description = "Prepare the park for the opening ceremony.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 147, StageId = 60, Name = "Organize Community Event", Description = "Organize an opening event for the community.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false },
            new ConstructionManagementAssistant.Core.Entites.Task { Id = 148, StageId = 60, Name = "Evaluate Project Success", Description = "Evaluate the success of the park project.", StartDate = new DateOnly(2022, 11, 1), EndDate = new DateOnly(2022, 11, 1), CreatedDate = new DateTime(2023, 10, 1),  IsCompleted = false }
            };
    }

    public static List<DocumentClassification> SeedDocumentClassifications()
    {
        return new List<DocumentClassification>
    {
        new DocumentClassification { Id = 1, Type = "Project Documents" },
        new DocumentClassification { Id = 2, Type = "Design Documents" },
        new DocumentClassification { Id = 3, Type = "Engineering & Technical Documents" },
        new DocumentClassification { Id = 4, Type = "Legal & Compliance Documents" },
        new DocumentClassification { Id = 5, Type = "Financial Documents" },
        new DocumentClassification { Id = 6, Type = "Site & Execution Documents" },
        new DocumentClassification { Id = 7, Type = "HR & Administrative Documents" },
        new DocumentClassification { Id = 8, Type = "Quality Assurance & Control Documents" },
        new DocumentClassification { Id = 9, Type = "Health, Safety, and Environment (HSE) Documents" },
        new DocumentClassification { Id = 10, Type = "Close-Out & Handover Documents" }
    };
    }


}
