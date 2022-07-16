**Initialize Database**

Change the ConnectionStrings -> Database in appsettings.json

```dotnet EF database update```


**Solution**

1) GET /api/Books/GetOrderedByPublisherAuthorTitle
2) GET /api/Books/GetOrderedByAuthorTitle
3) I designed a single Book table with the following structure:
``` sql
CREATE TABLE [dbo].[Book](
	[BookId] [uniqueidentifier] NOT NULL,
	[Publisher] [nvarchar](100) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[AuthorLastName] [nvarchar](50) NOT NULL,
	[AuthorFirstName] [nvarchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Citation] [nvarchar](max) NULL,
	CONSTRAINT [PK_Book] PRIMARY KEY
	(
		[BookId]
	)
)
```
- I used the Citation column as a serializable JSON. Since we only need the Citation data for display purposes, if we needed this information for more complex operations like filtering or sorting we could create a new Citation related table.
- Another data normalization option would be to create independent tables for Authors and Publishers and relate them to the Book table by a foreign key.

4) GET /api/Books/GetOrderedByPublisherAuthorTitleFromSp, GET /api/Books/GetOrderedByAuthorTitleFromSp
``` sql
CREATE OR ALTER PROC [dbo].[spGetOrderedByPublisherAuthorTitle] 
    AS
    BEGIN
	    SET NOCOUNT ON;
	    SELECT * FROM Book
	    ORDER BY Publisher, AuthorLastName, AuthorFirstName, Title
    END

CREATE OR ALTER PROC [dbo].[spGetOrderedByAuthorTitle] 
    AS
    BEGIN
	    SET NOCOUNT ON;
	    SELECT * FROM Book 
	    ORDER BY AuthorLastName, AuthorFirstName, Title
    END
```
5) GET /api/Books/GetTotalPrice

6) Using AddRangeAsync Ex. BookService /  `InsertBulk(List<Book> books)`
7) I added a CitationMLAStyle property on the BookModel class that is populated with the BookService's FormatMLAStyle function.
8) I added a CitationChicagoStyle property on the BookModel class that is populated with the BookService's FormatChicagoStyle function.