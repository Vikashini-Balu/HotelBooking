CREATE DATABASE HotelBooking
USE HotelBooking

--CREDENTIALS
CREATE TABLE [User]
(
UserID UNIQUEIDENTIFIER  ,
EmailID VARCHAR(50)PRIMARY KEY,
FirstName VARCHAR(25) NOT NULL,
LastName VARCHAR(25) NOT NULL,
UserPassword VARCHAR(15) NOT NULL,
IsAdmin BIT,
PhoneNumber BIGINT,
CreatedDate DATETIME Default getdate(),
ModifiedDate DATETIME NULL,
IsActive BIT,
AdminHotelID INT
);

ALTER TABLE [User]
ADD AdminHotelID INT;



--Hotels
CREATE TABLE Hotel
(
HotelID INT IDENTITY(1,1) PRIMARY KEY,
HotelName VARCHAR(50) UNIQUE NOT NULL,
HotelDescription VARCHAR(200) NOT NULL,
Rating INT,
NoOfRooms INT NOT NULL,
Amenities VARCHAR(500),
LocationID INT
)

ALTER TABLE Hotel Add COLUMN LocationID INT

ALTER TABLE RoomBookingDetails
ADD StatusID INT;



select * from Hotel

ALTER TABLE Hotel
ADD CONSTRAINT FK_Hotel_Location
FOREIGN KEY (LocationID)
REFERENCES [Location] (LocationID);


--HotelRoomType
CREATE TABLE HotelRoomType
(
RTID INT IDENTITY(1,1) PRIMARY KEY,
RoomType VARCHAR(50) NOT NULL,
NoOfPersons INT NOT NULL
)

--HotelRooms
CREATE TABLE HotelRoomDetails
(
HRID INT IDENTITY(1,1) PRIMARY KEY,
HotelRoomNumber VARCHAR(50),
HotelID INT FOREIGN KEY REFERENCES Hotel(HotelID),
RoomTypeID INT FOREIGN KEY REFERENCES HotelRoomType(RTID),
RoomDescription VARCHAR(500) NOT NULL,
RoomPrice DECIMAL(10,2) NOT NULL,
)

--BookingDetails
CREATE TABLE RoomBookingDetails
(
RoomBookingId INT IDENTITY(1,1) PRIMARY KEY,
EmailID VARCHAR(50) FOREIGN KEY REFERENCES [User](EmailID),
CheckInDate DATETIME,
CheckOutDate DATETIME,
TotalAmount DECIMAL(10,2),
BookedDate DATETIME,
HRID INT FOREIGN KEY REFERENCES HotelRoomDetails(HRID),
CreatedBy VARCHAR(50) NOT NULL,
ModifiedBy VARCHAR(50) NOT NULL,
StatusID INT FOREIGN KEY REFERENCES [Status](StatusID)
);

--RoomAvailability
CREATE TABLE RoomAvailability
(
RAID INT IDENTITY(1,1) PRIMARY KEY,
HRID INT FOREIGN KEY REFERENCES HotelRoomDetails(HRID),
AvailableDate DATE,
IsAvailable BIT 
)

DROP TABLE RoomAvailability

ALTER TABLE RoomAvailability
DROP COLUMN HotelID

ALTER TABLE RoomAvailability
ADD HotelID INT FOREIGN KEY REFERENCES Hotel(HotelID)

UPDATE RoomAvailability
SET HotelID = 12 WHERE RAID = 2

--Location
CREATE Table [Location]
(
LocationID INT PRIMARY KEY,
LocationName VARCHAR(15)
)

--Status
CREATE TABLE [Status]
(
StatusID INT PRIMARY KEY,
StatusName VARCHAR(15)
)

--JOIN Hotel and [Location]
SELECT H.HotelID,H.HotelName,H.HotelDescription,H.Rating,H.NoOfRooms,H.Amenities,H.LocationID,L.LocationName
FROM Hotel H
LEFT JOIN [Location] L ON L.LocationID = H.LocationID;

