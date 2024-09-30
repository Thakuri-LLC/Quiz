CREATE TABLE [dbo].[QuizLog] (
    [QuizLogID] INT      IDENTITY (1, 1) NOT NULL,
    [SessionID] BIGINT   NOT NULL,
    [QuizID]    INT      NOT NULL,
    [OptionID]  INT      NULL,
    [UpdatedOn] DATETIME DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([QuizLogID] ASC)
);

