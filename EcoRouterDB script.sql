CREATE DATABASE EcoRouter;

CREATE TABLE ROUTES(
	RouteID NVARCHAR(40) NOT NULL PRIMARY KEY,
	CreatedBy varchar(20) NULL,
	CreatedAt datetime NOT NULL,
	ModifiedBy varchar(20) NULL,
	ModifiedAt datetime NULL,
	IsActive bit NULL,
	DepartureId nvarchar(40) NULL,
	DestinationId nvarchar(40) NULL,
	FuelEstimation nvarchar(15) NULL,
	Distance nvarchar(15) NULL
)

CREATE TABLE MARKS (
	MarkID NVARCHAR(40) NOT NULL PRIMARY KEY,
    Longitude NVARCHAR(20) NOT NULL,
    Latitude NVARCHAR(20) NOT NULL
)

CREATE TABLE Users(
	UserId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	UserName nvarchar(10) NOT NULL,
	Password nvarchar(60) NULL,
	CreatedAt datetime NOT NULL,
	ModifiedAt datetime NOT NULL
	)

INSERT INTO Users
VALUES('admin', 'atBC0Hq7U2Dvqs0IY5UQtw==', GETDATE(),GETDATE())

INSERT MARKS (MarkID, Longitude, Latitude) VALUES (N'5A8575D0-B51C-4D4D-B00E-D88198FE5AD7', N'4.37031', N'50.9023')
INSERT MARKS (MarkID, Longitude, Latitude) VALUES (N'7AE2C0E0-FFB3-4DD3-8535-EDE2312BEB6F', N'4.34712', N'50.7661')
INSERT MARKS (MarkID, Longitude, Latitude) VALUES (N'9DF87207-8BCB-4DAC-B7FE-13191F1434B7', N'4.34539', N'50.8444')
INSERT MARKS (MarkID, Longitude, Latitude) VALUES (N'B8D2B756-27DF-442F-80D9-10F88958ED8C', N'4.36019', N'50.868')

INSERT ROUTES (RouteID, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, DepartureId, DestinationId, FuelEstimation, Distance) VALUES (N'15D693A2-108A-4698-913E-A8D06A14F7BE', N'admin', CAST(N'2020-02-18T15:50:43.337' AS DateTime), N'admin', CAST(N'2020-02-18T15:50:43.337' AS DateTime), 1, N'9DF87207-8BCB-4DAC-B7FE-13191F1434B7', N'B8D2B756-27DF-442F-80D9-10F88958ED8C', N'9.000', N'34.000')
INSERT ROUTES (RouteID, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, IsActive, DepartureId, DestinationId, FuelEstimation, Distance) VALUES (N'3201DE83-E3ED-4109-B106-8045C9CF7C3A', N'admin', CAST(N'2020-02-18T15:50:43.337' AS DateTime), N'admin', CAST(N'2020-02-18T15:50:43.337' AS DateTime), 1, N'5A8575D0-B51C-4D4D-B00E-D88198FE5AD7', N'7AE2C0E0-FFB3-4DD3-8535-EDE2312BEB6F', N'15.000', N'53.000')