SELECT H.HotelID, H.HotelName, H.HotelDescription, H.Rating, H.NoOfRooms, H.Amenities, H.LocationID, L.LocationName
FROM Hotel H
LEFT JOIN [Location] L ON L.LocationID = H.LocationID
WHERE H.HotelName LIKE '%Sun%';

SELECT H.HotelName,L.LocationName FROM Hotel H INNER JOIN [Location] L ON L.LocationID = H.LocationID 
WHERE H.HotelName LIKE '%ABC%';

--DropDownHotelDetail 
CREATE PROCEDURE USP_GetHotel
AS
BEGIN
SELECT HotelName FROM Hotel
END

--DropDownLocationDetail 
CREATE PROCEDURE USP_GetLocation 
AS
BEGIN
SELECT LocationName FROM [Location]
END

--sp for getting location of the hotel using hotelname(Hotel)

CREATE PROCEDURE sp_GetLocationByHotel
    @keyword nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT H.HotelName, L.LocationName
    FROM Hotel H
    INNER JOIN [Location] L ON L.LocationID = H.LocationID 
    WHERE H.HotelName LIKE '%' + @keyword + '%';
END

EXEC sp_GetLocationByHotel "Taj"

--Sp for getting Hotel names using location name(Location)

CREATE PROCEDURE USP_GetHotelsByLocation
    @LocationName nvarchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT H.HotelName
    FROM Hotel H
    INNER JOIN [Location] L ON L.LocationID = H.LocationID 
    WHERE L.LocationName = @LocationName;
END

EXEC USP_GetHotelsByLocation "Coimbatore"


--sp for get all hotels
CREATE PROCEDURE USP_Hotel
AS
BEGIN
    SELECT HotelID,HotelName,HotelDescription,Rating,NoOfRooms,Amenities,LocationID FROM Hotel
END

EXEC USP_Hotel

SELECT * FROM [User]
SELECT * FROM Hotel
SELECT * FROM HotelRoomType
SELECT * FROM HotelRoomDetails
SELECT * FROM RoomBookingDetails
SELECT * FROM RoomAvailability
SELECT * FROM [Location]
SELECT * FROM [Status]

--Insert UserDetails

CREATE OR ALTER PROC  USP_InsertUserDetails(
@EmailID VARCHAR(50) ,
@FirstName VARCHAR(25),
@LastName VARCHAR(25),
@UserPassword VARCHAR(15),
@IsAdmin BIT,
@PhoneNumber BIGINT ,
@IsActive BIT,
@AdminHotelID INT
)
AS
BEGIN
    Declare @id UNIQUEIDENTIFIER = NEWID()
	INSERT INTO [dbo].[User]
           ([UserID]
           ,[EmailID]
           ,[FirstName]
           ,[LastName]
           ,[UserPassword]
           ,[IsAdmin]
           ,[PhoneNumber]
		   ,[IsActive]
		   ,[AdminHotelID])
     VALUES
           (NEWID()
           ,@EmailID
           ,@FirstName
           ,@LastName
           ,@UserPassword
           ,@IsAdmin
           ,@PhoneNumber
		   ,@IsActive
		   ,@AdminHotelID)
END

EXEC USP_InsertUserDetails 'Bhala123@gmail.com','Bhala','Ganesh','BhalaU01',1,9638521470,1,10
EXEC USP_InsertUserDetails 'Gokula987@gmail.com','Gokula','Vani','GokulaU02',0,9874560123
EXEC USP_InsertUserDetails 'Mahesh412@gmail.com','Mahesh','Venkatachalam','MaheshU03',0,9510357412,1,NULL
EXEC USP_InsertUserDetails 'U04','Kamalesh753@gmail.com','Kamalesh','Krish','KamaleshU04',0,9382170543
EXEC USP_InsertUserDetails 'U05','Swathi159@gmail.com','Swathi','Gurunathan','SwathiU05',0,9137462058
EXEC USP_InsertUserDetails 'A02','Vikashini111@gmail.com','Vikashini','Balu','VikashiniU06',1,9988442200


