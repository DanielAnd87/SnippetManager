USE [MySnippets]
GO
/****** Object:  Table [dbo].[Folder]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[FolderId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[DefaultLanguage] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FolderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fragment]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fragment](
	[FragmentId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[SnippetId] [int] NOT NULL,
	[LanguageId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FragmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Selected] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Snippet]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Snippet](
	[SnippetId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[FolderId] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SnippetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[SnippetId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Folder] ON 

INSERT [dbo].[Folder] ([FolderId], [Name], [DefaultLanguage]) VALUES (25, N'another', 1)
INSERT [dbo].[Folder] ([FolderId], [Name], [DefaultLanguage]) VALUES (1012, N'React', 2)
INSERT [dbo].[Folder] ([FolderId], [Name], [DefaultLanguage]) VALUES (1013, N'AngularJs', 2)
INSERT [dbo].[Folder] ([FolderId], [Name], [DefaultLanguage]) VALUES (1014, N'node.js', 2)
INSERT [dbo].[Folder] ([FolderId], [Name], [DefaultLanguage]) VALUES (1015, N'.Net C#', 2)
SET IDENTITY_INSERT [dbo].[Folder] OFF
SET IDENTITY_INSERT [dbo].[Fragment] ON 

INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (4, N'mass vin doke som ör fin ', 1, 1)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (5, N'mass vin doke som ör fin ', 1, 1)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (28, N'write your code here...', 26, 1)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (38, N'write your code here...', 36, 1)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (39, N'write your code here...', 37, 1)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (1007, N' m.forEach(k=>{}', 1007, 1)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (1008, N'write your code here...', 1008, 2)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (1009, N'app.listen(3000, () => console.log(''server started''));', 1009, 2)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (1010, N'this.chart1.series[i].data = [this.$store.state.selectedcities[0].value[i]];', 1010, 2)
INSERT [dbo].[Fragment] ([FragmentId], [Code], [SnippetId], [LanguageId]) VALUES (1011, N'write your code here...', 1011, 2)
SET IDENTITY_INSERT [dbo].[Fragment] OFF
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([LanguageId], [Name], [Selected]) VALUES (1, N'Plain Text', 1)
INSERT [dbo].[Language] ([LanguageId], [Name], [Selected]) VALUES (2, N'JavaScript', 1)
INSERT [dbo].[Language] ([LanguageId], [Name], [Selected]) VALUES (3, N'test', 0)
SET IDENTITY_INSERT [dbo].[Language] OFF
SET IDENTITY_INSERT [dbo].[Snippet] ON 

INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (1, N'new name is the skit', 1, N'new description!!')
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (4, N'a nam', 2, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (5, N'a nam', 2, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (7, N'a nam', 4, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (8, N'a nam', 5, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (9, N'a nam', 5, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (26, N' ', 1, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (36, N'test ', 1, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (37, N'test ', 1, NULL)
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (1007, N'forloop array', 25, N'Vue.js')
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (1008, N'console logging', 1012, N'.Net C#')
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (1009, N'listen to port', 1014, N'')
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (1010, N'array state', 1012, N'simple explanation')
INSERT [dbo].[Snippet] ([SnippetId], [Name], [FolderId], [Description]) VALUES (1011, N'Array initiatIon', 1012, N'')
SET IDENTITY_INSERT [dbo].[Snippet] OFF
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([TagId], [Name], [SnippetId]) VALUES (1, N'new tag name', 1)
INSERT [dbo].[Tag] ([TagId], [Name], [SnippetId]) VALUES (2, N'another tag name', 1)
SET IDENTITY_INSERT [dbo].[Tag] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tag__737584F690B61F5F]    Script Date: 6/10/2021 6:17:25 PM ******/
ALTER TABLE [dbo].[Tag] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Folder]  WITH CHECK ADD FOREIGN KEY([DefaultLanguage])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Fragment]  WITH CHECK ADD FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Fragment]  WITH CHECK ADD FOREIGN KEY([SnippetId])
REFERENCES [dbo].[Snippet] ([SnippetId])
GO
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD FOREIGN KEY([SnippetId])
REFERENCES [dbo].[Snippet] ([SnippetId])
GO
/****** Object:  StoredProcedure [dbo].[Snippet_AddFolder]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_AddFolder] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@DefaultLanguage [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		INSERT INTO [dbo].[Folder]
           ([Name]
           ,[DefaultLanguage])
     VALUES
           (@Name,
           @DefaultLanguage)
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_AddFragment]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_AddFragment] 
	-- Add the parameters for the stored procedure here
	@Code [nvarchar](255),
	@SnippetId [int],
	@LanguageId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		INSERT INTO [dbo].[Fragment]
           ([Code]
           ,[SnippetId]
           ,[LanguageId])
     VALUES
           (@Code
           ,@SnippetId
           ,@LanguageId)
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_AddLanguage]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_AddLanguage] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		INSERT INTO [dbo].[Language]
           ([Name]
           ,[Selected])
     VALUES
           (@Name,
           0)
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_AddSnippet]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_AddSnippet] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@FolderId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @id int;
	begin Transaction
		INSERT INTO [dbo].[Snippet]
			   ([Name]
			   ,[FolderId])
		 VALUES
			   (@Name,
				@FolderId);

		select @id = Scope_Identity();
		
		declare @languageId int;
		set @languageId = (SELECT [DefaultLanguage]
		  FROM [dbo].[Folder] 
		 WHERE FolderId = @FolderId)

		exec dbo.Snippet_AddFragment "write your code here...", @id, @languageId;
	COMMIT Transaction
	RETURN @id;
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_AddTag]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_AddTag] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@SnippetId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		INSERT INTO [dbo].[Tag]
			   ([Name]
			 ,[SnippetId])
		 VALUES
			   (@Name,
				@SnippetId)
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_DeleteFolder]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_DeleteFolder] 
	-- Add the parameters for the stored procedure here
	
	@FolderId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction

	 DECLARE @SnippetId INT

	DECLARE CurName CURSOR FAST_FORWARD READ_ONLY
	FOR
		SELECT  SnippetId
		FROM    Snippet
		WHERE FolderId = @FolderId

	 OPEN CurName

	FETCH NEXT FROM CurName INTO @SnippetId

 WHILE @@FETCH_STATUS = 0
    BEGIN
		exec Snippet_DeleteSnippet @SnippetId;
        
        FETCH NEXT FROM CurName INTO @SnippetId;

    END

 CLOSE CurName
 DEALLOCATE CurName


		DELETE [dbo].Folder
		 WHERE [FolderId] =  @FolderId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_DeleteFragment]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Snippet_DeleteFragment] 
	-- Add the parameters for the stored procedure here
	
	@fragmentId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		DELETE [dbo].Fragment
		 WHERE [FragmentId] =  @fragmentId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_DeleteSnippet]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Snippet_DeleteSnippet] 
	-- Add the parameters for the stored procedure here
	
	@snippetId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		DELETE [dbo].Tag
		 WHERE [SnippetId] =  @snippetId

		 	DELETE [dbo].Fragment
		 WHERE [SnippetId] =  @snippetId

		 
		 	DELETE [dbo].Snippet
		 WHERE [SnippetId] =  @snippetId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_DeleteTag]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Snippet_DeleteTag] 
	-- Add the parameters for the stored procedure here
	
	@tagId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		DELETE [dbo].Tag
		 WHERE [TagId] =  @tagId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_DuplicateSnippet]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_DuplicateSnippet] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@Description [nvarchar](255),
	@FolderId [int],
	@SnippetId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		declare @id int;
	begin Transaction
		INSERT INTO [dbo].[Snippet]
			   ([Name]
			   ,[FolderId])
		 VALUES
			   (@Name,
				@FolderId);

		select @id = Scope_Identity();
		
		declare @languageId int;
		set @languageId = (SELECT [DefaultLanguage]
		  FROM [dbo].[Folder] 
		 WHERE FolderId = @FolderId)

		exec dbo.Snippet_AddFragment "write your code here...", @id, @languageId;
	COMMIT Transaction
	RETURN @id;
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_GetSnippetsFromFolder]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_GetSnippetsFromFolder] 
	-- Add the parameters for the stored procedure here
	@FolderId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT * FROM Snippet 
	WHERE FolderId = @FolderId
RETURN

END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateFolder]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateFolder] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@FolderId [int],
	@DefaultLanguage [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].[Folder]
			  SET[Name] =  @Name
		 WHERE [FolderId] =  @FolderId

		 begin Transaction
		UPDATE [dbo].[Folder]
			  SET [DefaultLanguage] =  @DefaultLanguage
		 WHERE [FolderId] =  @FolderId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateFolderName]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateFolderName] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@FolderId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].[Folder]
			  SET[Name] =  @Name
		 WHERE [FolderId] =  @FolderId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateFragmentCode]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateFragmentCode] 
	-- Add the parameters for the stored procedure here
	
	@fragmentId [int],
	@code[nvarchar](255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].Fragment
			  SET [Code] =  @code
		 WHERE [FragmentId] =  @fragmentId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateFragmentLanguage]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[Snippet_UpdateFragmentLanguage] 
	-- Add the parameters for the stored procedure here
	
	@fragmentId [int],
	@languageId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].Fragment
			  SET [LanguageId] =  @languageId
		 WHERE [FragmentId] =  @fragmentId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateLanguageSelection]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateLanguageSelection] 
	-- Add the parameters for the stored procedure here
	@Selection [bit],
	@LanguageId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].[Language]
			  SET [Selected] =  @Selection
		 WHERE [LanguageId] =  @LanguageId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateSnippetDescription]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateSnippetDescription] 
	-- Add the parameters for the stored procedure here
	@Description [nvarchar](255),
	@SnippetId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].[Snippet]
			  SET [Description] =  @Description
		 WHERE [SnippetId] =  @SnippetId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateSnippetName]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateSnippetName] 
	-- Add the parameters for the stored procedure here
	@Name [nvarchar](255),
	@SnippetId [int]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].[Snippet]
			  SET [Name] =  @Name
		 WHERE [SnippetId] =  @SnippetId
	COMMIT Transaction
END
GO
/****** Object:  StoredProcedure [dbo].[Snippet_UpdateTagName]    Script Date: 6/10/2021 6:17:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Snippet_UpdateTagName] 
	-- Add the parameters for the stored procedure here
	
	@tagId [int],
	@Name[nvarchar](255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin Transaction
		UPDATE [dbo].Tag
			  SET [Name] =  @Name
		 WHERE [TagId] =  @tagId
	COMMIT Transaction
END
GO
