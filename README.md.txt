//////////////////////////////////Airline Table

USE [FlightBooking]
GO

/****** Object:  Table [dbo].[Airlines]    Script Date: 12-05-2022 12:28:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Airlines](
	[AirlineId] [int] IDENTITY(1,1) NOT NULL,
	[AirlineName] [nvarchar](50) NULL,
	[AirlineLogo] [nvarchar](1000) NULL,
	[ContactNumber] [nvarchar](50) NULL,
	[IsBlocked] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[ContactAddress] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Airlines] PRIMARY KEY CLUSTERED 
(
	[AirlineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Airlines] ADD  CONSTRAINT [DF_Airlines_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Airlines] ADD  CONSTRAINT [DF_Airlines_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
GO

//////////////////////////////////Airline Table
/////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  Table [dbo].[BookingDetails]    Script Date: 12-05-2022 12:29:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookingDetails](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [nvarchar](50) NULL,
	[UserId] [uniqueidentifier] NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[NumberOfSeats] [int] NULL,
	[MealType] [nvarchar](10) NULL,
	[BookedDate] [datetime] NULL,
	[TripMode] [nvarchar](50) NULL,
	[TotalCost] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[PNRNumber] [nvarchar](50) NULL,
	[FlightId] [int] NULL,
	[FromPlace] [nvarchar](50) NULL,
	[ToPlace] [nvarchar](50) NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BookingDetails] ADD  CONSTRAINT [DF_BookingDetails_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[BookingDetails] ADD  CONSTRAINT [DF_BookingDetails_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO

///////////////////////////////////

//////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  Table [dbo].[Discounts]    Script Date: 12-05-2022 12:30:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Discounts](
	[DiscountId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Amount] [int] NULL,
	[AirlineId] [int] NULL,
	[DiscountStartDate] [datetime] NULL,
	[DiscountEndDate] [datetime] NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/////////////////////////////////

/////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  Table [dbo].[InventorySchedules]    Script Date: 12-05-2022 12:31:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventorySchedules](
	[FlightNumber] [nvarchar](50) NOT NULL,
	[AirlineId] [int] NULL,
	[FromPlace] [nvarchar](50) NULL,
	[ToPlace] [nvarchar](50) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
	[ScheduledDays] [nvarchar](50) NULL,
	[InstrumentUsed] [nvarchar](50) NULL,
	[TotalBCSeats] [int] NULL,
	[TotalNBCSeats] [int] NULL,
	[NumberOfRows] [int] NULL,
	[MealType] [nvarchar](50) NULL,
	[BCTicketCost] [float] NULL,
	[NBCTicketCost] [float] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[FlightId] [int] IDENTITY(1,1) NOT NULL,
	[ReturnTime] [datetime] NULL,
	[DepartureTime] [datetime] NULL,
 CONSTRAINT [PK_InventorySchedules] PRIMARY KEY CLUSTERED 
(
	[FlightNumber] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InventorySchedules] ADD  CONSTRAINT [DF_InventorySchedules_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[InventorySchedules] ADD  CONSTRAINT [DF_InventorySchedules_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
/////////////////////////////////

/////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  Table [dbo].[PassengerDetails]    Script Date: 12-05-2022 12:31:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PassengerDetails](
	[PassengerId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Age] [int] NULL,
	[SeatNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[PassengerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/////////////////////////////////

////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12-05-2022 12:32:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Role] [int] NULL,
	[Address] [nvarchar](1000) NULL,
	[Phone] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
GO
////////////////////////////////

///////////////////////////////
USE [FlightBooking]
GO

/****** Object:  UserDefinedTableType [dbo].[UDTT_Passenger]    Script Date: 12-05-2022 12:33:03 ******/
CREATE TYPE [dbo].[UDTT_Passenger] AS TABLE(
	[Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Age] [int] NULL,
	[SeatNo] [nvarchar](50) NULL
)
GO
///////////////////////////////