INSERT INTO dbo.[User](UserID,EmailID,FirstName,LastName,UserPassword,IsAdmin,PhoneNumber,IsActive) VALUES(NEWID(),'mathu90@gmail.com','mathu','mitha','pass',1,9638525256,1)

alter proc logindetailsccc
as
begin
	INSERT INTO [dbo].[User]
           ([UserID]
           ,[EmailID]
           ,[FirstName]
           ,[LastName]
           ,[UserPassword]
           ,[IsAdmin]
           ,[PhoneNumber])
     VALUES
           (NEWID()
           ,@emailid
           ,@firstname
           ,@lastname
           ,@paswd
           ,@isAdmin
           ,@phoneno)

end

select * from dbo.[User]
exec logindetails 'mariii@gmail.com','mari','muthu','marimuthu',1,67890876
exec logindetails'Bhala123@gmail.com','Bhala','Ganesh','Bhala',1,852147066

--sp for GetAllUser
Alter PROCEDURE sp_User
AS
BEGIN
    SELECT UserID,EmailID,FirstName,LastName,UserPassword,IsAdmin,PhoneNumber,CreatedDate,ModifiedDate,IsActive,AdminHotelID FROM [User]
END

Exec sp_User
--sp for Inserting Hotel
ALTER proc sp_Hotel(@HotelName varchar(50),@HotelDescription varchar(200),@LocationID INT,@Rating INT,@NoOfRooms int,@Amenities varchar(500))
as
begin
	INSERT INTO [dbo].Hotel ([HotelName],[HotelDescription],[LocationID],[Rating],[NoOfRooms],[Amenities]) VALUES (@HotelName,@HotelDescription,@LocationID,@Rating,@NoOfRooms,@Amenities)
end

EXEC sp_Hotel 'ABC','FiveStar',1,4,52,'We have spa'
EXEC sp_Hotel 'Taj','FiveStar',2,5,26,'We have swimmingpool'
EXEC sp_Hotel 'Hindustan','FourStar',3,'Coimbatore',4,30,'We have gym'
EXEC sp_Hotel 'Sky','ThreeStar',1,3,52,'We have sportsfacilities'
EXEC sp_Hotel 'Sun','FiveStar',2,4,15,'We have spa'

EXEC sp_Hotel 'Star','Resturant',2,2.5,6,'We have Resturant and resort'

--sp for Inserting Location

CREATE PROC SP_Location
(
@LocationID INT,
@LocationName VARCHAR(15)
)
AS
BEGIN
INSERT INTO [Location] VALUES(@LocationID,@LocationName)
END

EXEC SP_Location 01,'Coimbatore'
EXEC SP_Location 02,'Chennai'
EXEC SP_Location 03,'Bangalore'

--sp for inserting Status

CREATE PROC SP_Status
(
@StatusID INT,
@StatusName VARCHAR(15)
)
AS
BEGIN
INSERT INTO [Status] VALUES(@statusID,@StatusName)
END

EXEC SP_Status 0,'cancelled'
EXEC SP_Status 1,'Booked'
EXEC SP_Status 2,'Pending' 
--sp for inserting HotelRoomType

CREATE PROC SP_HotelRoomType
(
@RoomType VARCHAR(50) ,
@NoOfPersons INT 
)
AS
BEGIN
INSERT INTO HotelRoomType VALUES (@RoomType,@NoOfPersons)
END

EXEC SP_HotelRoomType 'AC',2
EXEC SP_HotelRoomType 'Non-AC',2
EXEC SP_HotelRoomType 'AC',3
EXEC SP_HotelRoomType 'AC',1
EXEC SP_HotelRoomType 'Non-AC',3

