CREATE TABLE [qz].[QuizOption] (
    [QuizOptionID]   INT          IDENTITY (1, 1) NOT NULL,
    [QuizOptionName] VARCHAR (50) NOT NULL,
    [QuizID]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([QuizOptionID] ASC),
    FOREIGN KEY ([QuizID]) REFERENCES [qz].[Quiz] ([QuizID]),
    CONSTRAINT [qz_QuizOption_QuizID_QuizOptionName] UNIQUE NONCLUSTERED ([QuizID] ASC, [QuizOptionName] ASC)
);