////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Airlines_AddAirlines]    Script Date: 12-05-2022 12:33:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Proc_Airlines_AddAirlines]
	@airlineName NVARCHAR(50),
	@airlineLogo NVARCHAR(1000),
	@contactNumber NVARCHAR(50),
	@contactAddress NVARCHAR(1000),
	@isBlocked BIT
AS
BEGIN

	INSERT INTO Airlines (AirlineName, AirlineLogo, ContactNumber, ContactAddress, IsBlocked)
	VALUES(@airlineName, @airlineLogo, @contactNumber, @contactAddress, @isBlocked)

END
GO
////////////////////////////////

////////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Airlines_GetAirlineById]    Script Date: 12-05-2022 12:34:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Proc_Airlines_GetAirlineById]
	@airlineId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT AirlineId, AirlineName, AirlineLogo, ContactNumber, ContactAddress, IsBlocked
	FROM Airlines
	WHERE AirlineId = @airlineId

END
GO
///////////////////////////////

///////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Airlines_GetAirlineByName]    Script Date: 12-05-2022 12:35:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Proc_Airlines_GetAirlineByName]
	@airlineName NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT AirlineId, AirlineName, AirlineLogo, ContactNumber, ContactAddress, IsBlocked
	FROM Airlines
	WHERE AirlineName = @airlineName

END
GO
//////////////////////////////

//////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Airlines_GetAirlines]    Script Date: 12-05-2022 12:35:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Proc_Airlines_GetAirlines]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT AirlineId, AirlineName, AirlineLogo, ContactNumber, ContactAddress, IsBlocked
	FROM Airlines
END
GO
//////////////////////////////

/////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Airlines_UpdateAirlines]    Script Date: 12-05-2022 12:36:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Proc_Airlines_UpdateAirlines]
	@airlineId INT,
	@airlineLogo NVARCHAR(1000),
	@contactNumber NVARCHAR(50),
	@contactAddress NVARCHAR(1000),
	@isBlocked BIT
AS
BEGIN

	UPDATE Airlines SET AirlineLogo = @airlineLogo, 
		ContactNumber = @contactNumber, 
		ContactAddress = @contactAddress, 
		IsBlocked = @isBlocked
	WHERE AirlineId = @airlineId

END
GO
////////////////////////////

////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_BookingDetails_BookFlight]    Script Date: 12-05-2022 12:36:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[Proc_BookingDetails_BookFlight]
	@flightNumber NVARCHAR(50),
	@UserId UNIQUEIDENTIFIER,
	@name NVARCHAR(50),
	@email NVARCHAR(50),
	@numberOfSeats INT,
	@mealType NVARCHAR(10),
	@bookedDate DATETIME,
	@tripMode NVARCHAR(50),
	@totalCost INT,
	@PNRNumber NVARCHAR(50),
	@flightId INT,
	@fromPlace NVARCHAR(50),
	@toPlace NVARCHAR(50),
	@passenger UDTT_Passenger READONLY
AS
BEGIN
BEGIN TRANSACTION trans;  

	DECLARE @bookingId INT;

	INSERT INTO BookingDetails(FlightNumber, UserId, [Name], Email, NumberOfSeats, MealType, BookedDate,
		TripMode, TotalCost, PNRNumber,FlightId, FromPlace, ToPlace)
	VALUES(@flightNumber, @UserId, @name, @email, @numberOfSeats, @MealType, @bookedDate, 
		@tripMode, @totalCost, @PNRNumber, @flightId, @fromPlace, @toPlace)

	SET @bookingId = @@IDENTITY

	EXEC Proc_PassengerDetails_AddPassengers @bookingId, @passenger;

COMMIT TRANSACTION trans;  

END
GO
////////////////////////////

////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_BookingDetails_CancelBooking]    Script Date: 12-05-2022 12:37:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Proc_BookingDetails_CancelBooking]
	@PNRNumber NVARCHAR(50)