--sp for inserting HotelRoomDetails

CREATE PROC SP_HotelRoomDetails
(
@HotelRoomNumber VARCHAR(50),
@HotelID INT,
@RoomTypeID INT,
@RoomDescription VARCHAR(500),
@RoomPrice DECIMAL(10,2)
)
As
BEGIN
INSERT INTO HotelRoomDetails VALUES (@HotelRoomNumber,@HotelID,@RoomTypeID,@RoomDescription,@RoomPrice)
END

EXEC SP_HotelRoomDetails 'G01',10,1,'It is a AC room comfortable for two person',1000.00
EXEC SP_HotelRoomDetails 'G11',11,2,'It is a Non-AC room comfortable for two person',750.00
EXEC SP_HotelRoomDetails 'F10',12,3,'It is a AC room comfortable for three person',1500.00
EXEC SP_HotelRoomDetails 'F15',13,4,'It is a AC room comfortable for one person',950.00
EXEC SP_HotelRoomDetails 'H07',14,5,'It is a Non-AC room comfortable for three person',1100.00
EXEC SP_HotelRoomDetails 'H15',16,1,'It is a AC room comfortable for two person',1700.00


--Insert RoomBookingDetails
CREATE PROC SP_RoomBookingDetails
( 
@EmailID VARCHAR(50),	
@CheckInDate DATETIME,
@CheckOutDate DATETIME,
@TotalAmount DECIMAL(10,2),
@BookedDate DATETIME,
@HRID INT,
@CreatedBy VARCHAR(50),
@ModifiedBy VARCHAR(50)
)
As
BEGIN
INSERT INTO RoomBookingDetails VALUES (@EmailID,@CheckInDate,@CheckOutDate,@TotalAmount,@BookedDate,@HRID,@CreatedBy,@ModifiedBy)
END

EXEC SP_RoomBookingDetails 'Bhala123@gmail.com','2023-04-20 14:30:00','2023-04-21 12:30:00',1500.00,'2023-04-19 08:30:00',1,'Krithi','Krithi'
EXEC SP_RoomBookingDetails 'Kamala12@gmail.com','2023-05-17 10:00:00','2023-05-18 12:30:00',1000.00,'2023-05-16 20:30:00',2,'Raghul','Raghul'
EXEC SP_RoomBookingDetails 'Kavi70@gmail.com','2023-05-10 14:00:00','2023-05-11 18:30:00',1500.00,'2023-05-09 21:30:00',3,'Deepi','Deepi'
EXEC SP_RoomBookingDetails 'mariii@gmail.com','2023-05-18 14:30:00','2023-05-19 12:30:00',2500.00,'2023-05-17 08:30:00',4,'Shri','Shri'
EXEC SP_RoomBookingDetails 'mathu90@gmail.com','2023-05-20 09:30:00','2023-05-24 09:30:00',3500.00,'2023-05-19 08:30:00',5,'Raju','Raju'
EXEC SP_RoomBookingDetails 'nandhini19@mail.com','2023-04-20 14:30:00','2023-04-21 12:30:00',1500.00,'2023-04-19 08:30:00',2,'Vijay','vijay'
EXEC SP_RoomBookingDetails 'vika19@gmail.com','2023-05-24 14:30:00','2023-05-25 12:30:00',1500.00,'2023-05-23 08:30:00',3,'Viky','viky'
EXEC SP_RoomBookingDetails 'Mahesh412@gmail.com','2023-05-25 14:30:00','2023-05-26 12:30:00',1500.00,'2023-05-24 08:30:00',3,'Rishi','Rishi'

--Sp for inserting RoomAvailability

ALTER PROC SP_RoomAvailability
(
@HRID INT,
@AvailableDate DATE,
@IsAvailable BIT 
)
AS
BEGIN
INSERT INTO RoomAvailability VALUES (@HRID,@AvailableDate,@IsAvailable)
END


