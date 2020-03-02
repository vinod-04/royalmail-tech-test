
USE [TechTest]

GO
SET IDENTITY_INSERT [dbo].[Skills] ON 
GO
INSERT [dbo].[Skills] ([SkillId], [Name], [IsEnabled]) VALUES (1, N'C#', 1)
GO
INSERT [dbo].[Skills] ([SkillId], [Name], [IsEnabled]) VALUES (2, N'Javascript', 1)
GO
INSERT [dbo].[Skills] ([SkillId], [Name], [IsEnabled]) VALUES (3, N'Java', 1)
GO
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (1, N'David', N'Hirst', 0, 1, 0)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (2, N'Nigel', N'Pearson', 0, 0, 0)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (3, N'John', N'Harkes', 0, 1, 1)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (4, N'Carlton', N'Palmer', 0, 0, 0)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (5, N'Kevin', N'Pressman', 0, 1, 1)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (6, N'Nigel', N'Worthington', 0, 0, 0)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (7, N'Viv', N'Anderson', 0, 1, 0)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (8, N'Phil', N'King', 0, 0, 0)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (9, N'John', N'Sheridan', 0, 1, 1)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (10, N'Danny', N'Wilson', 0, 1, 1)
GO
INSERT [dbo].[People] ([PersonId], [FirstName], [LastName], [IsAdmin], [IsValid], [IsEnabled]) VALUES (11, N'Si', N'Sis', 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (1, 1)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (1, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (1, 3)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (2, 1)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (2, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (2, 3)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (3, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (4, 1)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (4, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (4, 3)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (5, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (6, 1)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (7, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (7, 3)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (8, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (9, 1)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (10, 1)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (10, 2)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (10, 3)
GO
INSERT [dbo].[PersonSkills] ([PersonId], [SkillId]) VALUES (11, 1)
GO