AS
BEGIN

	DECLARE @bookingId INT;
	SET @bookingId = (SELECT BookingId FROM BookingDetails WHERE PNRNumber = @PNRNumber);

	DELETE FROM PassengerDetails WHERE BookingId = @bookingId;

	DELETE FROM BookingDetails WHERE BookingId = @bookingId;

END
GO
///////////////////////////

///////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_BookingDetails_GetBookingDetailsByEmail]    Script Date: 12-05-2022 12:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_BookingDetails_GetBookingDetailsByEmail]
	@email NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [BookingId],[FlightNumber],[UserId],[Name],[Email],[NumberOfSeats],[MealType]
      ,[BookedDate],[TripMode],[TotalCost],[CreatedDate],[UpdatedDate],[PNRNumber],[FlightId], [FromPlace],[ToPlace]
	FROM BookingDetails
	WHERE Email = @email
	ORDER BY CreatedDate DESC

END
GO
//////////////////////////

/////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_BookingDetails_GetBookingDetailsByPNRNumber]    Script Date: 12-05-2022 12:38:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_BookingDetails_GetBookingDetailsByPNRNumber] 
	@pnrNumber NVARCHAR(50) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [BookingId],[FlightNumber],[UserId],[Name],[Email],[NumberOfSeats],[MealType]
      ,[BookedDate],[TripMode],[TotalCost],[CreatedDate],[UpdatedDate],[PNRNumber], [FlightId], [FromPlace], [ToPlace]
	FROM BookingDetails
	WHERE (@pnrNumber IS NULL OR PNRNumber = @pnrNumber)

	SELECT PD.PassengerId, PD.BookingId, PD.[Name], PD.Gender, PD.Age, PD.SeatNo
	FROM PassengerDetails PD
	INNER JOIN BookingDetails BD ON BD.BookingId = PD.BookingId
	WHERE BD.PNRNumber = @pnrNumber;

END
GO
////////////////////////

///////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Discounts_AddDiscount]    Script Date: 12-05-2022 12:38:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Discounts_AddDiscount]
	@airlineId INT,
	@code NVARCHAR(50),
	@amount INT,
	@discountStartDate DATETIME,
	@discountEndDate DATETIME
AS
BEGIN

	INSERT INTO Discounts(Code, Amount, AirlineId, DiscountStartDate, DiscountEndDate)
	VALUES(@code, @amount, @airlineId, @discountStartDate, @discountEndDate)

END
GO
/////////////////////////

//////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Discounts_GetAllDiscount]    Script Date: 12-05-2022 12:39:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Discounts_GetAllDiscount]
AS
BEGIN

	SELECT D.Code, D.Amount, D.AirlineId, A.AirlineName, D.DiscountStartDate, D.DiscountEndDate
	FROM Discounts D
	INNER JOIN Airlines A ON A.AirlineId = D.AirlineId
END
GO
//////////////////////////

////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Discounts_GetDiscountByCode]    Script Date: 12-05-2022 12:40:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Discounts_GetDiscountByCode]
	@code NVARCHAR(50)
AS
BEGIN

	SELECT Code, Amount, AirlineId, DiscountStartDate, DiscountEndDate
	FROM Discounts
	WHERE Code = @code AND DiscountStartDate < GETDATE() AND DiscountEndDate > GETDATE()

END
GO
////////////////////////////

///////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Inventories_AddInventory]    Script Date: 12-05-2022 12:40:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[Proc_Inventories_AddInventory]
	@flightNumber NVARCHAR(50),
	@airlineId INT,
	@fromPlace NVARCHAR(50),
	@toPlace NVARCHAR(50),
	@startTime DATETIME,
	@endTime DATETIME,
	@scheduledDays NVARCHAR(50),
	@instrumentUsed NVARCHAR(100),
	@totalBCSeats INT,
	@totalNBCSeats INT,
	@numberOfRows INT,
	@mealType NVARCHAR(50),
	@bcTicketCost FLOAT(3),
	@nbcTicketCost FLOAT(3)