EXEC SP_RoomAvailability  11,'2023-06-1',0
EXEC SP_RoomAvailability  12,'2023-06-1',0


--Sp for getting location from hotel table

CREATE PROCEDURE [dbo].[GetHotelsByLocation]
    @Location varchar(25)
AS
BEGIN
    SELECT *
    FROM Hotel
    WHERE Location = @Location;
END

Exec [GetHotelsByLocation] 'Coimbatore'

--Sp for Insert and Update

ALTER PROCEDURE InsertUpdateUser
(
@EmailID VARCHAR(50) ,
@FirstName VARCHAR(25),
@LastName VARCHAR(25),
@UserPassword VARCHAR(15),
@IsAdmin BIT,
@PhoneNumber BIGINT,
@IsActive BIT
)
AS
BEGIN
    SET NOCOUNT ON;
	IF EXISTS (SELECT 1 FROM [User] WHERE EmailID = @EmailID)
    BEGIN
        UPDATE [User] SET FirstName = @FirstName, LastName = @LastName ,UserPassword = @UserPassword ,IsAdmin = @IsAdmin,PhoneNumber = @PhoneNumber,IsActive = @IsActive WHERE EmailID = @EmailID;
		SELECT 'Value Updated' AS result
    END
ELSE
    BEGIN
        INSERT INTO [User] (UserID, EmailID, FirstName, LastName, UserPassword,IsAdmin,PhoneNumber,IsActive ) VALUES (NEWID(),@EmailID, @FirstName, @LastName, @UserPassword,  @IsAdmin, @PhoneNumber, @IsActive);
		SELECT 'Value Inserted' AS result
    END
END


EXEC InsertUpdateUser 'ram12@mail.com', 'ram', 'som', 'raso', 0, 9215688963,0 


--sp for GetByEmailID

CREATE PROCEDURE sp_GetByEmailId
    @EmailID varchar(50)
AS
BEGIN
    SELECT * FROM [User] WHERE EmailID = @EmailID
END

EXEC sp_GetByEmailId 'viki19@gmail.com'

--sp for DeleteById

CREATE PROCEDURE sp_DeleteByEmailId
@EmailID varchar(50)
AS
BEGIN
    DELETE FROM [User] WHERE EmailID = @EmailID
END

EXEC sp_DeleteByEmailId 'mar@gmail.com'



INSERT INTO Hotel(LocationID) VALUES(1) WHERE HotelID = 10


--sp for GetAllLocation

CREATE PROCEDURE sp_GetAllLocation
AS
BEGIN
    SELECT LocationID,LocationName FROM [Location]
END

--sp for Location GetByID

CREATE PROCEDURE sp_GetByLocationId
    @LocationID INT
AS
BEGIN
    SELECT * FROM [Location] WHERE LocationID = @LocationID
END

EXEC sp_GetByLocationId 1

--Sp for HotelName and Procedure

ALTER PROCEDURE USP_HotelLocationDetails
    @hotelName varchar(50) = NULL,
    @locationName varchar(15) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @hotelName IS NOT NULL AND @locationName IS NOT NULL
    BEGIN
        SELECT H.HotelID, H.HotelName, H.HotelDescription, H.Rating, H.NoOfRooms, H.Amenities, H.LocationID, L.LocationName
        FROM Hotel H
        INNER JOIN [Location] L ON L.LocationID = H.LocationID 
        WHERE H.HotelName LIKE '%' + @hotelName + '%'
          AND L.LocationName LIKE '%' + @locationName + '%';
    END
    ELSE IF @hotelName IS NOT NULL
    BEGIN
        SELECT H.HotelID, H.HotelName, H.HotelDescription, H.Rating, H.NoOfRooms, H.Amenities, H.LocationID, L.LocationName
        FROM Hotel H
        INNER JOIN [Location] L ON L.LocationID = H.LocationID 
        WHERE H.HotelName LIKE '%' + @hotelName + '%';
    END
    ELSE IF @locationName IS NOT NULL
    BEGIN
        SELECT H.HotelID, H.HotelName, H.HotelDescription, H.Rating, H.NoOfRooms, H.Amenities, H.LocationID, L.LocationName
        FROM Hotel H
        INNER JOIN [Location] L ON L.LocationID = H.LocationID 
        WHERE L.LocationName LIKE '%' + @locationName + '%';
    END
    ELSE
    BEGIN
        SELECT H.HotelID, H.HotelName, H.HotelDescription, H.Rating, H.NoOfRooms, H.Amenities, H.LocationID, L.LocationName
        FROM Hotel H
        INNER JOIN [Location] L ON L.LocationID = H.LocationID;
    END
