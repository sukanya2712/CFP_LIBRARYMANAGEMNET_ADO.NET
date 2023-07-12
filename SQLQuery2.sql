Create DATABASE LibraryManagement;

use LibraryManagement;

CREATE TABLE LibraryBooks(
    ID int primary key Identity(1,1),
    Title varchar(50),
    Author varchar(50),
    Genre varchar(50),
    Borrowed int
)

--DROP DATABASE LibraryManagement;

CREATE PROCEDURE AddBook
    @Title VARCHAR(100),
    @Author VARCHAR(100),
    @Genre VARCHAR(20),
	@Borrowed int
AS
BEGIN
    INSERT INTO LibraryBooks VALUES(@Title,@Author,@Genre,@Borrowed)
END

CREATE PROCEDURE AddBooks
    @Title VARCHAR(100),
    @Author VARCHAR(100),
    @Genre VARCHAR(20),
    @Borrowed INT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO LibraryBooks VALUES (@Title, @Author, @Genre, @Borrowed);
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END

CREATE PROCEDURE getbooks
AS
BEGIN 
    BEGIN TRANSACTION
	    BEGIN TRY
		   DECLARE @BookCount INT;
           SELECT @BookCount = COUNT(Title) FROM LibraryBooks;
		   SELECT @BookCount AS TotalBook;
		   COMMIT;
		END TRY
		BEGIN CATCH
		   ROLLBACK;
		END CATCH;
END

CREATE PROCEDURE getbooklist
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        SELECT * FROM LibraryBooks;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END

EXEC getbooklist;

----------------------------------------no of availble books-------------------
CREATE PROCEDURE NOOFAVABOOKS
AS
BEGIN
    BEGIN TRANSACTION;
	BEGIN TRY
	   DECLARE @AVABookCount INT;
           SELECT @AVABookCount = COUNT(Borrowed) FROM LibraryBooks WHERE Borrowed = 0;
		   SELECT @AVABookCount AS TotalAvailbeBook;
		   COMMIT;
		END TRY
		BEGIN CATCH
		   ROLLBACK;
		END CATCH;
END

EXEC NOOFAVABOOKS;
-------------------------------no of borrowd books ----------------------------------
CREATE PROCEDURE NOOFBORROWEDBOOKS
AS
BEGIN
    BEGIN TRANSACTION;
	BEGIN TRY
	   DECLARE @BORBookCount INT;
           SELECT @BORBookCount = COUNT(Borrowed) FROM LibraryBooks WHERE Borrowed = 1;
		   SELECT @BORBookCount AS TotalBorrowedBook;
		   COMMIT;
		END TRY
		BEGIN CATCH
		   ROLLBACK;
		END CATCH;
END

EXEC NOOFBORROWEDBOOKS;
-------------------------------------BooksbyAuthor---------------------------------------------
CREATE PROCEDURE GetBooksByAuthor
    @AuthorName VARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        SELECT * FROM LibraryBooks WHERE Author = @AuthorName;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END;

EXEC GetBooksByAuthor @AuthorName = 'anna todd';

--------------------------------------BooksbyGenre-------------------------
CREATE PROCEDURE GetBooksByGenre
    @GenreName VARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        SELECT * FROM LibraryBooks WHERE Genre = @GenreName;
        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
    END CATCH;
END;

EXEC GetBooksByAuthor @GenreName = 'anna todd';