AS
BEGIN

	INSERT INTO InventorySchedules(FlightNumber, AirlineId, FromPlace, ToPlace, StartTime, EndTime, ScheduledDays, 
		InstrumentUsed, TotalBCSeats, TotalNBCSeats, NumberOfRows, MealType, BCTicketCost, NBCTicketCost)
	VALUES(@flightNumber, @airlineId, @fromPlace, @toPlace, @startTime, @endTime, @scheduledDays, 
		@instrumentUsed, @totalBCSeats, @totalNBCSeats, @numberOfRows, @mealType, @bcTicketCost, @nbcTicketCost)

END
GO
//////////////////////////

/////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Inventories_GetAllFlightDetails]    Script Date: 12-05-2022 12:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[Proc_Inventories_GetAllFlightDetails] 
	@fromPlace NVARCHAR(50) = NULL,
	@toPlace NVARCHAR(50) = NULL,
	@startTime DATETIME = NULL,
	@endTime DATETIME = NULL,
	@tripMode NVARCHAR(50) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT INV.FlightId, INV.FlightNumber, AL.AirlineName, INV.FromPlace, INV.ToPlace, INV.StartTime, INV.EndTime, INV.ScheduledDays,
		INV.MealType, INV.BCTicketCost, INV.NBCTicketCost
	FROM InventorySchedules INV
	INNER JOIN Airlines AL ON AL.AirlineId = INV.AirlineId
	WHERE AL.IsBlocked = 0 AND INV.StartTime >= GETDATE()
	AND  (@fromPlace IS NULL OR INV.FromPlace = @fromPlace)
	AND  (@toPlace IS NULL OR INV.ToPlace = @toPlace)
	AND  (@startTime IS NULL OR INV.StartTime >= @startTime)
	AND  (@endTime IS NULL OR INV.EndTime = @endTime)
	AND  (@tripMode IS NULL OR INV.ScheduledDays = @tripMode)

END
GO
////////////////////////

/////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Inventories_GetAllInventories]    Script Date: 12-05-2022 12:41:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Inventories_GetAllInventories]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT INV.FlightId, INV.FlightNumber, AL.AirlineId, AL.AirlineName, INV.FromPlace, INV.ToPlace, INV.StartTime, INV.EndTime, INV.ScheduledDays, 
		INV.InstrumentUsed, INV.TotalBCSeats, INV.TotalNBCSeats, INV.NumberOfRows, INV.MealType, INV.BCTicketCost, INV.NBCTicketCost
	FROM InventorySchedules INV
	INNER JOIN Airlines AL ON AL.AirlineId = INV.AirlineId

END
GO
/////////////////////////

///////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Inventories_GetInventoryByFlightNumber]    Script Date: 12-05-2022 12:42:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Inventories_GetInventoryByFlightNumber]
	@flightNumber NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT INV.FlightId, INV.FlightNumber, AL.AirlineId, AL.AirlineName, INV.FromPlace, INV.ToPlace, INV.StartTime, INV.EndTime, INV.ScheduledDays, 
		INV.InstrumentUsed, INV.TotalBCSeats, INV.TotalNBCSeats, INV.NumberOfRows, INV.MealType, INV.BCTicketCost, INV.NBCTicketCost,
		INV.DepartureTime, INV.ReturnTime
	FROM InventorySchedules INV
	INNER JOIN Airlines AL ON AL.AirlineId = INV.AirlineId
	WHERE INV.FlightNumber = @flightNumber

END
GO
//////////////////////////

//////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Inventories_GetInventoryByFlightNumberAndStartDate]    Script Date: 12-05-2022 12:42:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Inventories_GetInventoryByFlightNumberAndStartDate]
	@flightNumber NVARCHAR(50),
	@startTime DATETIME