END

EXEC USP_HotelLocationDetails "Taj",null
----------------------------------------------------------------------------------------------------

--Getting Hotels name by its partial name

ALTER PROCEDURE GetHotelsByPartialName
    @PartialName NVARCHAR(50)
AS
BEGIN
    SELECT TOP 5 HotelId AS Id , HotelName AS [Name]
    FROM Hotel
    WHERE HotelName LIKE '%' +@PartialName+'%'
END

EXEC GetHotelsByPartialName 'Hin'

--Getting Location name by its partial name

ALTER PROCEDURE GetLocationsByPartialName
   @LocationPartialName NVARCHAR(15)
AS
BEGIN
   SELECT TOP 5 LocationID AS Id, LocationName AS [Name]
   FROM [Location]
   WHERE LocationName LIKE '%' +@LocationPartialName+ '%'
END

EXEC GetLocationsByPartialName 'Chennai'

--sp CheckLogin

ALTER PROCEDURE CheckLogin
    @EmailID VARCHAR(50),
    @UserPassword VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT *
        FROM [User]
        WHERE EmailID = @EmailID AND UserPassword = @UserPassword
    )
    BEGIN
        SELECT 'Login successful!' AS Result
    END
    ELSE
    BEGIN
        SELECT 'Invalid email or password.' AS Result
    END
END

EXEC CheckLogin 'Bhala123@gmail.com','Bala'

--sp for signup page

ALTER PROCEDURE SignUp
    @EmailID VARCHAR(50),
	@FirstName VARCHAR(25),
    @LastName VARCHAR(25),
    @UserPassword VARCHAR(15),
    @IsAdmin BIT,
    @PhoneNumber BIGINT ,
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM [User] WHERE EmailID = @EmailID)    
    BEGIN
        SELECT 'Email already exists.' AS Result
    END
    ELSE
    BEGIN
        INSERT INTO [User] (UserID,EmailID,FirstName,LastName,UserPassword,IsAdmin,PhoneNumber,IsActive) VALUES (NEWID(),@EmailID,@FirstName,@LastName,@UserPassword,@IsAdmin,@PhoneNumber,@IsActive)
        SELECT 'SignUp successful.' AS Result
    END
END

EXEC SignUp 'narmu10@gmail.com','narma','sakhi','narm10',0,6898852520,1

--sp for GetAllRoomDetail

CREATE PROCEDURE USP_GetAllHotelRoomDetail
AS
BEGIN
SELECT * FROM HotelRoomDetails
END

--sp for GetByHotelId

ALTER PROCEDURE USP_GetHotelRoomDetailsByHotelID
	@HotelID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT HR.HotelID,H.HotelName,HR.HRID,HR.HotelRoomNumber, HR.RoomTypeID,HR.RoomDescription,HR.RoomPrice
    FROM HotelRoomDetails HR
    INNER JOIN Hotel H ON HR.HotelID = H.HotelID
    WHERE H.HotelID = @HotelID;
END

EXEC USP_GetHotelRoomDetailsByHotelID 11

--sp for GetAllRoomBookingDetails

