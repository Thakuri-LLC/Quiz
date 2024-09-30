CREATE TABLE [qz].[Quiz] (
    [QuizID]          INT           IDENTITY (1, 1) NOT NULL,
    [Question]        VARCHAR (500) NOT NULL,
    [CorrectOptionID] INT           NULL,
    PRIMARY KEY CLUSTERED ([QuizID] ASC),
    CONSTRAINT [qz_Quiz_Question] UNIQUE NONCLUSTERED ([Question] ASC)
);