AS
BEGIN
	SET NOCOUNT ON;

	SELECT INV.FlightId, INV.FlightNumber, AL.AirlineId, AL.AirlineName, INV.FromPlace, INV.ToPlace, INV.StartTime, INV.EndTime, INV.ScheduledDays, 
		INV.InstrumentUsed, INV.TotalBCSeats, INV.TotalNBCSeats, INV.NumberOfRows, INV.MealType, INV.BCTicketCost, INV.NBCTicketCost
	FROM InventorySchedules INV
	INNER JOIN Airlines AL ON AL.AirlineId = INV.AirlineId
	WHERE INV.FlightNumber = @flightNumber AND StartTime=@startTime

END
GO
///////////////////////////

//////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Inventories_GetInventoryById]    Script Date: 12-05-2022 12:43:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Inventories_GetInventoryById]
	@flightId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT INV.FlightId, INV.FlightNumber, AL.AirlineId, AL.AirlineName, INV.FromPlace, INV.ToPlace, INV.StartTime, INV.EndTime, INV.ScheduledDays, 
		INV.InstrumentUsed, INV.TotalBCSeats, INV.TotalNBCSeats, INV.NumberOfRows, INV.MealType, INV.BCTicketCost, INV.NBCTicketCost
	FROM InventorySchedules INV
	INNER JOIN Airlines AL ON AL.AirlineId = INV.AirlineId
	WHERE INV.FlightId = @flightId

END
GO
//////////////////////////

////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Passenger_GetSeats]    Script Date: 12-05-2022 12:43:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Proc_Passenger_GetSeats]
	@id INT
AS
BEGIN

	SELECT PD.SeatNo from PassengerDetails PD
	INNER JOIN BookingDetails BD on BD.BookingId = PD.BookingId
	INNER JOIN InventorySchedules INV on INV.FlightId = BD.flightId
	WHERE INV.FlightId =@id

END
GO
/////////////////////////////

////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_PassengerDetails_AddPassengers]    Script Date: 12-05-2022 12:44:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_PassengerDetails_AddPassengers]
	@bookingId INT,
	@passenger UDTT_Passenger READONLY
AS
BEGIN

	INSERT INTO PassengerDetails (BookingId, [Name], Gender, Age, SeatNo)
	SELECT @bookingId, [Name], Gender, Age, SeatNo
	FROM @passenger

END
GO
////////////////////////////

////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Users_AddUser]    Script Date: 12-05-2022 12:44:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Users_AddUser]
	@userId UNIQUEIDENTIFIER,
	@name NVARCHAR(50),
	@email NVARCHAR(50),
	@password NVARCHAR(50),
	@role INT,
	@address NVARCHAR(1000),
	@phone NVARCHAR(50)
AS
BEGIN

	INSERT INTO Users(UserId, [Name], Email, [Password], [Role], [Address], Phone)
	VALUES(@userId, @name, @email, @password, @role, @address, @phone)

END
GO
////////////////////////////

/////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Users_GetUserByUsername]    Script Date: 12-05-2022 12:45:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Users_GetUserByUsername]
	@username NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UserId, [Name], Email, [Role], [Address], Phone
	FROM Users
	WHERE Email = @username

END
GO
////////////////////////////////

///////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Users_GetUserByUsernameAndPassword]    Script Date: 12-05-2022 12:45:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Users_GetUserByUsernameAndPassword]
	@username NVARCHAR(50),
	@password NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UserId, [Name], Email, [Role], [Address], Phone
	FROM Users
	WHERE Email = @username AND [Password] = @password

END
GO
////////////////////////////////

///////////////////////////////
USE [FlightBooking]
GO

/****** Object:  StoredProcedure [dbo].[Proc_Users_GetUserByUsernameOrUserId]    Script Date: 12-05-2022 12:46:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Proc_Users_GetUserByUsernameOrUserId]
	@username NVARCHAR(50),
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UserId, [Name], Email, [Role], [Address], Phone
	FROM Users
	WHERE Email = @username OR UserId = @userId

END
GO
/////////////////////////////////