CREATE PROCEDURE USP_GetAllRoomBookingDetail
AS
BEGIN
SELECT * FROM RoomBookingDetails
END

--sp for GetCheckInDetailsForCurrentDay

CREATE PROCEDURE GetCheckInDetailsForCurrentDay
AS
BEGIN
    SET NOCOUNT ON;
    SELECT RoombookingId,EmailID, UserName, CheckInDate, RoomNumber
    FROM RoomBookingDetails
    WHERE CAST(CheckInDate AS DATE) = CAST(GETDATE() AS DATE);
END

--Update AdminHotelID
UPDATE RoomBookingDetails
SET CheckInDate = '2023-05-25 14:30:00',CheckOutDate = '2023-05-26 12:30:00',BookedDate = '2023-05-23 08:30:00'
WHERE EmailID ='Mahesh412@gmail.com';

UPDATE RoomBookingDetails
SET StatusID = 1 WHERE EmailID = 'mariii@gmail.com'


SELECT * FROM [User]
SELECT * FROM RoomBookingDetails
SELECT * FROM RoomAvailability
SELECT * FROM [Status]
SELECT * FROM Hotel


--sp to GetCurrentDateCheckInDetails
CREATE PROCEDURE GetCheckInDetails
    @EmailID VARCHAR(50)    
AS
BEGIN
    SET NOCOUNT ON;
	 IF EXISTS (SELECT 1 FROM [User] WHERE EmailID = @EmailID AND IsAdmin=1)
	  BEGIN
	   DECLARE @HotelID INT;
	   SET @HotelID=(SELECT AdminHotelID FROM [User] WHERE EmailID = @EmailID AND IsAdmin=1)
       select rbd.EmailID, hrd.HRID,hrd.HotelRoomNumber,hrd.HotelID,hrd.RoomTypeID,hrd.RoomDescription,hrd.RoomPrice,rbd.RoomBookingId,rbd.CheckInDate,rbd.CheckOutDate,rbd.TotalAmount,rbd.BookedDate,rbd.CreatedBy,rbd.ModifiedBy,'' AS AccessDenied FROM HotelRoomDetails hrd join RoomBookingDetails rbd on hrd.HRID=rbd.HRID where hrd.HotelID=@HotelID and  CAST(rbd.CheckInDate AS DATE) = CAST(GETDATE() AS DATE)
    END
    ELSE
    BEGIN      
        SELECT 'RESTRICTED ACCESS' AS AccessDenied
    END	        
END

EXEC GetCheckInDetails 'vika19@gmail.com'

--sp to GetCurrentDateCheckOutDetails

CREATE PROCEDURE GetCheckOutDetails
    @EmailID VARCHAR(50)    
AS
BEGIN
    SET NOCOUNT ON;
	 IF EXISTS (SELECT 1 FROM [User] WHERE EmailID = @EmailID AND IsAdmin=1)
	  BEGIN
	   DECLARE @HotelID INT;
	   SET @HotelID=(SELECT AdminHotelID FROM [User] WHERE EmailID = @EmailID AND IsAdmin=1)
       select rbd.EmailID, hrd.HRID,hrd.HotelRoomNumber,hrd.HotelID,hrd.RoomTypeID,hrd.RoomDescription,hrd.RoomPrice,rbd.RoomBookingId,rbd.CheckInDate,rbd.CheckOutDate,rbd.TotalAmount,rbd.BookedDate,rbd.CreatedBy,rbd.ModifiedBy,'' AS AccessDenied FROM HotelRoomDetails hrd join RoomBookingDetails rbd on hrd.HRID=rbd.HRID where hrd.HotelID=@HotelID and  CAST(rbd.CheckOutDate AS DATE) = CAST(GETDATE() AS DATE)
    END
    ELSE
    BEGIN      
        SELECT 'RESTRICTED ACCESS' AS AccessDenied
    END	        
END

