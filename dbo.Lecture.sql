CREATE TABLE [dbo].[Lecture] (
    [LectureId]   INT            IDENTITY (1, 1) NOT NULL,
    [RoomId]      INT            NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [StartTime]   DATETIME2 (7)  NOT NULL,
    [Speaker]     NVARCHAR (MAX) NULL,
    [CategoryId]  INT          NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [TimeFrame]   INT            NOT NULL,
    [Spaces]      INT            NOT NULL,
    CONSTRAINT [PK_Lecture] PRIMARY KEY CLUSTERED ([LectureId] ASC),
    CONSTRAINT [FK_Lecture_Room_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([RoomId]) ON DELETE CASCADE,
	CONSTRAINT [FK_Lecture_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Lecture_RoomId]
    ON [dbo].[Lecture]([RoomId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_Lecture_CategoryId]
    ON [dbo].[Lecture]([CategoryId] ASC);