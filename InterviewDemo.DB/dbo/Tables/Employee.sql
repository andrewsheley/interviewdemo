CREATE TABLE [dbo].[Employee] (
    [EmployeeID]     INT           IDENTITY (1, 1) NOT NULL,
    [LastName]       VARCHAR (50)  NULL,
    [FirstName]      VARCHAR (50)  NULL,
    [StreetAddress1] VARCHAR (100) NULL,
    [City]           VARCHAR (50)  NULL,
    [State]          VARCHAR (2)   NULL,
    [Zip]            VARCHAR (9)   NULL,
    [PhoneNumber]    VARCHAR (10)  NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