EXEC GetCheckOutDetails 'vika19@gmail.com'

--sp to cancelHotelroom

CREATE OR ALTER PROCEDURE CancelHotelRoom
    @EmailID VARCHAR(50)    
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @statusID INT;
	   SET @statusID =(SELECT StatusID FROM RoomBookingDetails WHERE EmailID = @EmailID)
	   IF EXISTS (SELECT StatusID FROM RoomBookingDetails WHERE EmailID = @EmailID AND StatusID=1)
	   BEGIN
	   UPDATE RoomBookingDetails
       SET StatusID = 0 WHERE EmailID = @EmailID
	   END
	   ELSE
	   BEGIN
	   UPDATE RoomBookingDetails
       SET StatusID = 1 WHERE EmailID = @EmailID
	   END
END

EXEC CancelHotelRoom 'Kamala12@gmail.com'

----
create index IHotelRoomId
ON HotelRoomDetails(HRID)

SELECT *
FROM HotelRoomDetails WITH(INDEX(IHotelRoomId)) WHERE HRID = 2

SELECT 
    ROW_NUMBER() OVER (ORDER BY HRID) AS RowNumber
FROM HotelRoomDetails 

SELECT HRID
FROM (SELECT ROW_NUMBER() OVER (ORDER BY HRID ASC) AS RowNumber, HRID, HotelRoomNumber, HotelID, RoomTypeID, RoomDescription, RoomPrice
    FROM HotelRoomDetails)
    AS SubqueryAlias WHERE RowNumber = 1

select * from HotelRoomDetails


----RoomAvailability loop
CREATE OR ALTER PROCEDURE RoomAvailabilityEntry (@StartDate Date,@Days INT) 
AS
BEGIN
	Declare @count int = 1,
	@roomCount int = 0,
	@sdate date = @StartDate

	SET @roomCount = (select COUNT(*) from HotelRoomDetails)
	WHILE(@count<=@Days)
	BEGIN
		Declare @rcount int = 1;
		Declare @HRID int = 0; 
		WHILE(@rcount <= @roomCount)
		BEGIN
			SET @HRID = (SELECT HRID
							FROM (SELECT ROW_NUMBER() OVER (ORDER BY HRID ASC) AS RowNumber, HRID, HotelRoomNumber, HotelID, RoomTypeID, RoomDescription, RoomPrice
								FROM HotelRoomDetails) AS SubqueryAlias WHERE RowNumber = @rcount);

			IF NOT EXISTS(select * from RoomAvailability WHERE HRID = @HRID AND AvailableDate = @sdate)
			BEGIN
				INSERT INTO RoomAvailability (HRID,AvailableDate,IsAvailable) VALUES (@HRID,@sdate,1);
			END
			SET @rcount = @rcount + 1;
		END
		SET @sdate = DATEADD(D,1,@sdate)
		SET @count = @count + 1
	END
END

exec RoomAvailabilityEntry '2023-06-12',30
select * from RoomAvailability

--BookRoom based on availability

CREATE OR ALTER PROCEDURE SP_BookRoom
@EmailID VARCHAR(50),   
@BookedDate DATETIME
AS
BEGIN
SET NOCOUNT ON;
DECLARE @HRID int = 0;
DECLARE @Name VARCHAR;
SET @HRID = (SELECT rbd.HRID FROM RoomBookingDetails rbd WHERE EmailID = @EmailID)
SET @Name = (SELECT * FROM [User] WHERE EmailID = @EmailID)
INSERT INTO RoomBookingDetails VALUES (@EmailID,NULL,NULL,NULL,@BookedDate,@HRID,NULL,NULL)
UPDATE RoomAvailability
       SET IsAvailable = 0 WHERE RAID = @RAID
END

EXEC SP_BookRoom 'Kamala12@gmail.com' , '2023-06-11'

--sp for cancel booked room

CREATE OR ALTER PROCEDURE CancelBookedRoom
